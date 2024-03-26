namespace ccxt;

// PLEASE DO NOT EDIT THIS FILE, IT IS GENERATED AND WILL BE OVERWRITTEN:
// https://github.com/ccxt/ccxt/blob/master/CONTRIBUTING.md#how-to-contribute-code


public partial class ascendex
{
    /// <summary>
    /// retrieves data on all markets for ascendex
    /// </summary>
    /// <remarks>
    /// <list type="table">
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>object[]</term> an array of objects representing market data.</returns>
    public async Task<List<MarketInterface>> FetchMarkets(Dictionary<string, object> parameters = null)
    {
        var res = await this.fetchMarkets(parameters);
        return ((IList<object>)res).Select(item => new MarketInterface(item)).ToList<MarketInterface>();
    }
    /// <summary>
    /// fetches the current integer timestamp in milliseconds from the ascendex server
    /// </summary>
    /// <remarks>
    /// <list type="table">
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>int</term> the current integer timestamp in milliseconds from the ascendex server.</returns>
    public async Task<Int64> FetchTime(Dictionary<string, object> parameters = null)
    {
        var res = await this.fetchTime(parameters);
        return (Int64)res;
    }
    /// <summary>
    /// fetch all the accounts associated with a profile
    /// </summary>
    /// <remarks>
    /// <list type="table">
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>object</term> a dictionary of [account structures]{@link https://docs.ccxt.com/#/?id=account-structure} indexed by the account type.</returns>
    public async Task<List<Account>> FetchAccounts(Dictionary<string, object> parameters = null)
    {
        var res = await this.fetchAccounts(parameters);
        return ((IList<object>)res).Select(item => new Account(item)).ToList<Account>();
    }
    /// <summary>
    /// query for balance and get the amount of funds available for trading or funds locked in orders
    /// </summary>
    /// <remarks>
    /// See <see href="https://ascendex.github.io/ascendex-pro-api/#cash-account-balance"/>  <br/>
    /// See <see href="https://ascendex.github.io/ascendex-pro-api/#margin-account-balance"/>  <br/>
    /// See <see href="https://ascendex.github.io/ascendex-futures-pro-api-v2/#position"/>  <br/>
    /// <list type="table">
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// <item>
    /// <term>params.type</term>
    /// <description>
    /// string : wallet type, 'spot', 'margin', or 'swap'
    /// </description>
    /// </item>
    /// <item>
    /// <term>params.marginMode</term>
    /// <description>
    /// string : 'cross' or undefined, for spot margin trading, value of 'isolated' is invalid
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>object</term> a [balance structure]{@link https://docs.ccxt.com/#/?id=balance-structure}.</returns>
    public async Task<Balances> FetchBalance(Dictionary<string, object> parameters = null)
    {
        var res = await this.fetchBalance(parameters);
        return new Balances(res);
    }
    /// <summary>
    /// fetches information on open orders with bid (buy) and ask (sell) prices, volumes and other data
    /// </summary>
    /// <remarks>
    /// <list type="table">
    /// <item>
    /// <term>limit</term>
    /// <description>
    /// int : the maximum amount of order book entries to return
    /// </description>
    /// </item>
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>object</term> A dictionary of [order book structures]{@link https://docs.ccxt.com/#/?id=order-book-structure} indexed by market symbols.</returns>
    public async Task<OrderBook> FetchOrderBook(string symbol, Int64? limit2 = 0, Dictionary<string, object> parameters = null)
    {
        var limit = limit2 == 0 ? null : (object)limit2;
        var res = await this.fetchOrderBook(symbol, limit, parameters);
        return new OrderBook(res);
    }
    /// <summary>
    /// fetches a price ticker, a statistical calculation with the information calculated over the past 24 hours for a specific market
    /// </summary>
    /// <remarks>
    /// <list type="table">
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>object</term> a [ticker structure]{@link https://docs.ccxt.com/#/?id=ticker-structure}.</returns>
    public async Task<Ticker> FetchTicker(string symbol, Dictionary<string, object> parameters = null)
    {
        var res = await this.fetchTicker(symbol, parameters);
        return new Ticker(res);
    }
    /// <summary>
    /// fetches price tickers for multiple markets, statistical information calculated over the past 24 hours for each market
    /// </summary>
    /// <remarks>
    /// See <see href="https://ascendex.github.io/ascendex-pro-api/#ticker"/>  <br/>
    /// See <see href="https://ascendex.github.io/ascendex-futures-pro-api-v2/#ticker"/>  <br/>
    /// <list type="table">
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>object</term> a dictionary of [ticker structures]{@link https://docs.ccxt.com/#/?id=ticker-structure}.</returns>
    public async Task<Tickers> FetchTickers(List<String> symbols = null, Dictionary<string, object> parameters = null)
    {
        var res = await this.fetchTickers(symbols, parameters);
        return new Tickers(res);
    }
    /// <summary>
    /// fetches historical candlestick data containing the open, high, low, and close price, and the volume of a market
    /// </summary>
    /// <remarks>
    /// <list type="table">
    /// <item>
    /// <term>since</term>
    /// <description>
    /// int : timestamp in ms of the earliest candle to fetch
    /// </description>
    /// </item>
    /// <item>
    /// <term>limit</term>
    /// <description>
    /// int : the maximum amount of candles to fetch
    /// </description>
    /// </item>
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>int[][]</term> A list of candles ordered as timestamp, open, high, low, close, volume.</returns>
    public async Task<List<OHLCV>> FetchOHLCV(string symbol, string timeframe = "1m", Int64? since2 = 0, Int64? limit2 = 0, Dictionary<string, object> parameters = null)
    {
        var since = since2 == 0 ? null : (object)since2;
        var limit = limit2 == 0 ? null : (object)limit2;
        var res = await this.fetchOHLCV(symbol, timeframe, since, limit, parameters);
        return ((IList<object>)res).Select(item => new OHLCV(item)).ToList<OHLCV>();
    }
    /// <summary>
    /// get the list of most recent trades for a particular symbol
    /// </summary>
    /// <remarks>
    /// See <see href="https://ascendex.github.io/ascendex-pro-api/#market-trades"/>  <br/>
    /// <list type="table">
    /// <item>
    /// <term>since</term>
    /// <description>
    /// int : timestamp in ms of the earliest trade to fetch
    /// </description>
    /// </item>
    /// <item>
    /// <term>limit</term>
    /// <description>
    /// int : the maximum amount of trades to fetch
    /// </description>
    /// </item>
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>Trade[]</term> a list of [trade structures]{@link https://docs.ccxt.com/#/?id=public-trades}.</returns>
    public async Task<List<Trade>> FetchTrades(string symbol, Int64? since2 = 0, Int64? limit2 = 0, Dictionary<string, object> parameters = null)
    {
        var since = since2 == 0 ? null : (object)since2;
        var limit = limit2 == 0 ? null : (object)limit2;
        var res = await this.fetchTrades(symbol, since, limit, parameters);
        return ((IList<object>)res).Select(item => new Trade(item)).ToList<Trade>();
    }
    /// <summary>
    /// fetch the trading fees for multiple markets
    /// </summary>
    /// <remarks>
    /// <list type="table">
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>object</term> a dictionary of [fee structures]{@link https://docs.ccxt.com/#/?id=fee-structure} indexed by market symbols.</returns>
    public async Task<Dictionary<string, object>> FetchTradingFees(Dictionary<string, object> parameters = null)
    {
        var res = await this.fetchTradingFees(parameters);
        return ((Dictionary<string, object>)res);
    }
    /// <summary>
    /// helper function to build request
    /// </summary>
    /// <remarks>
    /// <list type="table">
    /// <item>
    /// <term>price</term>
    /// <description>
    /// float : the price at which the order is to be fullfilled, in units of the quote currency, ignored in market orders
    /// </description>
    /// </item>
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// <item>
    /// <term>params.timeInForce</term>
    /// <description>
    /// string : "GTC", "IOC", "FOK", or "PO"
    /// </description>
    /// </item>
    /// <item>
    /// <term>params.postOnly</term>
    /// <description>
    /// bool : true or false
    /// </description>
    /// </item>
    /// <item>
    /// <term>params.stopPrice</term>
    /// <description>
    /// float : the price at which a trigger order is triggered at
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>object</term> request to be sent to the exchange.</returns>
    public Dictionary<string, object> CreateOrderRequest(string symbol, string type, string side, double amount, double? price2 = 0, Dictionary<string, object> parameters = null)
    {
        var price = price2 == 0 ? null : (object)price2;
        var res = this.createOrderRequest(symbol, type, side, amount, price, parameters);
        return ((Dictionary<string, object>)res);
    }
    /// <summary>
    /// create a trade order on the exchange
    /// </summary>
    /// <remarks>
    /// See <see href="https://ascendex.github.io/ascendex-pro-api/#place-order"/>  <br/>
    /// See <see href="https://ascendex.github.io/ascendex-futures-pro-api-v2/#new-order"/>  <br/>
    /// <list type="table">
    /// <item>
    /// <term>price</term>
    /// <description>
    /// float : *ignored in "market" orders* the price at which the order is to be fullfilled at in units of the quote currency
    /// </description>
    /// </item>
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// <item>
    /// <term>params.timeInForce</term>
    /// <description>
    /// string : "GTC", "IOC", "FOK", or "PO"
    /// </description>
    /// </item>
    /// <item>
    /// <term>params.postOnly</term>
    /// <description>
    /// bool : true or false
    /// </description>
    /// </item>
    /// <item>
    /// <term>params.stopPrice</term>
    /// <description>
    /// float : the price at which a trigger order is triggered at
    /// </description>
    /// </item>
    /// <item>
    /// <term>params.takeProfit</term>
    /// <description>
    /// object : *takeProfit object in params* containing the triggerPrice that the attached take profit order will be triggered (perpetual swap markets only)
    /// </description>
    /// </item>
    /// <item>
    /// <term>params.stopLoss</term>
    /// <description>
    /// object : *stopLoss object in params* containing the triggerPrice that the attached stop loss order will be triggered (perpetual swap markets only)
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>undefined</term> undefined.</returns>
    public async Task<Order> CreateOrder(string symbol, string type, string side, double amount, double? price2 = 0, Dictionary<string, object> parameters = null)
    {
        var price = price2 == 0 ? null : (object)price2;
        var res = await this.createOrder(symbol, type, side, amount, price, parameters);
        return new Order(res);
    }
    /// <summary>
    /// create a list of trade orders
    /// </summary>
    /// <remarks>
    /// See <see href="https://ascendex.github.io/ascendex-pro-api/#place-batch-orders"/>  <br/>
    /// See <see href="https://ascendex.github.io/ascendex-futures-pro-api-v2/#place-batch-orders"/>  <br/>
    /// <list type="table">
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// <item>
    /// <term>params.timeInForce</term>
    /// <description>
    /// string : "GTC", "IOC", "FOK", or "PO"
    /// </description>
    /// </item>
    /// <item>
    /// <term>params.postOnly</term>
    /// <description>
    /// bool : true or false
    /// </description>
    /// </item>
    /// <item>
    /// <term>params.stopPrice</term>
    /// <description>
    /// float : the price at which a trigger order is triggered at
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>object</term> an [order structure]{@link https://docs.ccxt.com/#/?id=order-structure}.</returns>
    public async Task<List<Order>> CreateOrders(List<OrderRequest> orders, Dictionary<string, object> parameters = null)
    {
        var res = await this.createOrders(orders, parameters);
        return ((IList<object>)res).Select(item => new Order(item)).ToList<Order>();
    }
    /// <summary>
    /// fetches information on an order made by the user
    /// </summary>
    /// <remarks>
    /// See <see href="https://ascendex.github.io/ascendex-pro-api/#query-order"/>  <br/>
    /// See <see href="https://ascendex.github.io/ascendex-futures-pro-api-v2/#query-order-by-id"/>  <br/>
    /// <list type="table">
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>object</term> An [order structure]{@link https://docs.ccxt.com/#/?id=order-structure}.</returns>
    public async Task<Order> FetchOrder(string id, string symbol = null, Dictionary<string, object> parameters = null)
    {
        var res = await this.fetchOrder(id, symbol, parameters);
        return new Order(res);
    }
    /// <summary>
    /// fetch all unfilled currently open orders
    /// </summary>
    /// <remarks>
    /// See <see href="https://ascendex.github.io/ascendex-pro-api/#list-open-orders"/>  <br/>
    /// See <see href="https://ascendex.github.io/ascendex-futures-pro-api-v2/#list-open-orders"/>  <br/>
    /// <list type="table">
    /// <item>
    /// <term>since</term>
    /// <description>
    /// int : the earliest time in ms to fetch open orders for
    /// </description>
    /// </item>
    /// <item>
    /// <term>limit</term>
    /// <description>
    /// int : the maximum number of  open orders structures to retrieve
    /// </description>
    /// </item>
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>Order[]</term> a list of [order structures]{@link https://docs.ccxt.com/#/?id=order-structure}.</returns>
    public async Task<List<Order>> FetchOpenOrders(string symbol = null, Int64? since2 = 0, Int64? limit2 = 0, Dictionary<string, object> parameters = null)
    {
        var since = since2 == 0 ? null : (object)since2;
        var limit = limit2 == 0 ? null : (object)limit2;
        var res = await this.fetchOpenOrders(symbol, since, limit, parameters);
        return ((IList<object>)res).Select(item => new Order(item)).ToList<Order>();
    }
    /// <summary>
    /// fetches information on multiple closed orders made by the user
    /// </summary>
    /// <remarks>
    /// See <see href="https://ascendex.github.io/ascendex-pro-api/#list-history-orders-v2"/>  <br/>
    /// See <see href="https://ascendex.github.io/ascendex-futures-pro-api-v2/#list-current-history-orders"/>  <br/>
    /// <list type="table">
    /// <item>
    /// <term>since</term>
    /// <description>
    /// int : the earliest time in ms to fetch orders for
    /// </description>
    /// </item>
    /// <item>
    /// <term>limit</term>
    /// <description>
    /// int : the maximum number of order structures to retrieve
    /// </description>
    /// </item>
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// <item>
    /// <term>params.until</term>
    /// <description>
    /// int : the latest time in ms to fetch orders for
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>Order[]</term> a list of [order structures]{@link https://docs.ccxt.com/#/?id=order-structure}.</returns>
    public async Task<List<Order>> FetchClosedOrders(string symbol = null, Int64? since2 = 0, Int64? limit2 = 0, Dictionary<string, object> parameters = null)
    {
        var since = since2 == 0 ? null : (object)since2;
        var limit = limit2 == 0 ? null : (object)limit2;
        var res = await this.fetchClosedOrders(symbol, since, limit, parameters);
        return ((IList<object>)res).Select(item => new Order(item)).ToList<Order>();
    }
    /// <summary>
    /// cancels an open order
    /// </summary>
    /// <remarks>
    /// See <see href="https://ascendex.github.io/ascendex-pro-api/#cancel-order"/>  <br/>
    /// See <see href="https://ascendex.github.io/ascendex-futures-pro-api-v2/#cancel-order"/>  <br/>
    /// <list type="table">
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>object</term> An [order structure]{@link https://docs.ccxt.com/#/?id=order-structure}.</returns>
    public async Task<Order> CancelOrder(string id, string symbol = null, Dictionary<string, object> parameters = null)
    {
        var res = await this.cancelOrder(id, symbol, parameters);
        return new Order(res);
    }
    /// <summary>
    /// cancel all open orders
    /// </summary>
    /// <remarks>
    /// See <see href="https://ascendex.github.io/ascendex-pro-api/#cancel-all-orders"/>  <br/>
    /// See <see href="https://ascendex.github.io/ascendex-futures-pro-api-v2/#cancel-all-open-orders"/>  <br/>
    /// <list type="table">
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>object[]</term> a list of [order structures]{@link https://docs.ccxt.com/#/?id=order-structure}.</returns>
    public async Task<Dictionary<string, object>> CancelAllOrders(string symbol = null, Dictionary<string, object> parameters = null)
    {
        var res = await this.cancelAllOrders(symbol, parameters);
        return ((Dictionary<string, object>)res);
    }
    /// <summary>
    /// fetch the deposit address for a currency associated with this account
    /// </summary>
    /// <remarks>
    /// See <see href="https://ascendex.github.io/ascendex-pro-api/#query-deposit-addresses"/>  <br/>
    /// <list type="table">
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// <item>
    /// <term>params.network</term>
    /// <description>
    /// string : unified network code for deposit chain
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>object</term> an [address structure]{@link https://docs.ccxt.com/#/?id=address-structure}.</returns>
    public async Task<Dictionary<string, object>> FetchDepositAddress(string code, Dictionary<string, object> parameters = null)
    {
        var res = await this.fetchDepositAddress(code, parameters);
        return ((Dictionary<string, object>)res);
    }
    /// <summary>
    /// fetch all deposits made to an account
    /// </summary>
    /// <remarks>
    /// <list type="table">
    /// <item>
    /// <term>since</term>
    /// <description>
    /// int : the earliest time in ms to fetch deposits for
    /// </description>
    /// </item>
    /// <item>
    /// <term>limit</term>
    /// <description>
    /// int : the maximum number of deposits structures to retrieve
    /// </description>
    /// </item>
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>object[]</term> a list of [transaction structures]{@link https://docs.ccxt.com/#/?id=transaction-structure}.</returns>
    public async Task<List<Transaction>> FetchDeposits(string code = null, Int64? since2 = 0, Int64? limit2 = 0, Dictionary<string, object> parameters = null)
    {
        var since = since2 == 0 ? null : (object)since2;
        var limit = limit2 == 0 ? null : (object)limit2;
        var res = await this.fetchDeposits(code, since, limit, parameters);
        return ((IList<object>)res).Select(item => new Transaction(item)).ToList<Transaction>();
    }
    /// <summary>
    /// fetch all withdrawals made from an account
    /// </summary>
    /// <remarks>
    /// <list type="table">
    /// <item>
    /// <term>since</term>
    /// <description>
    /// int : the earliest time in ms to fetch withdrawals for
    /// </description>
    /// </item>
    /// <item>
    /// <term>limit</term>
    /// <description>
    /// int : the maximum number of withdrawals structures to retrieve
    /// </description>
    /// </item>
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>object[]</term> a list of [transaction structures]{@link https://docs.ccxt.com/#/?id=transaction-structure}.</returns>
    public async Task<List<Transaction>> FetchWithdrawals(string code = null, Int64? since2 = 0, Int64? limit2 = 0, Dictionary<string, object> parameters = null)
    {
        var since = since2 == 0 ? null : (object)since2;
        var limit = limit2 == 0 ? null : (object)limit2;
        var res = await this.fetchWithdrawals(code, since, limit, parameters);
        return ((IList<object>)res).Select(item => new Transaction(item)).ToList<Transaction>();
    }
    /// <summary>
    /// fetch history of deposits and withdrawals
    /// </summary>
    /// <remarks>
    /// <list type="table">
    /// <item>
    /// <term>code</term>
    /// <description>
    /// string : unified currency code for the currency of the deposit/withdrawals, default is undefined
    /// </description>
    /// </item>
    /// <item>
    /// <term>since</term>
    /// <description>
    /// int : timestamp in ms of the earliest deposit/withdrawal, default is undefined
    /// </description>
    /// </item>
    /// <item>
    /// <term>limit</term>
    /// <description>
    /// int : max number of deposit/withdrawals to return, default is undefined
    /// </description>
    /// </item>
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>object</term> a list of [transaction structure]{@link https://docs.ccxt.com/#/?id=transaction-structure}.</returns>
    public async Task<List<Transaction>> FetchDepositsWithdrawals(string code = null, Int64? since2 = 0, Int64? limit2 = 0, Dictionary<string, object> parameters = null)
    {
        var since = since2 == 0 ? null : (object)since2;
        var limit = limit2 == 0 ? null : (object)limit2;
        var res = await this.fetchDepositsWithdrawals(code, since, limit, parameters);
        return ((IList<object>)res).Select(item => new Transaction(item)).ToList<Transaction>();
    }
    /// <summary>
    /// fetch all open positions
    /// </summary>
    /// <remarks>
    /// <list type="table">
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>object[]</term> a list of [position structure]{@link https://docs.ccxt.com/#/?id=position-structure}.</returns>
    public async Task<List<Position>> FetchPositions(List<String> symbols = null, Dictionary<string, object> parameters = null)
    {
        var res = await this.fetchPositions(symbols, parameters);
        return ((IList<object>)res).Select(item => new Position(item)).ToList<Position>();
    }
    /// <summary>
    /// fetch the funding rate for multiple markets
    /// </summary>
    /// <remarks>
    /// <list type="table">
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>object</term> a dictionary of [funding rates structures]{@link https://docs.ccxt.com/#/?id=funding-rates-structure}, indexe by market symbols.</returns>
    public async Task<Dictionary<string, object>> FetchFundingRates(List<String> symbols = null, Dictionary<string, object> parameters = null)
    {
        var res = await this.fetchFundingRates(symbols, parameters);
        return ((Dictionary<string, object>)res);
    }
    /// <summary>
    /// set the level of leverage for a market
    /// </summary>
    /// <remarks>
    /// See <see href="https://ascendex.github.io/ascendex-futures-pro-api-v2/#change-contract-leverage"/>  <br/>
    /// <list type="table">
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>object</term> response from the exchange.</returns>
    public async Task<Dictionary<string, object>> SetLeverage(Int64 leverage, string symbol = null, Dictionary<string, object> parameters = null)
    {
        var res = await this.setLeverage(leverage, symbol, parameters);
        return ((Dictionary<string, object>)res);
    }
    /// <summary>
    /// set margin mode to 'cross' or 'isolated'
    /// </summary>
    /// <remarks>
    /// See <see href="https://ascendex.github.io/ascendex-futures-pro-api-v2/#change-margin-type"/>  <br/>
    /// <list type="table">
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>object</term> response from the exchange.</returns>
    public async Task<Dictionary<string, object>> SetMarginMode(string marginMode, string symbol = null, Dictionary<string, object> parameters = null)
    {
        var res = await this.setMarginMode(marginMode, symbol, parameters);
        return ((Dictionary<string, object>)res);
    }
    /// <summary>
    /// retrieve information on the maximum leverage, and maintenance margin for trades of varying trade sizes
    /// </summary>
    /// <remarks>
    /// <list type="table">
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>object</term> a dictionary of [leverage tiers structures]{@link https://docs.ccxt.com/#/?id=leverage-tiers-structure}, indexed by market symbols.</returns>
    public async Task<Dictionary<string, object>> FetchLeverageTiers(List<String> symbols = null, Dictionary<string, object> parameters = null)
    {
        var res = await this.fetchLeverageTiers(symbols, parameters);
        return ((Dictionary<string, object>)res);
    }
    /// <summary>
    /// fetch deposit and withdraw fees
    /// </summary>
    /// <remarks>
    /// See <see href="https://ascendex.github.io/ascendex-pro-api/#list-all-assets"/>  <br/>
    /// <list type="table">
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>object</term> a list of [fee structures]{@link https://docs.ccxt.com/#/?id=fee-structure}.</returns>
    public async Task<Dictionary<string, object>> FetchDepositWithdrawFees(List<String> codes = null, Dictionary<string, object> parameters = null)
    {
        var res = await this.fetchDepositWithdrawFees(codes, parameters);
        return ((Dictionary<string, object>)res);
    }
    /// <summary>
    /// transfer currency internally between wallets on the same account
    /// </summary>
    /// <remarks>
    /// <list type="table">
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>object</term> a [transfer structure]{@link https://docs.ccxt.com/#/?id=transfer-structure}.</returns>
    public async Task<TransferEntry> Transfer(string code, double amount, string fromAccount, string toAccount, Dictionary<string, object> parameters = null)
    {
        var res = await this.transfer(code, amount, fromAccount, toAccount, parameters);
        return new TransferEntry(res);
    }
    /// <summary>
    /// fetch the history of funding payments paid and received on this account
    /// </summary>
    /// <remarks>
    /// See <see href="https://ascendex.github.io/ascendex-futures-pro-api-v2/#funding-payment-history"/>  <br/>
    /// <list type="table">
    /// <item>
    /// <term>symbol</term>
    /// <description>
    /// string : unified market symbol
    /// </description>
    /// </item>
    /// <item>
    /// <term>since</term>
    /// <description>
    /// int : the earliest time in ms to fetch funding history for
    /// </description>
    /// </item>
    /// <item>
    /// <term>limit</term>
    /// <description>
    /// int : the maximum number of funding history structures to retrieve
    /// </description>
    /// </item>
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// <item>
    /// <term>params.paginate</term>
    /// <description>
    /// boolean : default false, when true will automatically paginate by calling this endpoint multiple times. See in the docs all the [available parameters](https://github.com/ccxt/ccxt/wiki/Manual#pagination-params)
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>object</term> a [funding history structure]{@link https://docs.ccxt.com/#/?id=funding-history-structure}.</returns>
    public async Task<List<FundingHistory>> FetchFundingHistory(string symbol = null, Int64? since2 = 0, Int64? limit2 = 0, Dictionary<string, object> parameters = null)
    {
        var since = since2 == 0 ? null : (object)since2;
        var limit = limit2 == 0 ? null : (object)limit2;
        var res = await this.fetchFundingHistory(symbol, since, limit, parameters);
        return ((IList<object>)res).Select(item => new FundingHistory(item)).ToList<FundingHistory>();
    }
    public async Task<MarginModes> FetchMarginModes(List<string> symbols = null, Dictionary<string, object> parameters = null)
    {
        var res = await this.fetchMarginModes(symbols, parameters);
        return new MarginModes(res);
    }
    /// <summary>
    /// fetch the set leverage for all contract markets
    /// </summary>
    /// <remarks>
    /// See <see href="https://ascendex.github.io/ascendex-futures-pro-api-v2/#position"/>  <br/>
    /// <list type="table">
    /// <item>
    /// <term>params</term>
    /// <description>
    /// object : extra parameters specific to the exchange API endpoint
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <returns> <term>object</term> a list of [leverage structures]{@link https://docs.ccxt.com/#/?id=leverage-structure}.</returns>
    public async Task<Leverages> FetchLeverages(List<string> symbols = null, Dictionary<string, object> parameters = null)
    {
        var res = await this.fetchLeverages(symbols, parameters);
        return new Leverages(res);
    }
}
