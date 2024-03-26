namespace ccxt.pro;

// PLEASE DO NOT EDIT THIS FILE, IT IS GENERATED AND WILL BE OVERWRITTEN:
// https://github.com/ccxt/ccxt/blob/master/CONTRIBUTING.md#how-to-contribute-code


public partial class binancecoinm { public binancecoinm(object args = null) : base(args) { } }
public partial class binancecoinm : binance
{
    public override object describe()
    {
        // eslint-disable-next-line new-cap
        var restInstance = new ccxt.binancecoinm();
        object restDescribe = restInstance.describe();
        object extended = this.deepExtend(base.describe(), restDescribe);
        return this.deepExtend(extended, new Dictionary<string, object>() {
            { "id", "binancecoinm" },
            { "name", "Binance COIN-M" },
            { "urls", new Dictionary<string, object>() {
                { "logo", "https://user-images.githubusercontent.com/1294454/117738721-668c8d80-b205-11eb-8c49-3fad84c4a07f.jpg" },
            } },
            { "options", new Dictionary<string, object>() {
                { "fetchMarkets", new List<object>() {"inverse"} },
                { "defaultSubType", "inverse" },
            } },
        });
    }
}
