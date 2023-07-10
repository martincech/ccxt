// ----------------------------------------------------------------------------

// PLEASE DO NOT EDIT THIS FILE, IT IS GENERATED AND WILL BE OVERWRITTEN:
// https://github.com/ccxt/ccxt/blob/master/CONTRIBUTING.md#how-to-contribute-code
// EDIT THE CORRESPONDENT .ts FILE INSTEAD

import assert from 'assert';
import testTicker from './base/test.ticker.js';
async function testFetchTickers(exchange, skippedProperties, symbol) {
    const method = 'fetchTickers';
    // log ('fetching all tickers at once...')
    let tickers = undefined;
    let checkedSymbol = undefined;
    try {
        tickers = await exchange.fetchTickers();
    }
    catch (e) {
        tickers = await exchange.fetchTickers([symbol]);
        checkedSymbol = symbol;
    }
    assert(typeof tickers === 'object', exchange.id + ' ' + method + ' ' + checkedSymbol + ' must return an object. ' + exchange.json(tickers));
    const values = Object.values(tickers);
    for (let i = 0; i < values.length; i++) {
        const ticker = values[i];
        testTicker(exchange, skippedProperties, method, ticker, checkedSymbol);
    }
}
export default testFetchTickers;
