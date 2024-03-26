namespace ccxt.pro;

// PLEASE DO NOT EDIT THIS FILE, IT IS GENERATED AND WILL BE OVERWRITTEN:
// https://github.com/ccxt/ccxt/blob/master/CONTRIBUTING.md#how-to-contribute-code


public partial class coincheck { public coincheck(object args = null) : base(args) { } }
public partial class coincheck : ccxt.coincheck
{
    public override object describe()
    {
        return this.deepExtend(base.describe(), new Dictionary<string, object>() {
            { "has", new Dictionary<string, object>() {
                { "ws", true },
                { "watchOrderBook", true },
                { "watchOrders", false },
                { "watchTrades", true },
                { "watchOHLCV", false },
                { "watchTicker", false },
                { "watchTickers", false },
            } },
            { "urls", new Dictionary<string, object>() {
                { "api", new Dictionary<string, object>() {
                    { "ws", "wss://ws-api.coincheck.com/" },
                } },
            } },
            { "options", new Dictionary<string, object>() {
                { "expiresIn", "" },
                { "userId", "" },
                { "wsSessionToken", "" },
                { "watchOrderBook", new Dictionary<string, object>() {
                    { "snapshotDelay", 6 },
                    { "snapshotMaxRetries", 3 },
                } },
                { "tradesLimit", 1000 },
                { "OHLCVLimit", 1000 },
            } },
            { "exceptions", new Dictionary<string, object>() {
                { "exact", new Dictionary<string, object>() {
                    { "4009", typeof(AuthenticationError) },
                } },
            } },
        });
    }

    public async override Task<object> watchOrderBook(object symbol, object limit = null, object parameters = null)
    {
        /**
        * @method
        * @name coincheck#watchOrderBook
        * @description watches information on open orders with bid (buy) and ask (sell) prices, volumes and other data
        * @see https://coincheck.com/documents/exchange/api#websocket-order-book
        * @param {string} symbol unified symbol of the market to fetch the order book for
        * @param {int} [limit] the maximum amount of order book entries to return
        * @param {object} [params] extra parameters specific to the exchange API endpoint
        * @returns {object} A dictionary of [order book structures]{@link https://docs.ccxt.com/#/?id=order-book-structure} indexed by market symbols
        */
        parameters ??= new Dictionary<string, object>();
        await this.loadMarkets();
        object market = this.market(symbol);
        object messageHash = add("orderbook:", getValue(market, "symbol"));
        object url = getValue(getValue(this.urls, "api"), "ws");
        object request = new Dictionary<string, object>() {
            { "type", "subscribe" },
            { "channel", add(getValue(market, "id"), "-orderbook") },
        };
        object message = this.extend(request, parameters);
        object orderbook = await this.watch(url, messageHash, message, messageHash);
        return (orderbook as IOrderBook).limit();
    }

    public virtual void handleOrderBook(WebSocketClient client, object message)
    {
        //
        //     [
        //         "btc_jpy",
        //         {
        //             "bids": [
        //                 [
        //                     "6288279.0",
        //                     "0"
        //                 ]
        //             ],
        //             "asks": [
        //                 [
        //                     "6290314.0",
        //                     "0"
        //                 ]
        //             ],
        //             "last_update_at": "1705396097"
        //         }
        //     ]
        //
        object symbol = this.symbol(this.safeString(message, 0));
        object data = this.safeValue(message, 1, new Dictionary<string, object>() {});
        object timestamp = this.safeTimestamp(data, "last_update_at");
        object snapshot = this.parseOrderBook(data, symbol, timestamp);
        object orderbook = this.safeValue(this.orderbooks, symbol);
        if (isTrue(isEqual(orderbook, null)))
        {
            orderbook = this.orderBook(snapshot);
            ((IDictionary<string,object>)this.orderbooks)[(string)symbol] = orderbook;
        } else
        {
            orderbook = getValue(this.orderbooks, symbol);
            (orderbook as IOrderBook).reset(snapshot);
        }
        object messageHash = add("orderbook:", symbol);
        callDynamically(client as WebSocketClient, "resolve", new object[] {orderbook, messageHash});
    }

