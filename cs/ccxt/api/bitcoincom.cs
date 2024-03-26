// -------------------------------------------------------------------------------

// PLEASE DO NOT EDIT THIS FILE, IT IS GENERATED AND WILL BE OVERWRITTEN:
// https://github.com/ccxt/ccxt/blob/master/CONTRIBUTING.md#how-to-contribute-code

// -------------------------------------------------------------------------------

namespace ccxt;

public partial class bitcoincom : fmfwio
{
    public bitcoincom (object args = null): base(args) {}

    public async Task<object> publicGetPublicCurrency (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicCurrency",parameters);
    }

    public async Task<object> publicGetPublicCurrencyCurrency (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicCurrencyCurrency",parameters);
    }

    public async Task<object> publicGetPublicSymbol (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicSymbol",parameters);
    }

    public async Task<object> publicGetPublicSymbolSymbol (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicSymbolSymbol",parameters);
    }

    public async Task<object> publicGetPublicTicker (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicTicker",parameters);
    }

    public async Task<object> publicGetPublicTickerSymbol (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicTickerSymbol",parameters);
    }

    public async Task<object> publicGetPublicPriceRate (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicPriceRate",parameters);
    }

    public async Task<object> publicGetPublicPriceHistory (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicPriceHistory",parameters);
    }

    public async Task<object> publicGetPublicPriceTicker (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicPriceTicker",parameters);
    }

    public async Task<object> publicGetPublicPriceTickerSymbol (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicPriceTickerSymbol",parameters);
    }

    public async Task<object> publicGetPublicTrades (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicTrades",parameters);
    }

    public async Task<object> publicGetPublicTradesSymbol (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicTradesSymbol",parameters);
    }

    public async Task<object> publicGetPublicOrderbook (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicOrderbook",parameters);
    }

    public async Task<object> publicGetPublicOrderbookSymbol (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicOrderbookSymbol",parameters);
    }

    public async Task<object> publicGetPublicCandles (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicCandles",parameters);
    }

    public async Task<object> publicGetPublicCandlesSymbol (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicCandlesSymbol",parameters);
    }

    public async Task<object> publicGetPublicConvertedCandles (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicConvertedCandles",parameters);
    }

    public async Task<object> publicGetPublicConvertedCandlesSymbol (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicConvertedCandlesSymbol",parameters);
    }

    public async Task<object> publicGetPublicFuturesInfo (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicFuturesInfo",parameters);
    }

    public async Task<object> publicGetPublicFuturesInfoSymbol (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicFuturesInfoSymbol",parameters);
    }

    public async Task<object> publicGetPublicFuturesHistoryFunding (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicFuturesHistoryFunding",parameters);
    }

    public async Task<object> publicGetPublicFuturesHistoryFundingSymbol (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicFuturesHistoryFundingSymbol",parameters);
    }

    public async Task<object> publicGetPublicFuturesCandlesIndexPrice (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicFuturesCandlesIndexPrice",parameters);
    }

    public async Task<object> publicGetPublicFuturesCandlesIndexPriceSymbol (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicFuturesCandlesIndexPriceSymbol",parameters);
    }

    public async Task<object> publicGetPublicFuturesCandlesMarkPrice (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicFuturesCandlesMarkPrice",parameters);
    }

    public async Task<object> publicGetPublicFuturesCandlesMarkPriceSymbol (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicFuturesCandlesMarkPriceSymbol",parameters);
    }

    public async Task<object> publicGetPublicFuturesCandlesPremiumIndex (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicFuturesCandlesPremiumIndex",parameters);
    }

    public async Task<object> publicGetPublicFuturesCandlesPremiumIndexSymbol (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicFuturesCandlesPremiumIndexSymbol",parameters);
    }

    public async Task<object> publicGetPublicFuturesCandlesOpenInterest (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicFuturesCandlesOpenInterest",parameters);
    }

    public async Task<object> publicGetPublicFuturesCandlesOpenInterestSymbol (object parameters = null)
    {
        return await this.callAsync ("publicGetPublicFuturesCandlesOpenInterestSymbol",parameters);
    }

    public async Task<object> privateGetSpotBalance (object parameters = null)
    {
        return await this.callAsync ("privateGetSpotBalance",parameters);
    }

    public async Task<object> privateGetSpotBalanceCurrency (object parameters = null)
    {
        return await this.callAsync ("privateGetSpotBalanceCurrency",parameters);
    }

    public async Task<object> privateGetSpotOrder (object parameters = null)
    {
        return await this.callAsync ("privateGetSpotOrder",parameters);
    }

