import asyncio
import datetime
import os

from ccxt.async_support.xtrade_broker.xtb import xtb as a_xtb
from ccxt.xtb import xtb as s_xtb


async def test():
    since_hours_ms = int((datetime.datetime.now() - datetime.timedelta(hours=4)).timestamp() * 1000)
    since_weeks_ms = int((datetime.datetime.now() - datetime.timedelta(weeks=7)).timestamp() * 1000)
    print(f"{'='*20}\nAsync version\n{'='*20}\n")
    async_xtb = a_xtb({
        'uid': os.getenv("XTB_USER_ID", ""),
        'password': os.getenv("XTB_USER_PASSWORD", "")
    })
    async_xtb.check_required_credentials()
    print(f"Login: {async_xtb.sign_in()}")
    print(await async_xtb.fetch_balance())
    await async_xtb.load_markets()
    print(await async_xtb.fetch_ohlcv("NATGAS", "1h", since=since_hours_ms))
    print(await async_xtb.fetch_trades("NATGAS", since=since_weeks_ms))

    print(f"{'='*20}\nSync version\n{'='*20}\n")
    sync_xtb = s_xtb({
        'uid': os.getenv("XTB_USER_ID", ""),
        'password': os.getenv("XTB_USER_PASSWORD", "")
    })
    sync_xtb.check_required_credentials()
    print(f"Login: {sync_xtb.sign_in()}")
    print(sync_xtb.fetch_balance())
    print(sync_xtb.load_markets())
    print(sync_xtb.fetch_ohlcv("NATGAS", "1h", since=since_hours_ms))
    print(sync_xtb.fetch_trades("NATGAS", since=since_weeks_ms))


asyncio.run(test())
