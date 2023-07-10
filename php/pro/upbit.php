<?php

namespace ccxt\pro;

// PLEASE DO NOT EDIT THIS FILE, IT IS GENERATED AND WILL BE OVERWRITTEN:
// https://github.com/ccxt/ccxt/blob/master/CONTRIBUTING.md#how-to-contribute-code

use Exception; // a common import
use React\Async;

class upbit extends \ccxt\async\upbit {

    public function describe() {
        return $this->deep_extend(parent::describe(), array(
            'has' => array(
                'ws' => true,
                'watchOrderBook' => true,
                'watchTicker' => true,
                'watchTrades' => true,
            ),
            'urls' => array(
                'api' => array(
                    'ws' => 'wss://api.upbit.com/websocket/v1',
                ),
            ),
            'options' => array(
                'tradesLimit' => 1000,
            ),
        ));
    }

    public function watch_public(string $symbol, $channel, $params = array ()) {
        return Async\async(function () use ($symbol, $channel, $params) {
            Async\await($this->load_markets());
            $market = $this->market($symbol);
            $symbol = $market['symbol'];
            $marketId = $market['id'];
            $url = $this->urls['api']['ws'];
            $this->options[$channel] = $this->safe_value($this->options, $channel, array());
            $this->options[$channel][$symbol] = true;
            $symbols = is_array($this->options[$channel]) ? array_keys($this->options[$channel]) : array();
            $marketIds = $this->market_ids($symbols);
            $request = array(
                array(
                    'ticket' => $this->uuid(),
                ),
                array(
                    'type' => $channel,
                    'codes' => $marketIds,
                    // 'isOnlySnapshot' => false,
                    // 'isOnlyRealtime' => false,
                ),
            );
            $messageHash = $channel . ':' . $marketId;
            return Async\await($this->watch($url, $messageHash, $request, $messageHash));
        }) ();
    }

    public function watch_ticker(string $symbol, $params = array ()) {
        return Async\async(function () use ($symbol, $params) {
            /**
             * watches a price ticker, a statistical calculation with the information calculated over the past 24 hours for a specific market
             * @param {string} $symbol unified $symbol of the market to fetch the ticker for
             * @param {array} [$params] extra parameters specific to the upbit api endpoint
             * @return {array} a ~@link https://docs.ccxt.com/#/?id=ticker-structure ticker structure~
             */
            return Async\await($this->watch_public($symbol, 'ticker'));
        }) ();
    }

    public function watch_trades(string $symbol, ?int $since = null, ?int $limit = null, $params = array ()) {
        return Async\async(function () use ($symbol, $since, $limit, $params) {
            /**
             * get the list of most recent $trades for a particular $symbol
             * @param {string} $symbol unified $symbol of the market to fetch $trades for
             * @param {int} [$since] timestamp in ms of the earliest trade to fetch
             * @param {int} [$limit] the maximum amount of $trades to fetch
             * @param {array} [$params] extra parameters specific to the upbit api endpoint
             * @return {array[]} a list of ~@link https://docs.ccxt.com/en/latest/manual.html?#public-$trades trade structures~
             */
            Async\await($this->load_markets());
            $symbol = $this->symbol($symbol);
            $trades = Async\await($this->watch_public($symbol, 'trade'));
            if ($this->newUpdates) {
                $limit = $trades->getLimit ($symbol, $limit);
            }
            return $this->filter_by_since_limit($trades, $since, $limit, 'timestamp', true);
        }) ();
    }

    public function watch_order_book(string $symbol, ?int $limit = null, $params = array ()) {
        return Async\async(function () use ($symbol, $limit, $params) {
            /**
             * watches information on open orders with bid (buy) and ask (sell) prices, volumes and other data
             * @param {string} $symbol unified $symbol of the market to fetch the order book for
             * @param {int} [$limit] the maximum amount of order book entries to return
             * @param {array} [$params] extra parameters specific to the upbit api endpoint
             * @return {array} A dictionary of ~@link https://docs.ccxt.com/#/?id=order-book-structure order book structures~ indexed by market symbols
             */
            $orderbook = Async\await($this->watch_public($symbol, 'orderbook'));
            return $orderbook->limit ();
        }) ();
    }

