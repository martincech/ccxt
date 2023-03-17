import os
from datetime import datetime

from ccxt.xtrade_broker.apiclient import APIClient
from ccxt.xtrade_broker.xtb_constants import order_type, order_side, taker_maker

from ccxt.async_support.base.exchange import Exchange


class xtb(Exchange):
    _client = None

    def __init__(self, config={}):
        super().__init__(config)
        if os.getenv("XTB_USER_ID"):
            self.uid = os.getenv("XTB_USER_ID")
        if os.getenv("XTB_USER_PASSWORD"):
            self.password = os.getenv("XTB_USER_PASSWORD")

        self._is_logged = False

    def describe(self):
        return self.deep_extend(super(xtb, self).describe(), {
            'id': 'xtb',
            'name': 'XTB',
            'countries': ['CZ'],
            'version': 'v1',
            'has': {
                'publicAPI': False,
                'privateAPI': False,
                'spot': True,
                'margin': True,
                'swap': True,
                'future': True,
                'signIn': True,
                'option': None,

                'fetchBalance': True,
                'fetchMarkets': True,
                'fetchOHLCV': True,
                'fetchOrder': True,
                'fetchOrders': True,
                'fetchClosedOrder': True,
                'fetchTrades': True,
                'fetchTime': True,
                'cancelOrder': True,
                'cancelOrders': True,
                'createOrder': True,

            },
            'timeframes': {
                '1m': 1,
                '5m': 5,
                '15m': 15,
                '30m': 30,
                '1h': 60,
                '4h': 240,
                '1d': 1440,
                '1w': 10080,
                '1M': 43200,
            },
            'hostname': 'xtb.com',
            'urls': {
                'api': 'xapi.xtb.com:5124',
                'test': 'xapi.xtb.com:5112',
                'www': 'https://www.xtb.com/',
                'doc': 'http://developers.xstore.pro/api'
            },
            'requiredCredentials': {
                'apiKey': False,
                'secret': False,
                'login': False,
                'uid': True,
                'password': True,
            },

        })

    def sign_in(self):
        if not self._is_logged:
            if self._client is None:
                self._client = APIClient(self.urls['api'])
            ret = self._client.loginCommand(self.uid, self.password)
            self._is_logged = ret['status']
        return self._is_logged

    def _fetch_balance_impl(self, params={}):
        self.sign_in()
        resp = self._client.getMarginLevelCommand()
        if not resp:
            return {}
        free = resp['margin_free']
        used = resp['margin']
        total = used + free,
        return {
            'info': resp,
            'timestamp': datetime.now().timestamp() * 1000,
            'datetime': datetime.now().timestamp(),
            resp['currency']: {
                'free': free,
                'used': used,
                'total': total
            }
        }

    def fetch_balance(self, params={}):
        return self._fetch_balance_impl(params)

    async def fetch_balance(self, params={}):
        return self._fetch_balance_impl(params)

    def fetch_markets(self, params={}):
        return self._fetch_markets_impl(params)

    def _fetch_markets_impl(self, params={}):
        self.sign_in()
        symbols = self._client.getAllSymbols()
        return [
            self._parse_market_info(symbol) for symbol in symbols
        ]

    async def fetch_markets(self, params={}):
        return self._fetch_markets_impl(params)

    def fetch_time(self, params={}):
        return self._client.getServerTime()['time']

    def fetchTrades(self, symbol, since=None, limit=None, params={}):
        return self._fetchTrades_impl(symbol, since, limit, params)

    def _fetchTrades_impl(self, symbol, since=None, limit=None, params={}):
        trades = self._client.getTrades()
        return self.parse_trades(trades, self.market(symbol), since, limit, params)

    async def fetchTrades(self, symbol, since=None, limit=None, params={}):
        return self._fetchTrades_impl(symbol, since, limit, params)

    def fetch_orders(self, symbol=None, since=None, limit=None, params={}):
        return self._fetch_orders_impl(symbol, since, limit, params)

    def _fetch_orders_impl(self, symbol=None, since=None, limit=None, params={}):
        return self.fetchTrades(symbol, since, limit, params)

    async def fetch_orders(self, symbol=None, since=None, limit=None, params={}):
        return self._fetch_orders_impl(symbol, since, limit, params)

    def fetch_order(self, id, symbol=None, params={}):
        return self._fetch_order_impl(id, symbol, params)

    def _fetch_order_impl(self, id, symbol=None, params={}):
        trades = self._client.getTradeRecords(order_id=id)
        return self.parse_trades(trades, self.market(symbol), since=None, limit=None, params=params)

    async def fetch_order(self, id, symbol=None, params={}):
        return self._fetch_order_impl(id, symbol, params)

    def fetch_ohlcv(self, symbol, timeframe='1m', since=None, limit=None, params={}):
        return self._fetch_ohlcv_impl(symbol, timeframe, since, limit, params)

    def _fetch_ohlcv_impl(self, symbol, timeframe='1m', since=None, limit=None, params={}):
        ret = self._client.getChartLastRequest(symbol, self.timeframes[timeframe], since)
        candles = ret['rateInfos'] if limit is None else ret['rateInfos'][0:limit]
        return [self._parse_ohlcv_data(candle, ret['digits']) for candle in candles]

    async def fetch_ohlcv(self, symbol, timeframe='1m', since=None, limit=None, params={}):
        return self._fetch_ohlcv_impl(symbol, timeframe, since, limit, params)

    def _parse_market_info(self, market: dict):
        return {
            'info': market,
            'id': self.safe_string(market, 'symbol'),
            'symbol': self.safe_string(market, 'symbol'),
            'base': self.safe_string(market, 'currency'),
            'quote': self.safe_string(market, 'currencyProfit'),
            'type': 'spot',
            'spot': True,
            'margin': False,
            'swap': False,
            'future': False,
            'option': False,
            'active': True,
            'contract': False,
            'settle': None,
            'contractSize': None,
            'linear': True,
            'inverse': False,
            'expiry': None,
            'expiryDatetime': None,
            'strike': None,
            'optionType': None,
            'taker': 0,
            'maker': 0,
            'percentage': True,
            'tierBased': False,
            'feeSide': 'get',
            'precision': {
                'amount': self.safe_integer(market, 'precision'),
                'price': self.safe_integer(market, 'precision'),
                'cost': self.safe_integer(market, 'precision'),
            },
            'limits': {
                'leverage': {
                    'min': self.safe_float(market, 'leverage'),
                    'max': self.safe_float(market, 'leverage'),
                },
                'amount': {
                    'min': self.safe_float(market, 'lotMin'),
                    'max': self.safe_float(market, 'lotMax'),
                },
                'price': {
                    'min': self.safe_float(market, 'lotMin'),
                    'max': None,
                },
                'cost': {
                    'min': self.safe_float(market, 'minCost'),
                    'max': None,
                },
            },
        }

    def _parse_ohlcv_data(self, candle, digits):
        opn, high, low, close = [candle[what] for what in ['open', 'high', 'low', 'close']]
        high, low, close = [item + opn for item in [high, low, close]]
        opn, high, low, close = [item / (10 ^ digits) for item in [opn, high, low, close]]

        return [
            candle['ctm'],
            opn,
            high,
            low,
            close,
            candle['vol'],
        ]

    def parse_trade(self, trade, market=None):
        order_id = self.safe_string(trade, 'order')
        trade_id = self.safe_string(trade, 'position')
        timestamp = self.safe_integer(trade, 'open_time')
        price = self.safe_float(trade, 'open_price')
        amount = self.safe_string(trade, 'volume')
        symbol = trade['symbol']
        return self.safe_trade({
            'info': trade,
            'id': trade_id,
            'order': order_id,
            'timestamp': timestamp,
            'datetime': self.iso8601(timestamp),
            'symbol': symbol,
            'type': order_type(self.safe_integer(trade, 'cmd')),
            'side': order_side(self.safe_integer(trade, 'cmd')),
            'takerOrMaker': taker_maker(self.safe_integer(trade, 'cmd')),
            'price': self.price_to_precision(symbol, price),
            'amount': self.amount_to_precision(symbol, amount),
            'cost': None,
            'fee': None,
        }, market)
