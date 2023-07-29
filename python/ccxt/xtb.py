import functools
from typing import Optional

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
        return self._fetch_balance_impl(params)

    @force_sync
    def fetch_markets(self, params=None):
        return self._fetch_markets_impl(params)

    @force_sync
    def fetch_time(self, params=None):
        return self._fetch_time_impl(params)

    @force_sync
    def fetch_trades(self, symbol, since=None, limit=None, params=None):
        return self._fetch_trades_impl(symbol, since, limit, params)

    @force_sync
    def fetch_my_trades(self, symbol, since=None, limit=None, params=None):
        return self._fetch_trades_history_impl(symbol, since, limit, params)

    @force_sync
    def fetch_orders(self, symbol=None, since=None, limit=None, params=None):
        return self._fetch_orders_impl(symbol, since, limit, params)

    @force_sync
    def fetch_order(self, id, symbol=None, params=None):
        return self._fetch_order_impl(id, symbol, params)

    @force_sync
    def fetch_ohlcv(self, symbol, timeframe='1m', since=None, limit=None, params=None):
        return self._fetch_ohlcv_impl(symbol, timeframe, since, limit, params)

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
        return super()._fetch_funding_rate_history(symbol, since, limit, params)
