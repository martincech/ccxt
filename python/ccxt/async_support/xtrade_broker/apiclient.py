import datetime

from ccxt.base.errors import *

from ccxt.async_support.xtrade_broker.jsonsocket import JsonSocket, API_MAX_CONN_TRIES


class APIClient(JsonSocket):
    def __init__(self, url, encrypt=True, conn_retries=API_MAX_CONN_TRIES):
        self._session_id = None
        address, port = url.split(":")
        super(APIClient, self).__init__(address, int(port), encrypt, conn_retries=conn_retries)
        self._is_logged = False

    async def execute(self, dictionary):
        await self._sendObj(dictionary)
        return await self._readObj()

    async def _command_execute(self, commandName, arguments=None):
        await self.connect()
        if arguments is not None:
            log_args = arguments.copy()
            if 'password' in arguments:
                log_args['password'] = "*" * 5
        else:
            log_args = arguments
        self._logger.debug(f"Executing {commandName} {log_args}")
        try:
            ret = await self.execute(self._baseCommand(commandName, arguments))
            if not ret['status'] and 'errorCode' in ret:
                self._logger.error(f"Error code {ret['errorCode']}: {ret['errorDescr']}")
                self._raise_by_errorcode(ret['errorCode'], ret['errorDescr'])
            if ret['status'] and 'returnData' in ret:
                return ret['returnData']
            else:
                return ret
        except Exception as e:
            self._logger.error(f"Error executing {commandName}: {e}")
            return None

    @staticmethod
    def _raise_by_errorcode(errcode, description):
        if errcode == "BE014":
            raise DDoSProtection(description)
        elif errcode == "BE004" or errcode == "EX010":
            raise AccountSuspended(description)
        elif errcode == "EX007" or errcode == "EX011":
            raise PermissionDenied(description)
        elif errcode == "BE009":
            raise InsufficientFunds(description)
        elif errcode == "BE005" or errcode == "BE103" or "BE118" or "EX004":
            raise AuthenticationError(description)
        elif errcode == "BE110" or errcode == "EX000":
            raise BadRequest(description)
        elif errcode == "BE115" or errcode == "BE116":
            raise BadSymbol(description)
        elif errcode == "EX008":
            AccountNotEnabled(description)

        raise ExchangeError(description)

    # Command templates
    def _baseCommand(self, commandName, arguments=None):
        if arguments == None:
            arguments = dict()
        return dict([('command', commandName), ('arguments', arguments)])

    async def loginCommand(self, userId, password, appName='') -> bool:
        if self._is_logged:
            return True
        resp = await self._command_execute('login', dict(userId=userId, password=password, appName=appName))
        if resp['status']:
            self._session_id = resp['streamSessionId']
            self._is_logged = True
        else:
            self._is_logged = False
        return self._is_logged

    async def getCurrentUserDataCommand(self):
        return await self._command_execute('getCurrentUserData')

    async def getMarginLevelCommand(self):
        return await self._command_execute('getMarginLevel')

    async def getAllSymbols(self):
        return await self._command_execute('getAllSymbols')

    async def getSymbol(self, symbol: str):
        return await self._command_execute('getSymbol', {"symbol": symbol})

    def _convert_timestamp(self, ts):
        if ts is None:
            ts = datetime.datetime.now().timestamp()

        def convert_float_to_int(f):
            while f % 1 != 0:
                f *= 10
            return int(f)

        return convert_float_to_int(ts)

    async def getChartRangeRequest(self, symbol, timeframe=15, since=None, until=None, limit=None):
        since = self._convert_timestamp(since)
        until = self._convert_timestamp(until)
        arguments = {
            "info": {
                "period": timeframe,
                "start": int(since),
                "symbol": symbol,
                "ticks": limit or 0,
                "end": int(until)
            }
        }
        return await self._command_execute('getChartRangeRequest', arguments)

    async def getChartLastRequest(self, symbol, timeframe=15, since=None):
        since = self._convert_timestamp(since)
        arguments = {
            "info": {
                "period": timeframe,
                "start": int(since),
                "symbol": symbol
            }
        }
        return await self._command_execute('getChartLastRequest', arguments)

    async def getServerTime(self):
        return await self._command_execute('getServerTime')

    async def getTrades(self):
        return await self._command_execute('getTrades', {"openedOnly": True})

    async def getTradeRecords(self, order_id):
        return await self._command_execute('getTradeRecords', {"orders": [
            order_id
        ]})

    async def getTradesHistory(self, since=None, until=0):
        since = self._convert_timestamp(since)
        return await self._command_execute('getTradesHistory', {
            "start": int(since),
            "end": until
        })
