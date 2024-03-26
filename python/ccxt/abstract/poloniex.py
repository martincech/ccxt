from ccxt.base.types import Entry


class ImplicitAPI:
    public_get_markets = publicGetMarkets = Entry('markets', 'public', 'GET', {'cost': 20})
    public_get_markets_symbol = publicGetMarketsSymbol = Entry('markets/{symbol}', 'public', 'GET', {'cost': 1})
    public_get_currencies = publicGetCurrencies = Entry('currencies', 'public', 'GET', {'cost': 20})
    public_get_currencies_currency = publicGetCurrenciesCurrency = Entry('currencies/{currency}', 'public', 'GET', {'cost': 20})
    public_get_v2_currencies = publicGetV2Currencies = Entry('v2/currencies', 'public', 'GET', {'cost': 20})
    public_get_v2_currencies_currency = publicGetV2CurrenciesCurrency = Entry('v2/currencies/{currency}', 'public', 'GET', {'cost': 20})
    public_get_timestamp = publicGetTimestamp = Entry('timestamp', 'public', 'GET', {'cost': 1})
    public_get_markets_price = publicGetMarketsPrice = Entry('markets/price', 'public', 'GET', {'cost': 1})
    public_get_markets_symbol_price = publicGetMarketsSymbolPrice = Entry('markets/{symbol}/price', 'public', 'GET', {'cost': 1})
    public_get_markets_markprice = publicGetMarketsMarkPrice = Entry('markets/markPrice', 'public', 'GET', {'cost': 1})
    public_get_markets_symbol_markprice = publicGetMarketsSymbolMarkPrice = Entry('markets/{symbol}/markPrice', 'public', 'GET', {'cost': 1})
    public_get_markets_symbol_markpricecomponents = publicGetMarketsSymbolMarkPriceComponents = Entry('markets/{symbol}/markPriceComponents', 'public', 'GET', {'cost': 1})
    public_get_markets_symbol_orderbook = publicGetMarketsSymbolOrderBook = Entry('markets/{symbol}/orderBook', 'public', 'GET', {'cost': 1})
    public_get_markets_symbol_candles = publicGetMarketsSymbolCandles = Entry('markets/{symbol}/candles', 'public', 'GET', {'cost': 1})
    public_get_markets_symbol_trades = publicGetMarketsSymbolTrades = Entry('markets/{symbol}/trades', 'public', 'GET', {'cost': 20})
    public_get_markets_ticker24h = publicGetMarketsTicker24h = Entry('markets/ticker24h', 'public', 'GET', {'cost': 20})
    public_get_markets_symbol_ticker24h = publicGetMarketsSymbolTicker24h = Entry('markets/{symbol}/ticker24h', 'public', 'GET', {'cost': 20})
    public_get_markets_collateralinfo = publicGetMarketsCollateralInfo = Entry('markets/collateralInfo', 'public', 'GET', {'cost': 1})
    public_get_markets_currency_collateralinfo = publicGetMarketsCurrencyCollateralInfo = Entry('markets/{currency}/collateralInfo', 'public', 'GET', {'cost': 1})
    public_get_markets_borrowratesinfo = publicGetMarketsBorrowRatesInfo = Entry('markets/borrowRatesInfo', 'public', 'GET', {'cost': 1})
    private_get_accounts = privateGetAccounts = Entry('accounts', 'private', 'GET', {'cost': 4})
    private_get_accounts_balances = privateGetAccountsBalances = Entry('accounts/balances', 'private', 'GET', {'cost': 4})
    private_get_accounts_id_balances = privateGetAccountsIdBalances = Entry('accounts/{id}/balances', 'private', 'GET', {'cost': 4})
    private_get_accounts_activity = privateGetAccountsActivity = Entry('accounts/activity', 'private', 'GET', {'cost': 20})
    private_get_accounts_transfer = privateGetAccountsTransfer = Entry('accounts/transfer', 'private', 'GET', {'cost': 20})
    private_get_accounts_transfer_id = privateGetAccountsTransferId = Entry('accounts/transfer/{id}', 'private', 'GET', {'cost': 4})
    private_get_feeinfo = privateGetFeeinfo = Entry('feeinfo', 'private', 'GET', {'cost': 20})
    private_get_accounts_interest_history = privateGetAccountsInterestHistory = Entry('accounts/interest/history', 'private', 'GET', {'cost': 1})
    private_get_subaccounts = privateGetSubaccounts = Entry('subaccounts', 'private', 'GET', {'cost': 4})
    private_get_subaccounts_balances = privateGetSubaccountsBalances = Entry('subaccounts/balances', 'private', 'GET', {'cost': 20})
    private_get_subaccounts_id_balances = privateGetSubaccountsIdBalances = Entry('subaccounts/{id}/balances', 'private', 'GET', {'cost': 4})
    private_get_subaccounts_transfer = privateGetSubaccountsTransfer = Entry('subaccounts/transfer', 'private', 'GET', {'cost': 20})
    private_get_subaccounts_transfer_id = privateGetSubaccountsTransferId = Entry('subaccounts/transfer/{id}', 'private', 'GET', {'cost': 4})
    private_get_wallets_addresses = privateGetWalletsAddresses = Entry('wallets/addresses', 'private', 'GET', {'cost': 20})
    private_get_wallets_addresses_currency = privateGetWalletsAddressesCurrency = Entry('wallets/addresses/{currency}', 'private', 'GET', {'cost': 20})
    private_get_wallets_activity = privateGetWalletsActivity = Entry('wallets/activity', 'private', 'GET', {'cost': 20})
    private_get_margin_accountmargin = privateGetMarginAccountMargin = Entry('margin/accountMargin', 'private', 'GET', {'cost': 4})
    private_get_margin_borrowstatus = privateGetMarginBorrowStatus = Entry('margin/borrowStatus', 'private', 'GET', {'cost': 4})
    private_get_margin_maxsize = privateGetMarginMaxSize = Entry('margin/maxSize', 'private', 'GET', {'cost': 4})
    private_get_orders = privateGetOrders = Entry('orders', 'private', 'GET', {'cost': 20})
    private_get_orders_id = privateGetOrdersId = Entry('orders/{id}', 'private', 'GET', {'cost': 4})
    private_get_orders_killswitchstatus = privateGetOrdersKillSwitchStatus = Entry('orders/killSwitchStatus', 'private', 'GET', {'cost': 4})
    private_get_smartorders = privateGetSmartorders = Entry('smartorders', 'private', 'GET', {'cost': 20})
    private_get_smartorders_id = privateGetSmartordersId = Entry('smartorders/{id}', 'private', 'GET', {'cost': 4})
    private_get_orders_history = privateGetOrdersHistory = Entry('orders/history', 'private', 'GET', {'cost': 20})
    private_get_smartorders_history = privateGetSmartordersHistory = Entry('smartorders/history', 'private', 'GET', {'cost': 20})
    private_get_trades = privateGetTrades = Entry('trades', 'private', 'GET', {'cost': 20})
    private_get_orders_id_trades = privateGetOrdersIdTrades = Entry('orders/{id}/trades', 'private', 'GET', {'cost': 4})
    private_post_accounts_transfer = privatePostAccountsTransfer = Entry('accounts/transfer', 'private', 'POST', {'cost': 4})
    private_post_subaccounts_transfer = privatePostSubaccountsTransfer = Entry('subaccounts/transfer', 'private', 'POST', {'cost': 20})
    private_post_wallets_address = privatePostWalletsAddress = Entry('wallets/address', 'private', 'POST', {'cost': 20})
    private_post_wallets_withdraw = privatePostWalletsWithdraw = Entry('wallets/withdraw', 'private', 'POST', {'cost': 20})
    private_post_v2_wallets_withdraw = privatePostV2WalletsWithdraw = Entry('v2/wallets/withdraw', 'private', 'POST', {'cost': 20})
    private_post_orders = privatePostOrders = Entry('orders', 'private', 'POST', {'cost': 4})
    private_post_orders_batch = privatePostOrdersBatch = Entry('orders/batch', 'private', 'POST', {'cost': 20})
    private_post_orders_killswitch = privatePostOrdersKillSwitch = Entry('orders/killSwitch', 'private', 'POST', {'cost': 4})
    private_post_smartorders = privatePostSmartorders = Entry('smartorders', 'private', 'POST', {'cost': 4})
    private_delete_orders_id = privateDeleteOrdersId = Entry('orders/{id}', 'private', 'DELETE', {'cost': 4})
    private_delete_orders_cancelbyids = privateDeleteOrdersCancelByIds = Entry('orders/cancelByIds', 'private', 'DELETE', {'cost': 20})
    private_delete_orders = privateDeleteOrders = Entry('orders', 'private', 'DELETE', {'cost': 20})
    private_delete_smartorders_id = privateDeleteSmartordersId = Entry('smartorders/{id}', 'private', 'DELETE', {'cost': 4})
    private_delete_smartorders_cancelbyids = privateDeleteSmartordersCancelByIds = Entry('smartorders/cancelByIds', 'private', 'DELETE', {'cost': 20})
    private_delete_smartorders = privateDeleteSmartorders = Entry('smartorders', 'private', 'DELETE', {'cost': 20})
    private_put_orders_id = privatePutOrdersId = Entry('orders/{id}', 'private', 'PUT', {'cost': 20})
    private_put_smartorders_id = privatePutSmartordersId = Entry('smartorders/{id}', 'private', 'PUT', {'cost': 20})
