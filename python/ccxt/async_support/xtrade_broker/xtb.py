import asyncio
import functools
import logging
import os
from datetime import datetime
from typing import Optional, List

from ccxt import NotSupported, DECIMAL_PLACES
from ccxt.async_support import Exchange
from ccxt.async_support.xtrade_broker.apiclient import APIClient
from ccxt.async_support.xtrade_broker.xtb_constants import order_type, order_side, taker_maker, OrderType
from ccxt.base.types import OrderSide

logger = logging.getLogger(__name__)
API_MAX_CONNECTIONS = 45


def signed(fn):
    @functools.wraps(fn)
    async def wrapper(self, *args, **kwargs):
        client, id = await self.queue.get()
        while True:
            try:
                logger.debug("Using api connection %d" % id)
                if not await self.sign_in(client):
                    raise Exception('Login failed')
                kwargs['api_client'] = client
                res = await fn(self, *args, **kwargs)
                return res
            except BrokenPipeError:
                logger.error("Broken pipe error, reconnecting")
                client = APIClient(self.urls['api'])
                continue
            finally:
                await self.queue.put((client, id))

    return wrapper


# noinspection PyDefaultArgument
class xtb(Exchange):
    _client = None

    def __init__(self, config={}):
        super().__init__(config)
        if os.getenv("XTB_USER_ID"):
            self.uid = os.getenv("XTB_USER_ID")
        if os.getenv("XTB_USER_PASSWORD"):
            self.password = os.getenv("XTB_USER_PASSWORD")

        self.queue = asyncio.LifoQueue()
        for i in range(API_MAX_CONNECTIONS):
            self.queue.put_nowait(
                (APIClient(self.urls['api']), i)
            )

    def __del__(self):
        # Disconnect all APIClient instances in the queue when the object is destructed
        try:
            while True:
                client, _ = self.queue.get_nowait()
                client.disconnect()
        except asyncio.QueueEmpty:
            pass
        super().__del__()

    def describe(self):
        return {
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
                'fetchOrderBook': True,
                'fetchBidsAsks': True,
                'fetchTickers': True,

                'fetchFundingRate': 'emulated',
                'fetchFundingRateHistory': 'emulated',
                'fetchMarketLeverageTiers': 'emulated',
                'fetchMarkOHLCV': True,

                'fetchTrades': True,
                'fetchPosition': True,
                'fetchPositions': True,
                'fetchTime': True,

                'cancelOrder': True,
                'createOrder': True,
                'createLimitOrder': True,
                'createMarketOrder': True,
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
            'timeout': 10000,
            'rateLimit': 200,
            'hostname': 'xtb.com',
            'precisionMode': DECIMAL_PLACES,
            'urls': {
                'api': 'xapi.xtb.com:5124',
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

        }

    async def sign_in(self, client: APIClient):
        return await client.loginCommand(self.uid, self.password)

    async def fetch_balance(self, params=None):
        return await self._fetch_balance_impl(params)

    async def fetch_markets(self, params=None):
        return await self._fetch_markets_impl(params)

    async def fetch_ohlcv(self, symbol, timeframe='1m', since=None, limit=None, params=None):
        return await self._fetch_ohlcv_impl(symbol, timeframe, since, limit, params)

    async def fetch_order(self, id, symbol=None, params=None):
        return await self._fetch_order_impl(id, symbol, params)

    async def fetch_orders(self, symbol=None, since=None, limit=None, params=None):
        return await self._fetch_orders_impl(symbol, since, limit, params)

    async def fetch_closed_orders(self, symbol: Optional[str] = None, since: Optional[int] = None,
                                  limit: Optional[int] = None, params=None):
        raise await self._fetch_trades_history_impl(symbol, since, limit, params)

    async def fetch_order_book(self, symbol: str, limit: Optional[int] = None, params=None):
        raise NotSupported(self.id + ' fetchOrderBook() is not supported yet')

    async def fetch_bids_asks(self, symbols: Optional[List[str]] = None, params=None):
        raise NotSupported(self.id + ' fetchBidsAsks() is not supported yet')

    async def fetch_funding_rate(self, symbol: str, params={}):
        raise NotSupported(self.id + ' fetchFundingRate() is not supported yet')

    async def fetch_funding_rate_history(self, symbol: Optional[str] = None, since: Optional[int] = None,
                                         limit: Optional[int] = None, params={}):
        raise NotSupported(self.id + ' fetchFundingRateHistory() is not supported yet')

    async def fetch_market_leverage_tiers(self, symbol: str, params={}):
        await self.load_markets()
        market = self.market(symbol)
        return [{
            "tier": 1,
            "notionalCurrency": market['quote'],
            "minNotional": market['limits']['cost']['min'] * market['contractSize']/market['limits']['leverage']['max'],
            "maxNotional": market['limits']['cost']['max'] * market['contractSize']/market['limits']['leverage']['max'],
            "maintenanceMarginRate": 0,
            "maxLeverage": market['limits']['leverage']['max'],
            "info": {}
        }]

    async def fetch_position(self, symbol: str, params={}):
        return self._fetch_positions_impl([symbol], params)

    async def fetch_positions(self, symbols: Optional[List[str]] = None, params={}):
        return await self._fetch_positions_impl(symbols, params)

    async def fetch_mark_ohlcv(self, symbol, timeframe='1m', since: Optional[int] = None, limit: Optional[int] = None,
                               params={}):
        return self.fetch_ohlcv(symbol, timeframe, since, limit, params)

    async def fetch_trades(self, symbol, since=None, limit=None, params=None):
        return await self._fetch_orders_impl(symbol, since, limit, params)

    async def fetch_tickers(self, symbols: Optional[List[str]] = None, params={}):
        raise NotSupported(self.id + ' fetchTickers() is not supported yet')

    async def fetch_time(self, params=None):
        return await self._fetch_time_impl(params)

    async def cancel_order(self, id: str, symbol: Optional[str] = None, params=None):
        raise NotSupported(self.id + ' cancelOrder() is not supported yet')

    async def create_order(self, symbol: str, type: OrderType, side: OrderSide, amount, price=None, params=None):
        raise NotSupported(self.id + ' createOrder() is not supported yet')

    @signed
    async def _fetch_positions_impl(self, symbols: Optional[List[str]] = None, params={}, **kwargs):
        client = kwargs.get('api_client')
        trades = await client.getTrades()
        if symbols:
            trades = [trade for trade in trades if trade['symbol'] in symbols]
        return self.parse_positions(trades, symbols, params)

    @signed
    async def _fetch_balance_impl(self, params=None, **kwargs):
        client = kwargs.get('api_client')
        resp = await client.getMarginLevelCommand()
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

    @signed
    async def _fetch_markets_impl(self, params=None, **kwargs):
        client = kwargs.get('api_client')
        symbols = [await client.getSymbol(s) for s in ["EURUSD", "NATGAS", "US500"]]
        # symbols = await client.getAllSymbols()
        return [
            self._parse_market_info(symbol) for symbol in symbols
            if symbol['categoryName'] not in ["ETF", "STC"]
        ]

    @signed
    async def _fetch_trades_history_impl(self, symbol, since=None, limit=None, params=None, **kwargs):
        client = kwargs.get('api_client')
        trades = await client.getTradesHistory(since=since)
        return self.parse_trades(trades, self.market(symbol), since, limit, params)

    @signed
    async def _fetch_orders_impl(self, symbol=None, since=None, limit=None, params=None, **kwargs):
        client = kwargs.get('api_client')
        if since is None:
            trades = await client.getTrades()
        else:
            trades = await client.getTradesHistory(since)
        return self.parse_orders(trades, self.market(symbol), params)

    @signed
    async def _fetch_order_impl(self, id, symbol=None, params=None, **kwargs):
        client = kwargs.get('api_client')
        trades = await client.getTradeRecords(order_id=id)
        return self.parse_orders(trades, self.market(symbol), params)

    @signed
    async def _fetch_ohlcv_impl(self, symbol, timeframe='1m', since=None, limit=None, params=None, **kwargs):
        client = kwargs.get('api_client')
        ret = await client.getChartRangeRequest(symbol, self.timeframes[timeframe], since, limit=limit)
        candles = ret['rateInfos']
        return [self._parse_ohlcv_data(candle, ret['digits']) for candle in candles]

    @signed
    async def _fetch_time_impl(self, params=None, **kwargs):
        client = kwargs.get('api_client')
        return (await client.getServerTime())['time']

    @staticmethod
    def _calculate_precision(num):
        str_num = str(num)
        if '.' in str_num:
            return len(str_num.split('.')[1])
        else:
            return 0

    def _parse_market_info(self, market: dict):
        expiration_ts = self.safe_string(market, 'expiration')
        margin = self.safe_integer(market, 'marginMode', 104) in [101, 102, 103]
        # swap = bool(self.safe_float(market, 'swapLong', 0) or self.safe_float(market, 'swapShort', 0))
        swap = False
        spot = False
        future = "futures" in self.safe_string(market, 'description')
        if future:
            typ = 'future'
        # elif swap:
        #     typ = 'swap'
        else:
            typ = 'spot'
            spot = True

        contract_size = self.safe_float(market, 'contractSize')
        leverage = 100 / self.safe_float(market, 'leverage') if not spot else None
        amount_min = self.safe_float(market, 'lotMin')
        amount_max = self.safe_float(market, 'lotMax')
        price_min = self.safe_float(market, 'bid')
        price_max = self.safe_float(market, 'ask')
        return {
            'info': market,
            'id': self.safe_string(market, 'symbol'),
            'symbol': self.safe_string(market, 'symbol'),
            'base': self.safe_string(market, 'currency'),
            'quote': self.safe_string(market, 'currencyProfit'),
            'type': typ,
            'spot': spot,
            'margin': margin,
            'swap': swap,
            'future': future,
            'option': False,
            'active': True,
            'contract': future or swap,
            'settle': self.safe_string(market, 'currencyProfit'),
            'contractSize': contract_size,
            'linear': True,
            'inverse': False,
            'expiry': expiration_ts,
            'expiryDatetime': self.iso8601(expiration_ts),
            'strike': None,
            'optionType': None,
            'taker': 0,
            'maker': 0,
            'percentage': True,
            'tierBased': False,
            'feeSide': 'get',
            'precision': {
                'amount': self._calculate_precision(self.safe_float(market, 'lotStep', 0)),
                'price': self.safe_integer(market, 'precision'),
                'cost': None,
            },
            'limits': {
                'leverage': {
                    'min': leverage,
                    'max': leverage,
                },
                'amount': {
                    'min': amount_min,
                    'max': amount_max,
                },
                'price': {
                    'min': price_min,
                    'max': price_max,
                },
                'cost': {
                    'min': price_min * amount_min,
                    'max': price_max * amount_max,
                },
            },
        }

    @staticmethod
    def _parse_ohlcv_data(candle, digits):
        opn, high, low, close = [candle[what] for what in ['open', 'high', 'low', 'close']]
        high, low, close = [item + opn for item in [high, low, close]]
        opn, high, low, close = [item / (10 ** digits) for item in [opn, high, low, close]]

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
        order2_id = self.safe_string(trade, 'order2')
        trade_id = self.safe_string(trade, 'position')
        timestamp = self.safe_integer(trade, 'open_time')
        symbol = trade['symbol']
        price = float(self.price_to_precision(symbol, self.safe_float(trade, 'open_price')))
        amount = float(self.amount_to_precision(symbol, self.safe_string(trade, 'volume')))
        isopen = order_id == trade_id and order_id != order2_id
        isclosed = order_id != order2_id and order2_id != trade_id and order_id != trade_id
        iswaiting = order_id == order2_id and order2_id == trade_id
        if iswaiting:
            status = 'open'
        else:
            status = 'closed'

        return self.safe_trade({
            'info': trade,
            'id': trade_id,
            'clientOrderId': None,
            'timestamp': timestamp,
            'lastTradeTimestamp': timestamp,
            'datetime': self.iso8601(timestamp),
            'timeInForce': 'FOK',
            'symbol': symbol,
            'status': status,
            'order': order_id,
            'type': order_type(self.safe_integer(trade, 'cmd')),
            'side': order_side(self.safe_integer(trade, 'cmd')),
            'takerOrMaker': taker_maker(self.safe_integer(trade, 'cmd')),
            'price': price,
            'average': price,
            'amount': amount,
            'filled': amount,
            'remaining': 0.0,
            'cost': price * amount,
            'fee': {
                'cost': self.safe_float(trade, 'commission'),
                'currency': self.market(symbol)['base'],
                'rate': 0.0
            },
            'fees': None
        }, market)

    def parse_position(self, position, market=None):
        trade_id = self.safe_string(position, 'position')
        timestamp = self.safe_integer(position, 'open_time')
        symbol = position['symbol']
        price = self.price_to_precision(symbol, self.safe_float(position, 'open_price'))
        amount = self.amount_to_precision(symbol, self.safe_string(position, 'volume'))
        unrealizedPnl = None    # float, the difference between the market price and the entry price times the number of contracts, can be negative
        initialMargin = None    # float, the amount of collateral that is locked up in this position
        liquidationPrice = None # float, the price at which collateral becomes less than maintenanceMargin
        notional = None         # float, the value of the position in the settlement currency
        collateral = None  # float, the maximum amount of collateral that can be lost, affected by pnl
        return {
           'info': position,
           'id': trade_id,
           'symbol': symbol,
           'timestamp': timestamp,
           'datetime': self.iso8601(timestamp),
           'isolated': True,
           'hedged': False,
           'side': order_side(self.safe_integer(position, 'cmd')),
           'contracts': amount,
           'contractSize': self.market(symbol)['contractSize'],
           'entryPrice': price,
           'markPrice': price,
           'notional': notional,
           'leverage': self.market(symbol)['limits']['leverage']['max'],
           'collateral': collateral,
           'initialMargin': initialMargin,
           'maintenanceMargin': initialMargin,
           'initialMarginPercentage': None,
           'maintenanceMarginPercentage': None,
           'unrealizedPnl': unrealizedPnl,
           'liquidationPrice': liquidationPrice,
           'marginMode': 'isolated',
           'percentage': None #unrealizedPnl / initialMargin * 100
        }

    def parse_order(self, order, market=None):
        trade = self.parse_trade(order, market)
        trade['trades'] = [trade]
        return trade





