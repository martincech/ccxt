<?php

namespace ccxt\abstract;

// PLEASE DO NOT EDIT THIS FILE, IT IS GENERATED AND WILL BE OVERWRITTEN:
// https://github.com/ccxt/ccxt/blob/master/CONTRIBUTING.md#how-to-contribute-code


abstract class coinbase extends \ccxt\Exchange {
    public function v2_public_get_currencies($params = array()) {
        return $this->request('currencies', array('v2', 'public'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_public_get_currencies_crypto($params = array()) {
        return $this->request('currencies/crypto', array('v2', 'public'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_public_get_time($params = array()) {
        return $this->request('time', array('v2', 'public'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_public_get_exchange_rates($params = array()) {
        return $this->request('exchange-rates', array('v2', 'public'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_public_get_users_user_id($params = array()) {
        return $this->request('users/{user_id}', array('v2', 'public'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_public_get_prices_symbol_buy($params = array()) {
        return $this->request('prices/{symbol}/buy', array('v2', 'public'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_public_get_prices_symbol_sell($params = array()) {
        return $this->request('prices/{symbol}/sell', array('v2', 'public'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_public_get_prices_symbol_spot($params = array()) {
        return $this->request('prices/{symbol}/spot', array('v2', 'public'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_get_accounts($params = array()) {
        return $this->request('accounts', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_get_accounts_account_id($params = array()) {
        return $this->request('accounts/{account_id}', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_get_accounts_account_id_addresses($params = array()) {
        return $this->request('accounts/{account_id}/addresses', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_get_accounts_account_id_addresses_address_id($params = array()) {
        return $this->request('accounts/{account_id}/addresses/{address_id}', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_get_accounts_account_id_addresses_address_id_transactions($params = array()) {
        return $this->request('accounts/{account_id}/addresses/{address_id}/transactions', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_get_accounts_account_id_transactions($params = array()) {
        return $this->request('accounts/{account_id}/transactions', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_get_accounts_account_id_transactions_transaction_id($params = array()) {
        return $this->request('accounts/{account_id}/transactions/{transaction_id}', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_get_accounts_account_id_buys($params = array()) {
        return $this->request('accounts/{account_id}/buys', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_get_accounts_account_id_buys_buy_id($params = array()) {
        return $this->request('accounts/{account_id}/buys/{buy_id}', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_get_accounts_account_id_sells($params = array()) {
        return $this->request('accounts/{account_id}/sells', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_get_accounts_account_id_sells_sell_id($params = array()) {
        return $this->request('accounts/{account_id}/sells/{sell_id}', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_get_accounts_account_id_deposits($params = array()) {
        return $this->request('accounts/{account_id}/deposits', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_get_accounts_account_id_deposits_deposit_id($params = array()) {
        return $this->request('accounts/{account_id}/deposits/{deposit_id}', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_get_accounts_account_id_withdrawals($params = array()) {
        return $this->request('accounts/{account_id}/withdrawals', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_get_accounts_account_id_withdrawals_withdrawal_id($params = array()) {
        return $this->request('accounts/{account_id}/withdrawals/{withdrawal_id}', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_get_payment_methods($params = array()) {
        return $this->request('payment-methods', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_get_payment_methods_payment_method_id($params = array()) {
        return $this->request('payment-methods/{payment_method_id}', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_get_user($params = array()) {
        return $this->request('user', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_get_user_auth($params = array()) {
        return $this->request('user/auth', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_post_accounts($params = array()) {
        return $this->request('accounts', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_post_accounts_account_id_primary($params = array()) {
        return $this->request('accounts/{account_id}/primary', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_post_accounts_account_id_addresses($params = array()) {
        return $this->request('accounts/{account_id}/addresses', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_post_accounts_account_id_transactions($params = array()) {
        return $this->request('accounts/{account_id}/transactions', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_post_accounts_account_id_transactions_transaction_id_complete($params = array()) {
        return $this->request('accounts/{account_id}/transactions/{transaction_id}/complete', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_post_accounts_account_id_transactions_transaction_id_resend($params = array()) {
        return $this->request('accounts/{account_id}/transactions/{transaction_id}/resend', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_post_accounts_account_id_buys($params = array()) {
        return $this->request('accounts/{account_id}/buys', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_post_accounts_account_id_buys_buy_id_commit($params = array()) {
        return $this->request('accounts/{account_id}/buys/{buy_id}/commit', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_post_accounts_account_id_sells($params = array()) {
        return $this->request('accounts/{account_id}/sells', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_post_accounts_account_id_sells_sell_id_commit($params = array()) {
        return $this->request('accounts/{account_id}/sells/{sell_id}/commit', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_post_accounts_account_id_deposits($params = array()) {
        return $this->request('accounts/{account_id}/deposits', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_post_accounts_account_id_deposits_deposit_id_commit($params = array()) {
        return $this->request('accounts/{account_id}/deposits/{deposit_id}/commit', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_post_accounts_account_id_withdrawals($params = array()) {
        return $this->request('accounts/{account_id}/withdrawals', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_post_accounts_account_id_withdrawals_withdrawal_id_commit($params = array()) {
        return $this->request('accounts/{account_id}/withdrawals/{withdrawal_id}/commit', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_put_accounts_account_id($params = array()) {
        return $this->request('accounts/{account_id}', array('v2', 'private'), 'PUT', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_put_user($params = array()) {
        return $this->request('user', array('v2', 'private'), 'PUT', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_delete_accounts_id($params = array()) {
        return $this->request('accounts/{id}', array('v2', 'private'), 'DELETE', $params, null, null, array("cost" => 10.6));
    }
    public function v2_private_delete_accounts_account_id_transactions_transaction_id($params = array()) {
        return $this->request('accounts/{account_id}/transactions/{transaction_id}', array('v2', 'private'), 'DELETE', $params, null, null, array("cost" => 10.6));
    }
    public function v3_public_get_brokerage_time($params = array()) {
        return $this->request('brokerage/time', array('v3', 'public'), 'GET', $params, null, null, array("cost" => 3));
    }
    public function v3_private_get_brokerage_accounts($params = array()) {
        return $this->request('brokerage/accounts', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3_private_get_brokerage_accounts_account_uuid($params = array()) {
        return $this->request('brokerage/accounts/{account_uuid}', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3_private_get_brokerage_orders_historical_batch($params = array()) {
        return $this->request('brokerage/orders/historical/batch', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3_private_get_brokerage_orders_historical_fills($params = array()) {
        return $this->request('brokerage/orders/historical/fills', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3_private_get_brokerage_orders_historical_order_id($params = array()) {
        return $this->request('brokerage/orders/historical/{order_id}', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3_private_get_brokerage_products($params = array()) {
        return $this->request('brokerage/products', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 3));
    }
    public function v3_private_get_brokerage_products_product_id($params = array()) {
        return $this->request('brokerage/products/{product_id}', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 3));
    }
    public function v3_private_get_brokerage_products_product_id_candles($params = array()) {
        return $this->request('brokerage/products/{product_id}/candles', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 3));
    }
    public function v3_private_get_brokerage_products_product_id_ticker($params = array()) {
        return $this->request('brokerage/products/{product_id}/ticker', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 3));
    }
    public function v3_private_get_brokerage_best_bid_ask($params = array()) {
        return $this->request('brokerage/best_bid_ask', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 3));
    }
    public function v3_private_get_brokerage_product_book($params = array()) {
        return $this->request('brokerage/product_book', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 3));
    }
    public function v3_private_get_brokerage_transaction_summary($params = array()) {
        return $this->request('brokerage/transaction_summary', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 3));
    }
    public function v3_private_get_brokerage_portfolios($params = array()) {
        return $this->request('brokerage/portfolios', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3_private_get_brokerage_portfolios_portfolio_uuid($params = array()) {
        return $this->request('brokerage/portfolios/{portfolio_uuid}', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3_private_get_brokerage_convert_trade_trade_id($params = array()) {
        return $this->request('brokerage/convert/trade/{trade_id}', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3_private_get_brokerage_cfm_balance_summary($params = array()) {
        return $this->request('brokerage/cfm/balance_summary', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3_private_get_brokerage_cfm_positions($params = array()) {
        return $this->request('brokerage/cfm/positions', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3_private_get_brokerage_cfm_positions_product_id($params = array()) {
        return $this->request('brokerage/cfm/positions/{product_id}', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3_private_get_brokerage_cfm_sweeps($params = array()) {
        return $this->request('brokerage/cfm/sweeps', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3_private_get_brokerage_intx_portfolio_portfolio_uuid($params = array()) {
        return $this->request('brokerage/intx/portfolio/{portfolio_uuid}', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3_private_get_brokerage_intx_positions_portfolio_uuid($params = array()) {
        return $this->request('brokerage/intx/positions/{portfolio_uuid}', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3_private_get_brokerage_intx_positions_portfolio_uuid_symbol($params = array()) {
        return $this->request('brokerage/intx/positions/{portfolio_uuid}/{symbol}', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3_private_get_brokerage_payment_methods($params = array()) {
        return $this->request('brokerage/payment_methods', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3_private_get_brokerage_payment_methods_payment_method_id($params = array()) {
        return $this->request('brokerage/payment_methods/{payment_method_id}', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3_private_post_brokerage_orders($params = array()) {
        return $this->request('brokerage/orders', array('v3', 'private'), 'POST', $params, null, null, array("cost" => 1));
    }
    public function v3_private_post_brokerage_orders_batch_cancel($params = array()) {
        return $this->request('brokerage/orders/batch_cancel', array('v3', 'private'), 'POST', $params, null, null, array("cost" => 1));
    }
    public function v3_private_post_brokerage_orders_edit($params = array()) {
        return $this->request('brokerage/orders/edit', array('v3', 'private'), 'POST', $params, null, null, array("cost" => 1));
    }
    public function v3_private_post_brokerage_orders_edit_preview($params = array()) {
        return $this->request('brokerage/orders/edit_preview', array('v3', 'private'), 'POST', $params, null, null, array("cost" => 1));
    }
    public function v3_private_post_brokerage_orders_preview($params = array()) {
        return $this->request('brokerage/orders/preview', array('v3', 'private'), 'POST', $params, null, null, array("cost" => 1));
    }
    public function v3_private_post_brokerage_portfolios($params = array()) {
        return $this->request('brokerage/portfolios', array('v3', 'private'), 'POST', $params, null, null, array("cost" => 1));
    }
    public function v3_private_post_brokerage_portfolios_move_funds($params = array()) {
        return $this->request('brokerage/portfolios/move_funds', array('v3', 'private'), 'POST', $params, null, null, array("cost" => 1));
    }
    public function v3_private_post_brokerage_convert_quote($params = array()) {
        return $this->request('brokerage/convert/quote', array('v3', 'private'), 'POST', $params, null, null, array("cost" => 1));
    }
    public function v3_private_post_brokerage_convert_trade_trade_id($params = array()) {
        return $this->request('brokerage/convert/trade/{trade_id}', array('v3', 'private'), 'POST', $params, null, null, array("cost" => 1));
    }
    public function v3_private_post_brokerage_cfm_sweeps_schedule($params = array()) {
        return $this->request('brokerage/cfm/sweeps/schedule', array('v3', 'private'), 'POST', $params, null, null, array("cost" => 1));
    }
    public function v3_private_post_brokerage_intx_allocate($params = array()) {
        return $this->request('brokerage/intx/allocate', array('v3', 'private'), 'POST', $params, null, null, array("cost" => 1));
    }
    public function v3_private_put_brokerage_portfolios_portfolio_uuid($params = array()) {
        return $this->request('brokerage/portfolios/{portfolio_uuid}', array('v3', 'private'), 'PUT', $params, null, null, array("cost" => 1));
    }
    public function v3_private_delete_brokerage_portfolios_portfolio_uuid($params = array()) {
        return $this->request('brokerage/portfolios/{portfolio_uuid}', array('v3', 'private'), 'DELETE', $params, null, null, array("cost" => 1));
    }
    public function v3_private_delete_brokerage_cfm_sweeps($params = array()) {
        return $this->request('brokerage/cfm/sweeps', array('v3', 'private'), 'DELETE', $params, null, null, array("cost" => 1));
    }
    public function v2PublicGetCurrencies($params = array()) {
        return $this->request('currencies', array('v2', 'public'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PublicGetCurrenciesCrypto($params = array()) {
        return $this->request('currencies/crypto', array('v2', 'public'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PublicGetTime($params = array()) {
        return $this->request('time', array('v2', 'public'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PublicGetExchangeRates($params = array()) {
        return $this->request('exchange-rates', array('v2', 'public'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PublicGetUsersUserId($params = array()) {
        return $this->request('users/{user_id}', array('v2', 'public'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PublicGetPricesSymbolBuy($params = array()) {
        return $this->request('prices/{symbol}/buy', array('v2', 'public'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PublicGetPricesSymbolSell($params = array()) {
        return $this->request('prices/{symbol}/sell', array('v2', 'public'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PublicGetPricesSymbolSpot($params = array()) {
        return $this->request('prices/{symbol}/spot', array('v2', 'public'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivateGetAccounts($params = array()) {
        return $this->request('accounts', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivateGetAccountsAccountId($params = array()) {
        return $this->request('accounts/{account_id}', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivateGetAccountsAccountIdAddresses($params = array()) {
        return $this->request('accounts/{account_id}/addresses', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivateGetAccountsAccountIdAddressesAddressId($params = array()) {
        return $this->request('accounts/{account_id}/addresses/{address_id}', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivateGetAccountsAccountIdAddressesAddressIdTransactions($params = array()) {
        return $this->request('accounts/{account_id}/addresses/{address_id}/transactions', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivateGetAccountsAccountIdTransactions($params = array()) {
        return $this->request('accounts/{account_id}/transactions', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivateGetAccountsAccountIdTransactionsTransactionId($params = array()) {
        return $this->request('accounts/{account_id}/transactions/{transaction_id}', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivateGetAccountsAccountIdBuys($params = array()) {
        return $this->request('accounts/{account_id}/buys', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivateGetAccountsAccountIdBuysBuyId($params = array()) {
        return $this->request('accounts/{account_id}/buys/{buy_id}', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivateGetAccountsAccountIdSells($params = array()) {
        return $this->request('accounts/{account_id}/sells', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivateGetAccountsAccountIdSellsSellId($params = array()) {
        return $this->request('accounts/{account_id}/sells/{sell_id}', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivateGetAccountsAccountIdDeposits($params = array()) {
        return $this->request('accounts/{account_id}/deposits', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivateGetAccountsAccountIdDepositsDepositId($params = array()) {
        return $this->request('accounts/{account_id}/deposits/{deposit_id}', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivateGetAccountsAccountIdWithdrawals($params = array()) {
        return $this->request('accounts/{account_id}/withdrawals', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivateGetAccountsAccountIdWithdrawalsWithdrawalId($params = array()) {
        return $this->request('accounts/{account_id}/withdrawals/{withdrawal_id}', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivateGetPaymentMethods($params = array()) {
        return $this->request('payment-methods', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivateGetPaymentMethodsPaymentMethodId($params = array()) {
        return $this->request('payment-methods/{payment_method_id}', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivateGetUser($params = array()) {
        return $this->request('user', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivateGetUserAuth($params = array()) {
        return $this->request('user/auth', array('v2', 'private'), 'GET', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivatePostAccounts($params = array()) {
        return $this->request('accounts', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivatePostAccountsAccountIdPrimary($params = array()) {
        return $this->request('accounts/{account_id}/primary', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivatePostAccountsAccountIdAddresses($params = array()) {
        return $this->request('accounts/{account_id}/addresses', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivatePostAccountsAccountIdTransactions($params = array()) {
        return $this->request('accounts/{account_id}/transactions', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivatePostAccountsAccountIdTransactionsTransactionIdComplete($params = array()) {
        return $this->request('accounts/{account_id}/transactions/{transaction_id}/complete', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivatePostAccountsAccountIdTransactionsTransactionIdResend($params = array()) {
        return $this->request('accounts/{account_id}/transactions/{transaction_id}/resend', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivatePostAccountsAccountIdBuys($params = array()) {
        return $this->request('accounts/{account_id}/buys', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivatePostAccountsAccountIdBuysBuyIdCommit($params = array()) {
        return $this->request('accounts/{account_id}/buys/{buy_id}/commit', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivatePostAccountsAccountIdSells($params = array()) {
        return $this->request('accounts/{account_id}/sells', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivatePostAccountsAccountIdSellsSellIdCommit($params = array()) {
        return $this->request('accounts/{account_id}/sells/{sell_id}/commit', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivatePostAccountsAccountIdDeposits($params = array()) {
        return $this->request('accounts/{account_id}/deposits', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivatePostAccountsAccountIdDepositsDepositIdCommit($params = array()) {
        return $this->request('accounts/{account_id}/deposits/{deposit_id}/commit', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivatePostAccountsAccountIdWithdrawals($params = array()) {
        return $this->request('accounts/{account_id}/withdrawals', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivatePostAccountsAccountIdWithdrawalsWithdrawalIdCommit($params = array()) {
        return $this->request('accounts/{account_id}/withdrawals/{withdrawal_id}/commit', array('v2', 'private'), 'POST', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivatePutAccountsAccountId($params = array()) {
        return $this->request('accounts/{account_id}', array('v2', 'private'), 'PUT', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivatePutUser($params = array()) {
        return $this->request('user', array('v2', 'private'), 'PUT', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivateDeleteAccountsId($params = array()) {
        return $this->request('accounts/{id}', array('v2', 'private'), 'DELETE', $params, null, null, array("cost" => 10.6));
    }
    public function v2PrivateDeleteAccountsAccountIdTransactionsTransactionId($params = array()) {
        return $this->request('accounts/{account_id}/transactions/{transaction_id}', array('v2', 'private'), 'DELETE', $params, null, null, array("cost" => 10.6));
    }
    public function v3PublicGetBrokerageTime($params = array()) {
        return $this->request('brokerage/time', array('v3', 'public'), 'GET', $params, null, null, array("cost" => 3));
    }
    public function v3PrivateGetBrokerageAccounts($params = array()) {
        return $this->request('brokerage/accounts', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3PrivateGetBrokerageAccountsAccountUuid($params = array()) {
        return $this->request('brokerage/accounts/{account_uuid}', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3PrivateGetBrokerageOrdersHistoricalBatch($params = array()) {
        return $this->request('brokerage/orders/historical/batch', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3PrivateGetBrokerageOrdersHistoricalFills($params = array()) {
        return $this->request('brokerage/orders/historical/fills', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3PrivateGetBrokerageOrdersHistoricalOrderId($params = array()) {
        return $this->request('brokerage/orders/historical/{order_id}', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3PrivateGetBrokerageProducts($params = array()) {
        return $this->request('brokerage/products', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 3));
    }
    public function v3PrivateGetBrokerageProductsProductId($params = array()) {
        return $this->request('brokerage/products/{product_id}', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 3));
    }
    public function v3PrivateGetBrokerageProductsProductIdCandles($params = array()) {
        return $this->request('brokerage/products/{product_id}/candles', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 3));
    }
    public function v3PrivateGetBrokerageProductsProductIdTicker($params = array()) {
        return $this->request('brokerage/products/{product_id}/ticker', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 3));
    }
    public function v3PrivateGetBrokerageBestBidAsk($params = array()) {
        return $this->request('brokerage/best_bid_ask', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 3));
    }
    public function v3PrivateGetBrokerageProductBook($params = array()) {
        return $this->request('brokerage/product_book', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 3));
    }
    public function v3PrivateGetBrokerageTransactionSummary($params = array()) {
        return $this->request('brokerage/transaction_summary', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 3));
    }
    public function v3PrivateGetBrokeragePortfolios($params = array()) {
        return $this->request('brokerage/portfolios', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3PrivateGetBrokeragePortfoliosPortfolioUuid($params = array()) {
        return $this->request('brokerage/portfolios/{portfolio_uuid}', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3PrivateGetBrokerageConvertTradeTradeId($params = array()) {
        return $this->request('brokerage/convert/trade/{trade_id}', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3PrivateGetBrokerageCfmBalanceSummary($params = array()) {
        return $this->request('brokerage/cfm/balance_summary', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3PrivateGetBrokerageCfmPositions($params = array()) {
        return $this->request('brokerage/cfm/positions', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3PrivateGetBrokerageCfmPositionsProductId($params = array()) {
        return $this->request('brokerage/cfm/positions/{product_id}', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3PrivateGetBrokerageCfmSweeps($params = array()) {
        return $this->request('brokerage/cfm/sweeps', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3PrivateGetBrokerageIntxPortfolioPortfolioUuid($params = array()) {
        return $this->request('brokerage/intx/portfolio/{portfolio_uuid}', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3PrivateGetBrokerageIntxPositionsPortfolioUuid($params = array()) {
        return $this->request('brokerage/intx/positions/{portfolio_uuid}', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3PrivateGetBrokerageIntxPositionsPortfolioUuidSymbol($params = array()) {
        return $this->request('brokerage/intx/positions/{portfolio_uuid}/{symbol}', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3PrivateGetBrokeragePaymentMethods($params = array()) {
        return $this->request('brokerage/payment_methods', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3PrivateGetBrokeragePaymentMethodsPaymentMethodId($params = array()) {
        return $this->request('brokerage/payment_methods/{payment_method_id}', array('v3', 'private'), 'GET', $params, null, null, array("cost" => 1));
    }
    public function v3PrivatePostBrokerageOrders($params = array()) {
        return $this->request('brokerage/orders', array('v3', 'private'), 'POST', $params, null, null, array("cost" => 1));
    }
    public function v3PrivatePostBrokerageOrdersBatchCancel($params = array()) {
        return $this->request('brokerage/orders/batch_cancel', array('v3', 'private'), 'POST', $params, null, null, array("cost" => 1));
    }
    public function v3PrivatePostBrokerageOrdersEdit($params = array()) {
        return $this->request('brokerage/orders/edit', array('v3', 'private'), 'POST', $params, null, null, array("cost" => 1));
    }
    public function v3PrivatePostBrokerageOrdersEditPreview($params = array()) {
        return $this->request('brokerage/orders/edit_preview', array('v3', 'private'), 'POST', $params, null, null, array("cost" => 1));
    }
    public function v3PrivatePostBrokerageOrdersPreview($params = array()) {
        return $this->request('brokerage/orders/preview', array('v3', 'private'), 'POST', $params, null, null, array("cost" => 1));
    }
    public function v3PrivatePostBrokeragePortfolios($params = array()) {
        return $this->request('brokerage/portfolios', array('v3', 'private'), 'POST', $params, null, null, array("cost" => 1));
    }
    public function v3PrivatePostBrokeragePortfoliosMoveFunds($params = array()) {
        return $this->request('brokerage/portfolios/move_funds', array('v3', 'private'), 'POST', $params, null, null, array("cost" => 1));
    }
    public function v3PrivatePostBrokerageConvertQuote($params = array()) {
        return $this->request('brokerage/convert/quote', array('v3', 'private'), 'POST', $params, null, null, array("cost" => 1));
    }
    public function v3PrivatePostBrokerageConvertTradeTradeId($params = array()) {
        return $this->request('brokerage/convert/trade/{trade_id}', array('v3', 'private'), 'POST', $params, null, null, array("cost" => 1));
    }
    public function v3PrivatePostBrokerageCfmSweepsSchedule($params = array()) {
        return $this->request('brokerage/cfm/sweeps/schedule', array('v3', 'private'), 'POST', $params, null, null, array("cost" => 1));
    }
    public function v3PrivatePostBrokerageIntxAllocate($params = array()) {
        return $this->request('brokerage/intx/allocate', array('v3', 'private'), 'POST', $params, null, null, array("cost" => 1));
    }
    public function v3PrivatePutBrokeragePortfoliosPortfolioUuid($params = array()) {
        return $this->request('brokerage/portfolios/{portfolio_uuid}', array('v3', 'private'), 'PUT', $params, null, null, array("cost" => 1));
    }
    public function v3PrivateDeleteBrokeragePortfoliosPortfolioUuid($params = array()) {
        return $this->request('brokerage/portfolios/{portfolio_uuid}', array('v3', 'private'), 'DELETE', $params, null, null, array("cost" => 1));
    }
    public function v3PrivateDeleteBrokerageCfmSweeps($params = array()) {
        return $this->request('brokerage/cfm/sweeps', array('v3', 'private'), 'DELETE', $params, null, null, array("cost" => 1));
    }
}