    public function handle_ticker(Client $client, $message) {
        // 2020-03-17T23:07:36.511Z 'onMessage' <Buffer 7b 22 74 79 70 65 22 3a 22 74 69 63 6b 65 72 22 2c 22 63 6f 64 65 22 3a 22 42 54 43 2d 45 54 48 22 2c 22 6f 70 65 6e 69 6e 67 5f 70 72 69 63 65 22 3a ... >
        // { type => 'ticker',
        //   code => 'BTC-ETH',
        //   opening_price => 0.02295092,
        //   high_price => 0.02295092,
        //   low_price => 0.02161249,
        //   trade_price => 0.02161249,
        //   prev_closing_price => 0.02185802,
        //   acc_trade_price => 2.32732482,
        //   change => 'FALL',
        //   change_price => 0.00024553,
        //   signed_change_price => -0.00024553,
        //   change_rate => 0.0112329479,
        //   signed_change_rate => -0.0112329479,
        //   ask_bid => 'ASK',
        //   trade_volume => 2.12,
        //   acc_trade_volume => 106.11798418,
        //   trade_date => '20200317',
        //   trade_time => '215843',
        //   trade_timestamp => 1584482323000,
        //   acc_ask_volume => 90.16935908,
        //   acc_bid_volume => 15.9486251,
        //   highest_52_week_price => 0.03537414,
        //   highest_52_week_date => '2019-04-08',
        //   lowest_52_week_price => 0.01614901,
        //   lowest_52_week_date => '2019-09-06',
        //   trade_status => null,
        //   market_state => 'ACTIVE',
        //   market_state_for_ios => null,
        //   is_trading_suspended => false,
        //   delisting_date => null,
        //   market_warning => 'NONE',
        //   timestamp => 1584482323378,
        //   acc_trade_price_24h => 2.5955306323568927,
        //   acc_trade_volume_24h => 118.38798416,
        //   stream_type => 'SNAPSHOT' }
        $marketId = $this->safe_string($message, 'code');
        $messageHash = 'ticker:' . $marketId;
        $ticker = $this->parse_ticker($message);
        $symbol = $ticker['symbol'];
        $this->tickers[$symbol] = $ticker;
        $client->resolve ($ticker, $messageHash);
    }

    public function handle_order_book(Client $client, $message) {
        // { $type => 'orderbook',
        //   code => 'BTC-ETH',
        //   $timestamp => 1584486737444,
        //   total_ask_size => 16.76384456,
        //   total_bid_size => 168.9020623,
        //   orderbook_units:
        //    array( array( $ask_price => 0.02295077,
        //        $bid_price => 0.02161249,
        //        $ask_size => 3.57100696,
        //        $bid_size => 22.5303265 ),
        //      array( $ask_price => 0.02295078,
        //        $bid_price => 0.02152658,
        //        $ask_size => 0.52451651,
        //        $bid_size => 2.30355128 ),
        //      array( $ask_price => 0.02295086,
        //        $bid_price => 0.02150802,
        //        $ask_size => 1.585,
        //        $bid_size => 5 ), ... ),
        //   stream_type => 'SNAPSHOT' }
        $marketId = $this->safe_string($message, 'code');
        $symbol = $this->safe_symbol($marketId, null, '-');
        $type = $this->safe_string($message, 'stream_type');
        $options = $this->safe_value($this->options, 'watchOrderBook', array());
        $limit = $this->safe_integer($options, 'limit', 15);
        if ($type === 'SNAPSHOT') {
            $this->orderbooks[$symbol] = $this->order_book(array(), $limit);
        }
        $orderBook = $this->orderbooks[$symbol];
        // upbit always returns a snapshot of 15 topmost entries
        // the "REALTIME" deltas are not incremental
        // therefore we reset the orderbook on each update
        // and reinitialize it again with new bidasks
        $orderBook->reset (array());
        $orderBook['symbol'] = $symbol;
        $bids = $orderBook['bids'];
        $asks = $orderBook['asks'];
        $data = $this->safe_value($message, 'orderbook_units', array());
        for ($i = 0; $i < count($data); $i++) {
            $entry = $data[$i];
            $ask_price = $this->safe_float($entry, 'ask_price');
            $ask_size = $this->safe_float($entry, 'ask_size');
            $bid_price = $this->safe_float($entry, 'bid_price');
            $bid_size = $this->safe_float($entry, 'bid_size');
            $asks->store ($ask_price, $ask_size);
            $bids->store ($bid_price, $bid_size);
        }
        $timestamp = $this->safe_integer($message, 'timestamp');
        $datetime = $this->iso8601($timestamp);
        $orderBook['timestamp'] = $timestamp;
        $orderBook['datetime'] = $datetime;
        $messageHash = 'orderbook:' . $marketId;
        $client->resolve ($orderBook, $messageHash);
    }

    public function handle_trades(Client $client, $message) {
        // { type => 'trade',
        //   code => 'KRW-BTC',
        //   timestamp => 1584508285812,
        //   trade_date => '2020-03-18',
        //   trade_time => '05:11:25',
        //   trade_timestamp => 1584508285000,
        //   trade_price => 6747000,
        //   trade_volume => 0.06499468,
        //   ask_bid => 'ASK',
        //   prev_closing_price => 6774000,
        //   change => 'FALL',
        //   change_price => 27000,
        //   sequential_id => 1584508285000002,
        //   stream_type => 'REALTIME' }
        $trade = $this->parse_trade($message);
        $symbol = $trade['symbol'];
        $stored = $this->safe_value($this->trades, $symbol);
        if ($stored === null) {
            $limit = $this->safe_integer($this->options, 'tradesLimit', 1000);
            $stored = new ArrayCache ($limit);
            $this->trades[$symbol] = $stored;
        }
        $stored->append ($trade);
        $marketId = $this->safe_string($message, 'code');
        $messageHash = 'trade:' . $marketId;
        $client->resolve ($stored, $messageHash);
    }

    public function handle_message(Client $client, $message) {
        $methods = array(
            'ticker' => array($this, 'handle_ticker'),
            'orderbook' => array($this, 'handle_order_book'),
            'trade' => array($this, 'handle_trades'),
        );
        $methodName = $this->safe_string($message, 'type');
        $method = $this->safe_value($methods, $methodName);
        if ($method) {
            $method($client, $message);
        }
    }
}
