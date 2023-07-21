import datetime

from ccxt.base.errors import *

from ccxt.async_support.xtrade_broker.jsonsocket import JsonSocket, API_MAX_CONN_TRIES


class APIClient(JsonSocket):
    def __init__(self, url, encrypt=True, conn_retries=API_MAX_CONN_TRIES):
        self._session_id = None
        address, port = url.split(":")
        super(APIClient, self).__init__(address, int(port), encrypt, conn_retries=conn_retries)
        if (not self.connect()):
            raise Exception(
                "Cannot connect to " + address + ":" + str(port) + " after " + str(conn_retries) + " retries")

    def execute(self, dictionary):
        self._sendObj(dictionary)
        return self._readObj()

    def disconnect(self):
        self.close()

    def _command_execute(self, commandName, arguments=None):
        if arguments is not None:
            log_args = arguments.copy()
            if 'password' in arguments:
                log_args['password'] = "*" * 5
        else:
            log_args = arguments
        self._logger.debug(f"Executing {commandName} {log_args}")
        ret = self.execute(self._baseCommand(commandName, arguments))
        if not ret['status'] and 'errorCode' in ret:
            self._logger.error(f"Error code {ret['errorCode']}: {ret['errorDescr']}")
            self._raise_by_errorcode(ret['errorCode'], ret['errorDescr'])
        if ret['status'] and 'returnData' in ret:
            return ret['returnData']
        else:
            return ret

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

    def loginCommand(self, userId, password, appName=''):
        resp = self._command_execute('login', dict(userId=userId, password=password, appName=appName))
        if resp['status']:
            self._session_id = resp['streamSessionId']
        return resp

    def getCurrentUserDataCommand(self):
        return self._command_execute('getCurrentUserData')

    def getMarginLevelCommand(self):
        return self._command_execute('getMarginLevel')

    def getAllSymbols(self):
        return self._command_execute('getAllSymbols')

    def getSymbol(self, symbol: str):
        return self._command_execute('getSymbol', {"symbol": symbol})

    def _convert_timestamp(self, ts):
        if ts is None:
            ts = datetime.datetime.now().timestamp()

        def convert_float_to_int(f):
            while f % 1 != 0:
                f *= 10
            return int(f)

        return convert_float_to_int(ts)

    def getChartRangeRequest(self, symbol, timeframe=15, since=None):
        since = self._convert_timestamp(since)
        arguments = {
            "info": {
                "period": timeframe,
                "start": int(since),
                "symbol": symbol
            }
        }
        return self._command_execute('getChartLastRequest', arguments)

    def getChartRangeRequest(self, symbol, timeframe=15, since=None, until=None, limit=None):
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
        return self._command_execute('getChartRangeRequest', arguments)

    def getChartLastRequest(self, symbol, timeframe=15, since=None):
        since = self._convert_timestamp(since)
        arguments = {
            "info": {
                "period": timeframe,
                "start": int(since),
                "symbol": symbol
            }
        }
        return self._command_execute('getChartLastRequest', arguments)

    def getServerTime(self):
        return self._command_execute('getServerTime')

    def getTrades(self):
        return self._command_execute('getTrades', {"openedOnly": True})

    def getTradeRecords(self, order_id):
        return self._command_execute('getTradeRecords', {"orders": [
            order_id
        ]})

    def getTradesHistory(self, since=None, until=0):
        since = self._convert_timestamp(since)
        return self._command_execute('getTradesHistory', {
            "start": int(since),
            "end": until
        })