    public async override Task<object> watchTrades(object symbol, object since = null, object limit = null, object parameters = null)
    {
        /**
        * @method
        * @name coincheck#watchTrades
        * @description watches information on multiple trades made in a market
        * @see https://coincheck.com/documents/exchange/api#websocket-trades
        * @param {string} symbol unified market symbol of the market trades were made in
        * @param {int} [since] the earliest time in ms to fetch trades for
        * @param {int} [limit] the maximum number of trade structures to retrieve
        * @param {object} [params] extra parameters specific to the exchange API endpoint
        * @returns {object[]} a list of [trade structures]{@link https://docs.ccxt.com/#/?id=trade-structure
        */
        parameters ??= new Dictionary<string, object>();
        await this.loadMarkets();
        object market = this.market(symbol);
        symbol = getValue(market, "symbol");
        object messageHash = add("trade:", getValue(market, "symbol"));
        object url = getValue(getValue(this.urls, "api"), "ws");
        object request = new Dictionary<string, object>() {
            { "type", "subscribe" },
            { "channel", add(getValue(market, "id"), "-trades") },
        };
        object message = this.extend(request, parameters);
        object trades = await this.watch(url, messageHash, message, messageHash);
        if (isTrue(this.newUpdates))
        {
            limit = callDynamically(trades, "getLimit", new object[] {symbol, limit});
        }
        return this.filterBySinceLimit(trades, since, limit, "timestamp", true);
    }

    public virtual void handleTrades(WebSocketClient client, object message)
    {
        //
        //     [
        //         [
        //             "1663318663", // transaction timestamp (unix time)
        //             "2357062", // transaction ID
        //             "btc_jpy", // pair
        //             "2820896.0", // transaction rate
        //             "5.0", // transaction amount
        //             "sell", // order side
        //             "1193401", // ID of the Taker
        //             "2078767" // ID of the Maker
        //         ]
        //     ]
        //
        object first = this.safeValue(message, 0, new List<object>() {});
        object symbol = this.symbol(this.safeString(first, 2));
        object stored = this.safeValue(this.trades, symbol);
        if (isTrue(isEqual(stored, null)))
        {
            object limit = this.safeInteger(this.options, "tradesLimit", 1000);
            stored = new ArrayCache(limit);
            ((IDictionary<string,object>)this.trades)[(string)symbol] = stored;
        }
        for (object i = 0; isLessThan(i, getArrayLength(message)); postFixIncrement(ref i))
        {
            object data = this.safeValue(message, i);
            object trade = this.parseWsTrade(data);
            callDynamically(stored, "append", new object[] {trade});
        }
        object messageHash = add("trade:", symbol);
        callDynamically(client as WebSocketClient, "resolve", new object[] {stored, messageHash});
    }

    public override object parseWsTrade(object trade, object market = null)
    {
        //
        //     [
        //         "1663318663", // transaction timestamp (unix time)
        //         "2357062", // transaction ID
        //         "btc_jpy", // pair
        //         "2820896.0", // transaction rate
        //         "5.0", // transaction amount
        //         "sell", // order side
        //         "1193401", // ID of the Taker
        //         "2078767" // ID of the Maker
        //     ]
        //
        object symbol = this.symbol(this.safeString(trade, 2));
        object timestamp = this.safeTimestamp(trade, 0);
        object side = this.safeString(trade, 5);
        object priceString = this.safeString(trade, 3);
        object amountString = this.safeString(trade, 4);
        return this.safeTrade(new Dictionary<string, object>() {
            { "id", this.safeString(trade, 1) },
            { "info", trade },
            { "timestamp", timestamp },
            { "datetime", this.iso8601(timestamp) },
            { "order", null },
            { "symbol", symbol },
            { "type", null },
            { "side", side },
            { "takerOrMaker", null },
            { "price", priceString },
            { "amount", amountString },
            { "cost", null },
            { "fee", null },
        }, market);
    }

    public override void handleMessage(WebSocketClient client, object message)
    {
        object data = this.safeValue(message, 0);
        if (!isTrue(((data is IList<object>) || (data.GetType().IsGenericType && data.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>))))))
        {
            this.handleOrderBook(client as WebSocketClient, message);
        } else
        {
            this.handleTrades(client as WebSocketClient, message);
        }
    }
}
