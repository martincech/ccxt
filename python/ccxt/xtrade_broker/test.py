import asyncio
import datetime
import os

from ccxt.xtrade_broker import xtb


async def test():
    xtb_broker = xtb({
        'uid': os.getenv("XTB_USER_ID", ""),
        'password': os.getenv("XTB_USER_PASSWORD", "")
    })
    xtb_broker.check_required_credentials()
    print(xtb_broker.sign_in())
    # print("Sync version")
    # print(xtb_broker.fetch_balance())
    # print(xtb_broker.load_markets())
    # print(xtb_broker.fetch_ohlcv("NATGAS", "15m",
    #                              since=(datetime.datetime.now() - datetime.timedelta(hours=4)).timestamp()))
    # print(xtb_broker.fetchTrades("NATGAS", since=(datetime.datetime.now() - datetime.timedelta(weeks=7)).timestamp()))

    print("Now async:")
    print(await xtb_broker.fetch_balance())
    print(await xtb_broker.load_markets())
    print(await xtb_broker.fetch_ohlcv("NATGAS", "15m",
                                       since=(datetime.datetime.now() - datetime.timedelta(hours=4)).timestamp()))
    print(await xtb_broker.fetchTrades("NATGAS",
                                       since=(datetime.datetime.now() - datetime.timedelta(weeks=7)).timestamp()))


asyncio.run(test())
