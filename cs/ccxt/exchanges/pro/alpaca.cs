namespace ccxt.pro;

// PLEASE DO NOT EDIT THIS FILE, IT IS GENERATED AND WILL BE OVERWRITTEN:
// https://github.com/ccxt/ccxt/blob/master/CONTRIBUTING.md#how-to-contribute-code


public partial class alpaca { public alpaca(object args = null) : base(args) { } }
public partial class alpaca : ccxt.alpaca
{
    public override object describe()
    {
        return this.deepExtend(base.describe(), new Dictionary<string, object>() {
            { "has", new Dictionary<string, object>() {
                { "ws", true },
                { "watchBalance", false },
                { "watchMyTrades", true },
                { "watchOHLCV", true },
                { "watchOrderBook", true },
                { "watchOrders", true },
                { "watchTicker", true },
                { "watchTickers", false },
                { "watchTrades", true },
                { "watchPosition", false },
            } },
            { "urls", new Dictionary<string, object>() {
                { "api", new Dictionary<string, object>() {
                    { "ws", new Dictionary<string, object>() {
                        { "crypto", "wss://stream.data.alpaca.markets/v1beta2/crypto" },
                        { "trading", "wss://api.alpaca.markets/stream" },
                    } },
                } },
                { "test", new Dictionary<string, object>() {
                    { "ws", new Dictionary<string, object>() {
                        { "crypto", "wss://stream.data.alpaca.markets/v1beta2/crypto" },
                        { "trading", "wss://paper-api.alpaca.markets/stream" },
                    } },
                } },
            } },
            { "options", new Dictionary<string, object>() {} },
            { "streaming", new Dictionary<string, object>() {} },
            { "exceptions", new Dictionary<string, object>() {
                { "ws", new Dictionary<string, object>() {
                    { "exact", new Dictionary<string, object>() {} },
                } },
            } },
        });
    }

    public async override Task<object> watchTicker(object symbol, object parameters = null)
    {
        /**
        * @method
        * @name alpaca#watchTicker
        * @description watches a price ticker, a statistical calculation with the information calculated over the past 24 hours for a specific market
        * @param {string} symbol unified symbol of the market to fetch the ticker for
        * @param {object} [params] extra parameters specific to the exchange API endpoint
        * @returns {object} a [ticker structure]{@link https://docs.ccxt.com/#/?id=ticker-structure}
        */
        parameters ??= new Dictionary<string, object>();
        object url = getValue(getValue(getValue(this.urls, "api"), "ws"), "crypto");
        await this.authenticate(url);
        await this.loadMarkets();
        object market = this.market(symbol);
        object messageHash = add("ticker:", getValue(market, "symbol"));
        object request = new Dictionary<string, object>() {
            { "action", "subscribe" },
            { "quotes", new List<object>() {getValue(market, "id")} },
        };
        return await this.watch(url, messageHash, this.extend(request, parameters), messageHash);
    }

    public virtual void handleTicker(WebSocketClient client, object message)
    {
        //
        //    {
        //         "T": "q",
        //         "S": "BTC/USDT",
        //         "bp": 17394.44,
        //         "bs": 0.021981,
        //         "ap": 17397.99,
        //         "as": 0.02,
        //         "t": "2022-12-16T06:07:56.611063286Z"
        //    ]
        //
        object ticker = this.parseTicker(message);
        object symbol = getValue(ticker, "symbol");
        object messageHash = add("ticker:", symbol);
        ((IDictionary<string,object>)this.tickers)[(string)symbol] = ticker;
        callDynamically(client as WebSocketClient, "resolve", new object[] {getValue(this.tickers, symbol), messageHash});
    }

    public override object parseTicker(object ticker, object market = null)
    {
        //
        //    {
        //         "T": "q",
        //         "S": "BTC/USDT",
        //         "bp": 17394.44,
        //         "bs": 0.021981,
        //         "ap": 17397.99,
        //         "as": 0.02,
        //         "t": "2022-12-16T06:07:56.611063286Z"
        //    }
        //
        object marketId = this.safeString(ticker, "S");
        object datetime = this.safeString(ticker, "t");
        return this.safeTicker(new Dictionary<string, object>() {
            { "symbol", this.safeSymbol(marketId, market) },
            { "timestamp", this.parse8601(datetime) },
            { "datetime", datetime },
            { "high", null },
            { "low", null },
            { "bid", this.safeString(ticker, "bp") },
            { "bidVolume", this.safeString(ticker, "bs") },
            { "ask", this.safeString(ticker, "ap") },
            { "askVolume", this.safeString(ticker, "as") },
            { "vwap", null },
            { "open", null },
            { "close", null },
            { "last", null },
            { "previousClose", null },
            { "change", null },
            { "percentage", null },
            { "average", null },
            { "baseVolume", null },
            { "quoteVolume", null },
            { "info", ticker },
        }, market);
    }

