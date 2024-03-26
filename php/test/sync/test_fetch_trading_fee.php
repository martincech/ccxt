<?php
namespace ccxt;

// ----------------------------------------------------------------------------

// PLEASE DO NOT EDIT THIS FILE, IT IS GENERATED AND WILL BE OVERWRITTEN:
// https://github.com/ccxt/ccxt/blob/master/CONTRIBUTING.md#how-to-contribute-code

// -----------------------------------------------------------------------------
include_once PATH_TO_CCXT . '/test/base/test_trading_fee.php';

function test_fetch_trading_fee($exchange, $skipped_properties, $symbol) {
    $method = 'fetchTradingFee';
    $fee = $exchange->fetch_trading_fee($symbol);
    assert(is_array($fee), $exchange->id . ' ' . $method . ' ' . $symbol . ' must return an object. ' . $exchange->json($fee));
    test_trading_fee($exchange, $skipped_properties, $method, $symbol, $fee);
}