    public async Task<object> privateGetSpotOrderClientOrderId (object parameters = null)
    {
        return await this.callAsync ("privateGetSpotOrderClientOrderId",parameters);
    }

    public async Task<object> privateGetSpotFee (object parameters = null)
    {
        return await this.callAsync ("privateGetSpotFee",parameters);
    }

    public async Task<object> privateGetSpotFeeSymbol (object parameters = null)
    {
        return await this.callAsync ("privateGetSpotFeeSymbol",parameters);
    }

    public async Task<object> privateGetSpotHistoryOrder (object parameters = null)
    {
        return await this.callAsync ("privateGetSpotHistoryOrder",parameters);
    }

    public async Task<object> privateGetSpotHistoryTrade (object parameters = null)
    {
        return await this.callAsync ("privateGetSpotHistoryTrade",parameters);
    }

    public async Task<object> privateGetMarginAccount (object parameters = null)
    {
        return await this.callAsync ("privateGetMarginAccount",parameters);
    }

    public async Task<object> privateGetMarginAccountIsolatedSymbol (object parameters = null)
    {
        return await this.callAsync ("privateGetMarginAccountIsolatedSymbol",parameters);
    }

    public async Task<object> privateGetMarginAccountCrossCurrency (object parameters = null)
    {
        return await this.callAsync ("privateGetMarginAccountCrossCurrency",parameters);
    }

    public async Task<object> privateGetMarginOrder (object parameters = null)
    {
        return await this.callAsync ("privateGetMarginOrder",parameters);
    }

    public async Task<object> privateGetMarginOrderClientOrderId (object parameters = null)
    {
        return await this.callAsync ("privateGetMarginOrderClientOrderId",parameters);
    }

    public async Task<object> privateGetMarginConfig (object parameters = null)
    {
        return await this.callAsync ("privateGetMarginConfig",parameters);
    }

    public async Task<object> privateGetMarginHistoryOrder (object parameters = null)
    {
        return await this.callAsync ("privateGetMarginHistoryOrder",parameters);
    }

    public async Task<object> privateGetMarginHistoryTrade (object parameters = null)
    {
        return await this.callAsync ("privateGetMarginHistoryTrade",parameters);
    }

    public async Task<object> privateGetMarginHistoryPositions (object parameters = null)
    {
        return await this.callAsync ("privateGetMarginHistoryPositions",parameters);
    }

    public async Task<object> privateGetMarginHistoryClearing (object parameters = null)
    {
        return await this.callAsync ("privateGetMarginHistoryClearing",parameters);
    }

    public async Task<object> privateGetFuturesBalance (object parameters = null)
    {
        return await this.callAsync ("privateGetFuturesBalance",parameters);
    }

    public async Task<object> privateGetFuturesBalanceCurrency (object parameters = null)
    {
        return await this.callAsync ("privateGetFuturesBalanceCurrency",parameters);
    }

    public async Task<object> privateGetFuturesAccount (object parameters = null)
    {
        return await this.callAsync ("privateGetFuturesAccount",parameters);
    }

    public async Task<object> privateGetFuturesAccountIsolatedSymbol (object parameters = null)
    {
        return await this.callAsync ("privateGetFuturesAccountIsolatedSymbol",parameters);
    }

    public async Task<object> privateGetFuturesOrder (object parameters = null)
    {
        return await this.callAsync ("privateGetFuturesOrder",parameters);
    }

    public async Task<object> privateGetFuturesOrderClientOrderId (object parameters = null)
    {
        return await this.callAsync ("privateGetFuturesOrderClientOrderId",parameters);
    }

    public async Task<object> privateGetFuturesConfig (object parameters = null)
    {
        return await this.callAsync ("privateGetFuturesConfig",parameters);
    }

    public async Task<object> privateGetFuturesFee (object parameters = null)
    {
        return await this.callAsync ("privateGetFuturesFee",parameters);
    }

    public async Task<object> privateGetFuturesFeeSymbol (object parameters = null)
    {
        return await this.callAsync ("privateGetFuturesFeeSymbol",parameters);
    }

    public async Task<object> privateGetFuturesHistoryOrder (object parameters = null)
    {
        return await this.callAsync ("privateGetFuturesHistoryOrder",parameters);
    }

    public async Task<object> privateGetFuturesHistoryTrade (object parameters = null)
    {
        return await this.callAsync ("privateGetFuturesHistoryTrade",parameters);
    }

    public async Task<object> privateGetFuturesHistoryPositions (object parameters = null)
    {
        return await this.callAsync ("privateGetFuturesHistoryPositions",parameters);
    }