    public async override Task<object> watchOHLCV(object symbol, object timeframe = null, object since = null, object limit = null, object parameters = null)
    {
        /**
        * @method
        * @name alpaca#watchOHLCV
        * @description watches historical candlestick data containing the open, high, low, and close price, and the volume of a market
        * @param {string} symbol unified symbol of the market to fetch OHLCV data for
        * @param {string} timeframe the length of time each candle represents
        * @param {int} [since] timestamp in ms of the earliest candle to fetch
        * @param {int} [limit] the maximum amount of candles to fetch
        * @param {object} [params] extra parameters specific to the exchange API endpoint
        * @returns {int[][]} A list of candles ordered as timestamp, open, high, low, close, volume
        */
        timeframe ??= "1m";
        parameters ??= new Dictionary<string, object>();
        object url = getValue(getValue(getValue(this.urls, "api"), "ws"), "crypto");
        await this.authenticate(url);
        await this.loadMarkets();
        object market = this.market(symbol);
        symbol = getValue(market, "symbol");
        object request = new Dictionary<string, object>() {
            { "action", "subscribe" },
            { "bars", new List<object>() {getValue(market, "id")} },
        };
        object messageHash = add("ohlcv:", symbol);
        object ohlcv = await this.watch(url, messageHash, this.extend(request, parameters), messageHash);
        if (isTrue(this.newUpdates))
        {
            limit = callDynamically(ohlcv, "getLimit", new object[] {symbol, limit});
        }
        return this.filterBySinceLimit(ohlcv, since, limit, 0, true);
    }

    public virtual void handleOHLCV(WebSocketClient client, object message)
    {
        //
        //    {
        //        "T": "b",
        //        "S": "BTC/USDT",
        //        "o": 17416.39,
        //        "h": 17424.82,
        //        "l": 17416.39,
        //        "c": 17424.82,
        //        "v": 1.341054,
        //        "t": "2022-12-16T06:53:00Z",
        //        "n": 21,
        //        "vw": 17421.9529234915
        //    }
        //
        object marketId = this.safeString(message, "S");
        object symbol = this.safeSymbol(marketId);
        object stored = this.safeValue(this.ohlcvs, symbol);
        if (isTrue(isEqual(stored, null)))
        {
            object limit = this.safeInteger(this.options, "OHLCVLimit", 1000);
            stored = new ArrayCacheByTimestamp(limit);
            ((IDictionary<string,object>)this.ohlcvs)[(string)symbol] = stored;
        }
        object parsed = this.parseOHLCV(message);
        callDynamically(stored, "append", new object[] {parsed});
        object messageHash = add("ohlcv:", symbol);
        callDynamically(client as WebSocketClient, "resolve", new object[] {stored, messageHash});
    }

    public async override Task<object> watchOrderBook(object symbol, object limit = null, object parameters = null)
    {
        /**
        * @method
        * @name alpaca#watchOrderBook
        * @description watches information on open orders with bid (buy) and ask (sell) prices, volumes and other data
        * @param {string} symbol unified symbol of the market to fetch the order book for
        * @param {int} [limit] the maximum amount of order book entries to return.
        * @param {object} [params] extra parameters specific to the exchange API endpoint
        * @returns {object} A dictionary of [order book structures]{@link https://docs.ccxt.com/#/?id=order-book-structure} indexed by market symbols
        */
        parameters ??= new Dictionary<string, object>();
        object url = getValue(getValue(getValue(this.urls, "api"), "ws"), "crypto");
        await this.authenticate(url);
        await this.loadMarkets();
        object market = this.market(symbol);
        symbol = getValue(market, "symbol");
        object messageHash = add(add("orderbook", ":"), symbol);
        object request = new Dictionary<string, object>() {
            { "action", "subscribe" },
            { "orderbooks", new List<object>() {getValue(market, "id")} },
        };
        object orderbook = await this.watch(url, messageHash, this.extend(request, parameters), messageHash);
        return (orderbook as IOrderBook).limit();
    }

