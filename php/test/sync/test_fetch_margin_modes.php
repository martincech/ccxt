<?php
namespace ccxt;

// ----------------------------------------------------------------------------

// PLEASE DO NOT EDIT THIS FILE, IT IS GENERATED AND WILL BE OVERWRITTEN:
// https://github.com/ccxt/ccxt/blob/master/CONTRIBUTING.md#how-to-contribute-code

// -----------------------------------------------------------------------------
include_once PATH_TO_CCXT . '/test/base/test_margin_mode.php';

function test_fetch_margin_modes($exchange, $skipped_properties, $symbol) {
    $method = 'fetchMarginModes';
    $margin_modes = $exchange->fetch_margin_modes($symbol);
    assert(is_array($margin_modes), $exchange->id . ' ' . $method . ' ' . $symbol . ' must return an object. ' . $exchange->json($margin_modes));
    $margin_mode_keys = is_array($margin_modes) ? array_keys($margin_modes) : array();
    assert_non_emtpy_array($exchange, $skipped_properties, $method, $margin_modes, $symbol);
    for ($i = 0; $i < count($margin_mode_keys); $i++) {
        $margin_modes_for_symbol = $margin_modes[$margin_mode_keys[$i]];
        assert_non_emtpy_array($exchange, $skipped_properties, $method, $margin_modes_for_symbol, $symbol);
        for ($j = 0; $j < count($margin_modes_for_symbol); $j++) {
            test_margin_mode($exchange, $skipped_properties, $method, $margin_modes_for_symbol[$j]);
        }
    }
}
