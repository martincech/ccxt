import asyncio
import json
import logging
import ssl

# API inter-command timeout (in ms)
API_SEND_TIMEOUT = 205

# max connection tries
API_MAX_CONN_TRIES = 3


class JsonSocket(object):
    def __init__(self, address: str, port: int, encrypt=False, conn_retries=API_MAX_CONN_TRIES,
                 logger=logging.getLogger(__name__)):
        self.writer = None
        self.reader = None
        self._logger = logger
        self._conn_retries = conn_retries
        self._ssl = encrypt
        self._address = address
        self._port = port
        self._decoder = json.JSONDecoder()
        self._receivedData = ''
        self._is_connected = False

    def __del__(self):
        self.disconnect()

    async def connect(self):
        if not self._is_connected:
            for i in range(self._conn_retries):
                try:
                    if not self._ssl:
                        self.reader, self.writer = await asyncio.open_connection(self._address, self._port)
                    else:
                        ssl_context = ssl.create_default_context()
                        self.reader, self.writer = await asyncio.open_connection(self._address, self._port,
                                                                                 ssl=ssl_context)
                except (OSError, asyncio.TimeoutError) as msg:
                    self._logger.error("SockThread Error: %s" % msg)
                    await asyncio.sleep(0.25)
                    continue
                self._logger.debug("Socket connected")
                self._is_connected = True
                break
            if not self._is_connected:
                raise Exception(f"Cannot connect to {self._address}:{self._port} after {self._conn_retries} retries")
        return self._is_connected

    async def _sendObj(self, obj):
        msg = json.dumps(obj)
        await self._waitingSend(msg)

    async def _waitingSend(self, msg):
        if self.writer:
            msg = msg.encode('utf-8')
            try:
                self.writer.write(msg)
                await self.writer.drain()
                await asyncio.sleep(API_SEND_TIMEOUT / 1000)
            except (OSError, asyncio.TimeoutError):
                self.disconnect()
                raise BrokenPipeError("socket connection broken")

    async def _read(self, bytesSize=4096):
        if not self.reader:
            self.disconnect()
            raise BrokenPipeError("socket connection broken")
        while True:
            char = await self.reader.read(bytesSize)
            if not char:
                break
            self._receivedData += char.decode()
            try:
                (resp, size) = self._decoder.raw_decode(self._receivedData)
                if size == len(self._receivedData):
                    self._receivedData = ''
                    break
                elif size < len(self._receivedData):
                    self._receivedData = self._receivedData[size:].strip()
                    break
            except ValueError as e:
                continue
        return resp

    async def _readObj(self):
        return await self._read()

    def disconnect(self):
        self._logger.debug("Closing socket")
        self._is_connected = False
        if self.writer:
            self.writer.close()
            self.writer = None
        if self.reader:
            self.reader = None

    @property
    def timeout(self):
        return self.writer.get_extra_info('socket').gettimeout()

    @timeout.setter
    def timeout(self, value):
        self.writer.get_extra_info('socket').settimeout(value)

    @property
    def address(self):
        return self._address

    @property
    def port(self):
        return self._port

    @property
    def encrypt(self):
        return self._ssl