    public virtual void handleOrderBook(WebSocketClient client, object message)
    {
        //
        // snapshot
        //    {
        //        "T": "o",
        //        "S": "BTC/USDT",
        //        "t": "2022-12-16T06:35:31.585113205Z",
        //        "b": [{
        //                "p": 17394.37,
        //                "s": 0.015499,
        //            },
        //            ...
        //        ],
        //        "a": [{
        //                "p": 17398.8,
        //                "s": 0.042919,
        //            },
        //            ...
        //        ],
        //        "r": true,
        //    }
        //
        object marketId = this.safeString(message, "S");
        object symbol = this.safeSymbol(marketId);
        object datetime = this.safeString(message, "t");
        object timestamp = this.parse8601(datetime);
        object isSnapshot = this.safeBool(message, "r", false);
        object orderbook = this.safeValue(this.orderbooks, symbol);
        if (isTrue(isEqual(orderbook, null)))
        {
            orderbook = this.orderBook();
        }
        if (isTrue(isSnapshot))
        {
            object snapshot = this.parseOrderBook(message, symbol, timestamp, "b", "a", "p", "s");
            (orderbook as IOrderBook).reset(snapshot);
        } else
        {
            object asks = this.safeValue(message, "a", new List<object>() {});
            object bids = this.safeValue(message, "b", new List<object>() {});
            this.handleDeltas(getValue(orderbook, "asks"), asks);
            this.handleDeltas(getValue(orderbook, "bids"), bids);
            ((IDictionary<string,object>)orderbook)["timestamp"] = timestamp;
            ((IDictionary<string,object>)orderbook)["datetime"] = datetime;
        }
        object messageHash = add(add("orderbook", ":"), symbol);
        ((IDictionary<string,object>)this.orderbooks)[(string)symbol] = orderbook;
        callDynamically(client as WebSocketClient, "resolve", new object[] {orderbook, messageHash});
    }

    public override void handleDelta(object bookside, object delta)
    {
        object bidAsk = this.parseBidAsk(delta, "p", "s");
        (bookside as IOrderBookSide).storeArray(bidAsk);
    }

    public override void handleDeltas(object bookside, object deltas)
    {
        for (object i = 0; isLessThan(i, getArrayLength(deltas)); postFixIncrement(ref i))
        {
            this.handleDelta(bookside, getValue(deltas, i));
        }
    }

    public async override Task<object> watchTrades(object symbol, object since = null, object limit = null, object parameters = null)
    {
        /**
        * @method
        * @name alpaca#watchTrades
        * @description watches information on multiple trades made in a market
        * @param {string} symbol unified market symbol of the market trades were made in
        * @param {int} [since] the earliest time in ms to fetch orders for
        * @param {int} [limit] the maximum number of trade structures to retrieve
        * @param {object} [params] extra parameters specific to the exchange API endpoint
        * @returns {object[]} a list of [trade structures]{@link https://docs.ccxt.com/#/?id=trade-structure
        */
        parameters ??= new Dictionary<string, object>();
        object url = getValue(getValue(getValue(this.urls, "api"), "ws"), "crypto");
        await this.authenticate(url);
        await this.loadMarkets();
        object market = this.market(symbol);
        symbol = getValue(market, "symbol");
        object messageHash = add("trade:", symbol);
        object request = new Dictionary<string, object>() {
            { "action", "subscribe" },
            { "trades", new List<object>() {getValue(market, "id")} },
        };
        object trades = await this.watch(url, messageHash, this.extend(request, parameters), messageHash);
        if (isTrue(this.newUpdates))
        {
            limit = callDynamically(trades, "getLimit", new object[] {symbol, limit});
        }
        return this.filterBySinceLimit(trades, since, limit, "timestamp", true);
    }

