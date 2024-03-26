import functools
from typing import Optional, List

from ccxt import Exchange
from ccxt.async_support.xtrade_broker.xtb import xtb as a_xtb


def force_sync(fn):
    """
    turn an async function to sync function
    """
    import asyncio

    @functools.wraps(fn)
    def wrapper(*args, **kwargs):
        res = fn(*args, **kwargs)
        if asyncio.iscoroutine(res):
            loop = asyncio.get_event_loop()
            if loop.is_running():
                future = asyncio.run_coroutine_threadsafe(res, loop)
            else:
                future = asyncio.ensure_future(res)
                loop.run_until_complete(future)
            return future.result()
        return res

    return wrapper


class xtb(a_xtb):
    @force_sync
    def fetch_balance(self, params=None):
        return super().fetch_balance(params)

    @force_sync
    def fetch_markets(self, params=None):
        return super().fetch_markets(params)

    @force_sync
    def fetch_time(self, params=None):
        return super().fetch_time(params)

    @force_sync
    def fetch_trades(self, symbol, since=None, limit=None, params=None):
        return super().fetch_trades(symbol, since, limit, params)

    @force_sync
    def fetch_orders(self, symbol=None, since=None, limit=None, params=None):
        return super().fetch_orders(symbol, since, limit, params)

    @force_sync
    def fetch_order(self, id, symbol=None, params=None):
        return super().fetch_order(id, symbol, params)

    @force_sync
    def fetch_ohlcv(self, symbol, timeframe='1m', since=None, limit=None, params=None):
        return super().fetch_ohlcv(symbol, timeframe, since, limit, params)

    @force_sync
    def load_markets(self, reload=False, params=None):
        return Exchange.load_markets(self, reload, params)

    @force_sync
    def fetch_market_leverage_tiers(self, symbol: str, params={}):
        return super().fetch_market_leverage_tiers(symbol, params)

    @force_sync
    def fetch_funding_rate(self, symbol: str, params={}):
        return super().fetch_funding_rate(symbol, params)

    @force_sync
    def fetch_funding_rate_history(self, symbol: Optional[str] = None, since: Optional[int] = None,
                                         limit: Optional[int] = None, params={}):
        return super().fetch_funding_rate_history(symbol, since, limit, params)

    @force_sync
    def fetch_position(self, symbol: str, params={}):
        return super().fetch_position(symbol, params)

    @force_sync
    def fetch_positions(self, symbols: Optional[List[str]] = None, params={}):
        return super().fetch_positions(symbols, params)