    public async Task<object> privateGetFuturesHistoryClearing (object parameters = null)
    {
        return await this.callAsync ("privateGetFuturesHistoryClearing",parameters);
    }

    public async Task<object> privateGetWalletBalance (object parameters = null)
    {
        return await this.callAsync ("privateGetWalletBalance",parameters);
    }

    public async Task<object> privateGetWalletBalanceCurrency (object parameters = null)
    {
        return await this.callAsync ("privateGetWalletBalanceCurrency",parameters);
    }

    public async Task<object> privateGetWalletCryptoAddress (object parameters = null)
    {
        return await this.callAsync ("privateGetWalletCryptoAddress",parameters);
    }

    public async Task<object> privateGetWalletCryptoAddressRecentDeposit (object parameters = null)
    {
        return await this.callAsync ("privateGetWalletCryptoAddressRecentDeposit",parameters);
    }

    public async Task<object> privateGetWalletCryptoAddressRecentWithdraw (object parameters = null)
    {
        return await this.callAsync ("privateGetWalletCryptoAddressRecentWithdraw",parameters);
    }

    public async Task<object> privateGetWalletCryptoAddressCheckMine (object parameters = null)
    {
        return await this.callAsync ("privateGetWalletCryptoAddressCheckMine",parameters);
    }

    public async Task<object> privateGetWalletTransactions (object parameters = null)
    {
        return await this.callAsync ("privateGetWalletTransactions",parameters);
    }

    public async Task<object> privateGetWalletTransactionsTxId (object parameters = null)
    {
        return await this.callAsync ("privateGetWalletTransactionsTxId",parameters);
    }

    public async Task<object> privateGetWalletCryptoFeeEstimate (object parameters = null)
    {
        return await this.callAsync ("privateGetWalletCryptoFeeEstimate",parameters);
    }

    public async Task<object> privateGetWalletAirdrops (object parameters = null)
    {
        return await this.callAsync ("privateGetWalletAirdrops",parameters);
    }

    public async Task<object> privateGetWalletAmountLocks (object parameters = null)
    {
        return await this.callAsync ("privateGetWalletAmountLocks",parameters);
    }

    public async Task<object> privateGetSubAccount (object parameters = null)
    {
        return await this.callAsync ("privateGetSubAccount",parameters);
    }

    public async Task<object> privateGetSubAccountAcl (object parameters = null)
    {
        return await this.callAsync ("privateGetSubAccountAcl",parameters);
    }

    public async Task<object> privateGetSubAccountBalanceSubAccID (object parameters = null)
    {
        return await this.callAsync ("privateGetSubAccountBalanceSubAccID",parameters);
    }

    public async Task<object> privateGetSubAccountCryptoAddressSubAccIDCurrency (object parameters = null)
    {
        return await this.callAsync ("privateGetSubAccountCryptoAddressSubAccIDCurrency",parameters);
    }

    public async Task<object> privatePostSpotOrder (object parameters = null)
    {
        return await this.callAsync ("privatePostSpotOrder",parameters);
    }

    public async Task<object> privatePostSpotOrderList (object parameters = null)
    {
        return await this.callAsync ("privatePostSpotOrderList",parameters);
    }

    public async Task<object> privatePostMarginOrder (object parameters = null)
    {
        return await this.callAsync ("privatePostMarginOrder",parameters);
    }

    public async Task<object> privatePostMarginOrderList (object parameters = null)
    {
        return await this.callAsync ("privatePostMarginOrderList",parameters);
    }

    public async Task<object> privatePostFuturesOrder (object parameters = null)
    {
        return await this.callAsync ("privatePostFuturesOrder",parameters);
    }

    public async Task<object> privatePostFuturesOrderList (object parameters = null)
    {
        return await this.callAsync ("privatePostFuturesOrderList",parameters);
    }

    public async Task<object> privatePostWalletCryptoAddress (object parameters = null)
    {
        return await this.callAsync ("privatePostWalletCryptoAddress",parameters);
    }

    public async Task<object> privatePostWalletCryptoWithdraw (object parameters = null)
    {
        return await this.callAsync ("privatePostWalletCryptoWithdraw",parameters);
    }

    public async Task<object> privatePostWalletConvert (object parameters = null)
    {
        return await this.callAsync ("privatePostWalletConvert",parameters);
    }

    public async Task<object> privatePostWalletTransfer (object parameters = null)
    {
        return await this.callAsync ("privatePostWalletTransfer",parameters);
    }