    public virtual void handleTrades(WebSocketClient client, object message)
    {
        //
        //     {
        //         "T": "t",
        //         "S": "BTC/USDT",
        //         "p": 17408.8,
        //         "s": 0.042919,
        //         "t": "2022-12-16T06:43:18.327Z",
        //         "i": 16585162,
        //         "tks": "B"
        //     ]
        //
        object marketId = this.safeString(message, "S");
        object symbol = this.safeSymbol(marketId);
        object stored = this.safeValue(this.trades, symbol);
        if (isTrue(isEqual(stored, null)))
        {
            object limit = this.safeInteger(this.options, "tradesLimit", 1000);
            stored = new ArrayCache(limit);
            ((IDictionary<string,object>)this.trades)[(string)symbol] = stored;
        }
        object parsed = this.parseTrade(message);
        callDynamically(stored, "append", new object[] {parsed});
        object messageHash = add(add("trade", ":"), symbol);
        callDynamically(client as WebSocketClient, "resolve", new object[] {stored, messageHash});
    }

    public async override Task<object> watchMyTrades(object symbol = null, object since = null, object limit = null, object parameters = null)
    {
        /**
        * @method
        * @name alpaca#watchMyTrades
        * @description watches information on multiple trades made by the user
        * @param {string} symbol unified market symbol of the market trades were made in
        * @param {int} [since] the earliest time in ms to fetch trades for
        * @param {int} [limit] the maximum number of trade structures to retrieve
        * @param {object} [params] extra parameters specific to the exchange API endpoint
        * @param {boolean} [params.unifiedMargin] use unified margin account
        * @returns {object[]} a list of [trade structures]{@link https://docs.ccxt.com/#/?id=trade-structure
        */
        parameters ??= new Dictionary<string, object>();
        object url = getValue(getValue(getValue(this.urls, "api"), "ws"), "trading");
        await this.authenticate(url);
        object messageHash = "myTrades";
        await this.loadMarkets();
        if (isTrue(!isEqual(symbol, null)))
        {
            symbol = this.symbol(symbol);
            messageHash = add(messageHash, add(":", symbol));
        }
        object request = new Dictionary<string, object>() {
            { "action", "listen" },
            { "data", new Dictionary<string, object>() {
                { "streams", new List<object>() {"trade_updates"} },
            } },
        };
        object trades = await this.watch(url, messageHash, this.extend(request, parameters), messageHash);
        if (isTrue(this.newUpdates))
        {
            limit = callDynamically(trades, "getLimit", new object[] {symbol, limit});
        }
        return this.filterBySinceLimit(trades, since, limit, "timestamp", true);
    }

    public async override Task<object> watchOrders(object symbol = null, object since = null, object limit = null, object parameters = null)
    {
        /**
        * @method
        * @name alpaca#watchOrders
        * @description watches information on multiple orders made by the user
        * @param {string} symbol unified market symbol of the market orders were made in
        * @param {int} [since] the earliest time in ms to fetch orders for
        * @param {int} [limit] the maximum number of order structures to retrieve
        * @param {object} [params] extra parameters specific to the exchange API endpoint
        * @returns {object[]} a list of [order structures]{@link https://docs.ccxt.com/#/?id=order-structure
        */
        parameters ??= new Dictionary<string, object>();
        object url = getValue(getValue(getValue(this.urls, "api"), "ws"), "trading");
        await this.authenticate(url);
        await this.loadMarkets();
        object messageHash = "orders";
        if (isTrue(!isEqual(symbol, null)))
        {
            object market = this.market(symbol);
            symbol = getValue(market, "symbol");
            messageHash = add("orders:", symbol);
        }
        object request = new Dictionary<string, object>() {
            { "action", "listen" },
            { "data", new Dictionary<string, object>() {
                { "streams", new List<object>() {"trade_updates"} },
            } },
        };
        object orders = await this.watch(url, messageHash, this.extend(request, parameters), messageHash);
        if (isTrue(this.newUpdates))
        {
            limit = callDynamically(orders, "getLimit", new object[] {symbol, limit});
        }
        return this.filterBySymbolSinceLimit(orders, symbol, since, limit, true);
    }

    public virtual void handleTradeUpdate(WebSocketClient client, object message)
    {
        this.handleOrder(client as WebSocketClient, message);
        this.handleMyTrade(client as WebSocketClient, message);
    }

