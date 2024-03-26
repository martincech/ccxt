// -------------------------------------------------------------------------------

// PLEASE DO NOT EDIT THIS FILE, IT IS GENERATED AND WILL BE OVERWRITTEN:
// https://github.com/ccxt/ccxt/blob/master/CONTRIBUTING.md#how-to-contribute-code

// -------------------------------------------------------------------------------

namespace ccxt;

public partial class bit2c : Exchange
{
    public bit2c (object args = null): base(args) {}

    public async Task<object> publicGetExchangesPairTicker (object parameters = null)
    {
        return await this.callAsync ("publicGetExchangesPairTicker",parameters);
    }

    public async Task<object> publicGetExchangesPairOrderbook (object parameters = null)
    {
        return await this.callAsync ("publicGetExchangesPairOrderbook",parameters);
    }

    public async Task<object> publicGetExchangesPairTrades (object parameters = null)
    {
        return await this.callAsync ("publicGetExchangesPairTrades",parameters);
    }

    public async Task<object> publicGetExchangesPairLasttrades (object parameters = null)
    {
        return await this.callAsync ("publicGetExchangesPairLasttrades",parameters);
    }

    public async Task<object> privatePostMerchantCreateCheckout (object parameters = null)
    {
        return await this.callAsync ("privatePostMerchantCreateCheckout",parameters);
    }

    public async Task<object> privatePostFundsAddCoinFundsRequest (object parameters = null)
    {
        return await this.callAsync ("privatePostFundsAddCoinFundsRequest",parameters);
    }

    public async Task<object> privatePostOrderAddFund (object parameters = null)
    {
        return await this.callAsync ("privatePostOrderAddFund",parameters);
    }

    public async Task<object> privatePostOrderAddOrder (object parameters = null)
    {
        return await this.callAsync ("privatePostOrderAddOrder",parameters);
    }

    public async Task<object> privatePostOrderGetById (object parameters = null)
    {
        return await this.callAsync ("privatePostOrderGetById",parameters);
    }

    public async Task<object> privatePostOrderAddOrderMarketPriceBuy (object parameters = null)
    {
        return await this.callAsync ("privatePostOrderAddOrderMarketPriceBuy",parameters);
    }

    public async Task<object> privatePostOrderAddOrderMarketPriceSell (object parameters = null)
    {
        return await this.callAsync ("privatePostOrderAddOrderMarketPriceSell",parameters);
    }

    public async Task<object> privatePostOrderCancelOrder (object parameters = null)
    {
        return await this.callAsync ("privatePostOrderCancelOrder",parameters);
    }

    public async Task<object> privatePostOrderAddCoinFundsRequest (object parameters = null)
    {
        return await this.callAsync ("privatePostOrderAddCoinFundsRequest",parameters);
    }

    public async Task<object> privatePostOrderAddStopOrder (object parameters = null)
    {
        return await this.callAsync ("privatePostOrderAddStopOrder",parameters);
    }

    public async Task<object> privatePostPaymentGetMyId (object parameters = null)
    {
        return await this.callAsync ("privatePostPaymentGetMyId",parameters);
    }

    public async Task<object> privatePostPaymentSend (object parameters = null)
    {
        return await this.callAsync ("privatePostPaymentSend",parameters);
    }

    public async Task<object> privatePostPaymentPay (object parameters = null)
    {
        return await this.callAsync ("privatePostPaymentPay",parameters);
    }

    public async Task<object> privateGetAccountBalance (object parameters = null)
    {
        return await this.callAsync ("privateGetAccountBalance",parameters);
    }

    public async Task<object> privateGetAccountBalanceV2 (object parameters = null)
    {
        return await this.callAsync ("privateGetAccountBalanceV2",parameters);
    }

    public async Task<object> privateGetOrderMyOrders (object parameters = null)
    {
        return await this.callAsync ("privateGetOrderMyOrders",parameters);
    }

    public async Task<object> privateGetOrderGetById (object parameters = null)
    {
        return await this.callAsync ("privateGetOrderGetById",parameters);
    }

    public async Task<object> privateGetOrderAccountHistory (object parameters = null)
    {
        return await this.callAsync ("privateGetOrderAccountHistory",parameters);
    }

    public async Task<object> privateGetOrderOrderHistory (object parameters = null)
    {
        return await this.callAsync ("privateGetOrderOrderHistory",parameters);
    }

}