    public async Task<object> privatePostWalletInternalWithdraw (object parameters = null)
    {
        return await this.callAsync ("privatePostWalletInternalWithdraw",parameters);
    }

    public async Task<object> privatePostWalletCryptoCheckOffchainAvailable (object parameters = null)
    {
        return await this.callAsync ("privatePostWalletCryptoCheckOffchainAvailable",parameters);
    }

    public async Task<object> privatePostWalletCryptoFeesEstimate (object parameters = null)
    {
        return await this.callAsync ("privatePostWalletCryptoFeesEstimate",parameters);
    }

    public async Task<object> privatePostWalletAirdropsIdClaim (object parameters = null)
    {
        return await this.callAsync ("privatePostWalletAirdropsIdClaim",parameters);
    }

    public async Task<object> privatePostSubAccountFreeze (object parameters = null)
    {
        return await this.callAsync ("privatePostSubAccountFreeze",parameters);
    }

    public async Task<object> privatePostSubAccountActivate (object parameters = null)
    {
        return await this.callAsync ("privatePostSubAccountActivate",parameters);
    }

    public async Task<object> privatePostSubAccountTransfer (object parameters = null)
    {
        return await this.callAsync ("privatePostSubAccountTransfer",parameters);
    }

    public async Task<object> privatePostSubAccountAcl (object parameters = null)
    {
        return await this.callAsync ("privatePostSubAccountAcl",parameters);
    }

    public async Task<object> privatePatchSpotOrderClientOrderId (object parameters = null)
    {
        return await this.callAsync ("privatePatchSpotOrderClientOrderId",parameters);
    }

    public async Task<object> privatePatchMarginOrderClientOrderId (object parameters = null)
    {
        return await this.callAsync ("privatePatchMarginOrderClientOrderId",parameters);
    }

    public async Task<object> privatePatchFuturesOrderClientOrderId (object parameters = null)
    {
        return await this.callAsync ("privatePatchFuturesOrderClientOrderId",parameters);
    }

    public async Task<object> privateDeleteSpotOrder (object parameters = null)
    {
        return await this.callAsync ("privateDeleteSpotOrder",parameters);
    }

    public async Task<object> privateDeleteSpotOrderClientOrderId (object parameters = null)
    {
        return await this.callAsync ("privateDeleteSpotOrderClientOrderId",parameters);
    }

    public async Task<object> privateDeleteMarginPosition (object parameters = null)
    {
        return await this.callAsync ("privateDeleteMarginPosition",parameters);
    }

    public async Task<object> privateDeleteMarginPositionIsolatedSymbol (object parameters = null)
    {
        return await this.callAsync ("privateDeleteMarginPositionIsolatedSymbol",parameters);
    }

    public async Task<object> privateDeleteMarginOrder (object parameters = null)
    {
        return await this.callAsync ("privateDeleteMarginOrder",parameters);
    }

    public async Task<object> privateDeleteMarginOrderClientOrderId (object parameters = null)
    {
        return await this.callAsync ("privateDeleteMarginOrderClientOrderId",parameters);
    }

    public async Task<object> privateDeleteFuturesPosition (object parameters = null)
    {
        return await this.callAsync ("privateDeleteFuturesPosition",parameters);
    }

    public async Task<object> privateDeleteFuturesPositionMarginModeSymbol (object parameters = null)
    {
        return await this.callAsync ("privateDeleteFuturesPositionMarginModeSymbol",parameters);
    }

    public async Task<object> privateDeleteFuturesOrder (object parameters = null)
    {
        return await this.callAsync ("privateDeleteFuturesOrder",parameters);
    }

    public async Task<object> privateDeleteFuturesOrderClientOrderId (object parameters = null)
    {
        return await this.callAsync ("privateDeleteFuturesOrderClientOrderId",parameters);
    }

    public async Task<object> privateDeleteWalletCryptoWithdrawId (object parameters = null)
    {
        return await this.callAsync ("privateDeleteWalletCryptoWithdrawId",parameters);
    }

    public async Task<object> privatePutMarginAccountIsolatedSymbol (object parameters = null)
    {
        return await this.callAsync ("privatePutMarginAccountIsolatedSymbol",parameters);
    }

    public async Task<object> privatePutFuturesAccountIsolatedSymbol (object parameters = null)
    {
        return await this.callAsync ("privatePutFuturesAccountIsolatedSymbol",parameters);
    }

    public async Task<object> privatePutWalletCryptoWithdrawId (object parameters = null)
    {
        return await this.callAsync ("privatePutWalletCryptoWithdrawId",parameters);
    }

}