    public virtual void handleOrder(WebSocketClient client, object message)
    {
        //
        //    {
        //        "stream": "trade_updates",
        //        "data": {
        //          "event": "new",
        //          "timestamp": "2022-12-16T07:28:51.67621869Z",
        //          "order": {
        //            "id": "c2470331-8993-4051-bf5d-428d5bdc9a48",
        //            "client_order_id": "0f1f3764-107a-4d09-8b9a-d75a11738f5c",
        //            "created_at": "2022-12-16T02:28:51.673531798-05:00",
        //            "updated_at": "2022-12-16T02:28:51.678736847-05:00",
        //            "submitted_at": "2022-12-16T02:28:51.673015558-05:00",
        //            "filled_at": null,
        //            "expired_at": null,
        //            "cancel_requested_at": null,
        //            "canceled_at": null,
        //            "failed_at": null,
        //            "replaced_at": null,
        //            "replaced_by": null,
        //            "replaces": null,
        //            "asset_id": "276e2673-764b-4ab6-a611-caf665ca6340",
        //            "symbol": "BTC/USD",
        //            "asset_class": "crypto",
        //            "notional": null,
        //            "qty": "0.01",
        //            "filled_qty": "0",
        //            "filled_avg_price": null,
        //            "order_class": '',
        //            "order_type": "market",
        //            "type": "market",
        //            "side": "buy",
        //            "time_in_force": "gtc",
        //            "limit_price": null,
        //            "stop_price": null,
        //            "status": "new",
        //            "extended_hours": false,
        //            "legs": null,
        //            "trail_percent": null,
        //            "trail_price": null,
        //            "hwm": null
        //          },
        //          "execution_id": "5f781a30-b9a3-4c86-b466-2175850cf340"
        //        }
        //      }
        //
        object data = this.safeValue(message, "data", new Dictionary<string, object>() {});
        object rawOrder = this.safeValue(data, "order", new Dictionary<string, object>() {});
        if (isTrue(isEqual(this.orders, null)))
        {
            object limit = this.safeInteger(this.options, "ordersLimit", 1000);
            this.orders = new ArrayCacheBySymbolById(limit);
        }
        object orders = this.orders;
        object order = this.parseOrder(rawOrder);
        callDynamically(orders, "append", new object[] {order});
        object messageHash = "orders";
        callDynamically(client as WebSocketClient, "resolve", new object[] {orders, messageHash});
        messageHash = add("orders:", getValue(order, "symbol"));
        callDynamically(client as WebSocketClient, "resolve", new object[] {orders, messageHash});
    }

    public virtual void handleMyTrade(WebSocketClient client, object message)
    {
        //
        //    {
        //        "stream": "trade_updates",
        //        "data": {
        //          "event": "new",
        //          "timestamp": "2022-12-16T07:28:51.67621869Z",
        //          "order": {
        //            "id": "c2470331-8993-4051-bf5d-428d5bdc9a48",
        //            "client_order_id": "0f1f3764-107a-4d09-8b9a-d75a11738f5c",
        //            "created_at": "2022-12-16T02:28:51.673531798-05:00",
        //            "updated_at": "2022-12-16T02:28:51.678736847-05:00",
        //            "submitted_at": "2022-12-16T02:28:51.673015558-05:00",
        //            "filled_at": null,
        //            "expired_at": null,
        //            "cancel_requested_at": null,
        //            "canceled_at": null,
        //            "failed_at": null,
        //            "replaced_at": null,
        //            "replaced_by": null,
        //            "replaces": null,
        //            "asset_id": "276e2673-764b-4ab6-a611-caf665ca6340",
        //            "symbol": "BTC/USD",
        //            "asset_class": "crypto",
        //            "notional": null,
        //            "qty": "0.01",
        //            "filled_qty": "0",
        //            "filled_avg_price": null,
        //            "order_class": '',
        //            "order_type": "market",
        //            "type": "market",
        //            "side": "buy",
        //            "time_in_force": "gtc",
        //            "limit_price": null,
        //            "stop_price": null,
        //            "status": "new",
        //            "extended_hours": false,
        //            "legs": null,
        //            "trail_percent": null,
        //            "trail_price": null,
        //            "hwm": null
        //          },
        //          "execution_id": "5f781a30-b9a3-4c86-b466-2175850cf340"
        //        }
        //      }
        //
        object data = this.safeValue(message, "data", new Dictionary<string, object>() {});
        object eventVar = this.safeString(data, "event");
        if (isTrue(isTrue(!isEqual(eventVar, "fill")) && isTrue(!isEqual(eventVar, "partial_fill"))))
        {
            return;
        }
        object rawOrder = this.safeValue(data, "order", new Dictionary<string, object>() {});
        object myTrades = this.myTrades;
        if (isTrue(isEqual(myTrades, null)))
        {
            object limit = this.safeInteger(this.options, "tradesLimit", 1000);
            myTrades = new ArrayCacheBySymbolById(limit);
        }
        object trade = this.parseMyTrade(rawOrder);
        callDynamically(myTrades, "append", new object[] {trade});
        object messageHash = add("myTrades:", getValue(trade, "symbol"));
        callDynamically(client as WebSocketClient, "resolve", new object[] {myTrades, messageHash});
        messageHash = "myTrades";
        callDynamically(client as WebSocketClient, "resolve", new object[] {myTrades, messageHash});
    }

    public virtual object parseMyTrade(object trade, object market = null)
    {
        //
        //    {
        //        "id": "c2470331-8993-4051-bf5d-428d5bdc9a48",
        //        "client_order_id": "0f1f3764-107a-4d09-8b9a-d75a11738f5c",
        //        "created_at": "2022-12-16T02:28:51.673531798-05:00",
        //        "updated_at": "2022-12-16T02:28:51.678736847-05:00",
        //        "submitted_at": "2022-12-16T02:28:51.673015558-05:00",
        //        "filled_at": null,
        //        "expired_at": null,
        //        "cancel_requested_at": null,
        //        "canceled_at": null,
        //        "failed_at": null,
        //        "replaced_at": null,
        //        "replaced_by": null,
        //        "replaces": null,
        //        "asset_id": "276e2673-764b-4ab6-a611-caf665ca6340",
        //        "symbol": "BTC/USD",
        //        "asset_class": "crypto",
        //        "notional": null,
        //        "qty": "0.01",
        //        "filled_qty": "0",
        //        "filled_avg_price": null,
        //        "order_class": '',
        //        "order_type": "market",
        //        "type": "market",
        //        "side": "buy",
        //        "time_in_force": "gtc",
        //        "limit_price": null,
        //        "stop_price": null,
        //        "status": "new",
        //        "extended_hours": false,
        //        "legs": null,
        //        "trail_percent": null,
        //        "trail_price": null,
        //        "hwm": null
        //    }
        //
        object marketId = this.safeString(trade, "symbol");
        object datetime = this.safeString(trade, "filled_at");
        object type = this.safeString(trade, "type");
        if (isTrue(isGreaterThanOrEqual(getIndexOf(type, "limit"), 0)))
        {
            // might be limit or stop-limit
            type = "limit";
        }
        return this.safeTrade(new Dictionary<string, object>() {
            { "id", this.safeString(trade, "i") },
            { "info", trade },
            { "timestamp", this.parse8601(datetime) },
            { "datetime", datetime },
            { "symbol", this.safeSymbol(marketId, null, "/") },
            { "order", this.safeString(trade, "id") },
            { "type", type },
            { "side", this.safeString(trade, "side") },
            { "takerOrMaker", ((bool) isTrue((isEqual(type, "market")))) ? "taker" : "maker" },
            { "price", this.safeString(trade, "filled_avg_price") },
            { "amount", this.safeString(trade, "filled_qty") },
            { "cost", null },
            { "fee", null },
        }, market);
    }

    public async virtual Task<object> authenticate(object url, object parameters = null)
    {
        parameters ??= new Dictionary<string, object>();
        this.checkRequiredCredentials();
        object messageHash = "authenticated";
        var client = this.client(url);
        var future = client.future(messageHash);
        object authenticated = this.safeValue(((WebSocketClient)client).subscriptions, messageHash);
        if (isTrue(isEqual(authenticated, null)))
        {
            object request = new Dictionary<string, object>() {
                { "action", "auth" },
                { "key", this.apiKey },
                { "secret", this.secret },
            };
            if (isTrue(isEqual(url, getValue(getValue(getValue(this.urls, "api"), "ws"), "trading"))))
            {
                // this auth request is being deprecated in test environment
                request = ((object)new Dictionary<string, object>() {
                    { "action", "authenticate" },
                    { "data", new Dictionary<string, object>() {
                        { "key_id", this.apiKey },
                        { "secret_key", this.secret },
                    } },
                });
            }
            this.watch(url, messageHash, request, messageHash, future);
        }
        return await (future as Exchange.Future);
    }

    public virtual void handleErrorMessage(WebSocketClient client, object message)
    {
        //
        //    {
        //        "T": "error",
        //        "code": 400,
        //        "msg": "invalid syntax"
        //    }
        //
        object code = this.safeString(message, "code");
        object msg = this.safeValue(message, "msg", new Dictionary<string, object>() {});
        throw new ExchangeError ((string)add(add(add(add(this.id, " code: "), code), " message: "), msg)) ;
    }

    public virtual object handleConnected(WebSocketClient client, object message)
    {
        //
        //    {
        //        "T": "success",
        //        "msg": "connected"
        //    }
        //
        return message;
    }

    public virtual void handleCryptoMessage(WebSocketClient client, object message)
    {
        for (object i = 0; isLessThan(i, getArrayLength(message)); postFixIncrement(ref i))
        {
            object data = getValue(message, i);
            object T = this.safeString(data, "T");
            object msg = this.safeString(data, "msg");
            if (isTrue(isEqual(T, "subscription")))
            {
                this.handleSubscription(client as WebSocketClient, data);
                return;
            }
            if (isTrue(isTrue(isEqual(T, "success")) && isTrue(isEqual(msg, "connected"))))
            {
                this.handleConnected(client as WebSocketClient, data);
                return;
            }
            if (isTrue(isTrue(isEqual(T, "success")) && isTrue(isEqual(msg, "authenticated"))))
            {
                this.handleAuthenticate(client as WebSocketClient, data);
                return;
            }
            object methods = new Dictionary<string, object>() {
                { "error", this.handleErrorMessage },
                { "b", this.handleOHLCV },
                { "q", this.handleTicker },
                { "t", this.handleTrades },
                { "o", this.handleOrderBook },
            };
            object method = this.safeValue(methods, T);
            if (isTrue(!isEqual(method, null)))
            {
                DynamicInvoker.InvokeMethod(method, new object[] { client, data});
            }
        }
    }

    public virtual void handleTradingMessage(WebSocketClient client, object message)
    {
        object stream = this.safeString(message, "stream");
        object methods = new Dictionary<string, object>() {
            { "authorization", this.handleAuthenticate },
            { "listening", this.handleSubscription },
            { "trade_updates", this.handleTradeUpdate },
        };
        object method = this.safeValue(methods, stream);
        if (isTrue(!isEqual(method, null)))
        {
            DynamicInvoker.InvokeMethod(method, new object[] { client, message});
        }
    }

    public override void handleMessage(WebSocketClient client, object message)
    {
        if (isTrue(((message is IList<object>) || (message.GetType().IsGenericType && message.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>))))))
        {
            this.handleCryptoMessage(client as WebSocketClient, message);
            return;
        }
        this.handleTradingMessage(client as WebSocketClient, message);
    }

    public virtual void handleAuthenticate(WebSocketClient client, object message)
    {
        //
        // crypto
        //    {
        //        "T": "success",
        //        "msg": "connected"
        //    ]
        //
        // trading
        //    {
        //        "stream": "authorization",
        //        "data": {
        //            "status": "authorized",
        //            "action": "authenticate"
        //        }
        //    }
        // error
        //    {
        //        "stream": "authorization",
        //        "data": {
        //            "action": "authenticate",
        //            "message": "access key verification failed",
        //            "status": "unauthorized"
        //        }
        //    }
        //
        object T = this.safeString(message, "T");
        object data = this.safeValue(message, "data", new Dictionary<string, object>() {});
        object status = this.safeString(data, "status");
        if (isTrue(isTrue(isEqual(T, "success")) || isTrue(isEqual(status, "authorized"))))
        {
            object promise = getValue(client.futures, "authenticated");
            callDynamically(promise, "resolve", new object[] {message});
            return;
        }
        throw new AuthenticationError ((string)add(this.id, " failed to authenticate.")) ;
    }

    public virtual object handleSubscription(WebSocketClient client, object message)
    {
        //
        // crypto
        //    {
        //          "T": "subscription",
        //          "trades": [],
        //          "quotes": [ "BTC/USDT" ],
        //          "orderbooks": [],
        //          "bars": [],
        //          "updatedBars": [],
        //          "dailyBars": []
        //    }
        // trading
        //    {
        //        "stream": "listening",
        //        "data": {
        //            "streams": ["trade_updates"]
        //        }
        //    }
        //
        return message;
    }
}
