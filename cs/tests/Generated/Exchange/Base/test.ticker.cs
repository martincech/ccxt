using ccxt;
namespace Tests;

// PLEASE DO NOT EDIT THIS FILE, IT IS GENERATED AND WILL BE OVERWRITTEN:
// https://github.com/ccxt/ccxt/blob/master/CONTRIBUTING.md#how-to-contribute-code


public partial class testMainClass : BaseTest
{
    public static void testTicker(Exchange exchange, object skippedProperties, object method, object entry, object symbol)
    {
        object format = new Dictionary<string, object>() {
            { "info", new Dictionary<string, object>() {} },
            { "symbol", "ETH/BTC" },
            { "timestamp", 1502962946216 },
            { "datetime", "2017-09-01T00:00:00" },
            { "high", exchange.parseNumber("1.234") },
            { "low", exchange.parseNumber("1.234") },
            { "bid", exchange.parseNumber("1.234") },
            { "bidVolume", exchange.parseNumber("1.234") },
            { "ask", exchange.parseNumber("1.234") },
            { "askVolume", exchange.parseNumber("1.234") },
            { "vwap", exchange.parseNumber("1.234") },
            { "open", exchange.parseNumber("1.234") },
            { "close", exchange.parseNumber("1.234") },
            { "last", exchange.parseNumber("1.234") },
            { "previousClose", exchange.parseNumber("1.234") },
            { "change", exchange.parseNumber("1.234") },
            { "percentage", exchange.parseNumber("1.234") },
            { "average", exchange.parseNumber("1.234") },
            { "baseVolume", exchange.parseNumber("1.234") },
            { "quoteVolume", exchange.parseNumber("1.234") },
        };
        // todo: atm, many exchanges fail, so temporarily decrease stict mode
        object emptyAllowedFor = new List<object>() {"timestamp", "datetime", "open", "high", "low", "close", "last", "baseVolume", "quoteVolume", "previousClose", "vwap", "change", "percentage", "average"};
        // trick csharp-transpiler for string
        if (!isTrue(((object)method).ToString().Contains("BidsAsks")))
        {
            ((IList<object>)emptyAllowedFor).Add("bid");
            ((IList<object>)emptyAllowedFor).Add("ask");
            ((IList<object>)emptyAllowedFor).Add("bidVolume");
            ((IList<object>)emptyAllowedFor).Add("askVolume");
        }
        testSharedMethods.assertStructure(exchange, skippedProperties, method, entry, format, emptyAllowedFor);
        testSharedMethods.assertTimestampAndDatetime(exchange, skippedProperties, method, entry);
        object logText = testSharedMethods.logTemplate(exchange, method, entry);
        //
        testSharedMethods.assertGreater(exchange, skippedProperties, method, entry, "open", "0");
        testSharedMethods.assertGreater(exchange, skippedProperties, method, entry, "high", "0");
        testSharedMethods.assertGreater(exchange, skippedProperties, method, entry, "low", "0");
        testSharedMethods.assertGreater(exchange, skippedProperties, method, entry, "close", "0");
        testSharedMethods.assertGreater(exchange, skippedProperties, method, entry, "ask", "0");
        testSharedMethods.assertGreaterOrEqual(exchange, skippedProperties, method, entry, "askVolume", "0");
        testSharedMethods.assertGreater(exchange, skippedProperties, method, entry, "bid", "0");
        testSharedMethods.assertGreaterOrEqual(exchange, skippedProperties, method, entry, "bidVolume", "0");
        testSharedMethods.assertGreater(exchange, skippedProperties, method, entry, "vwap", "0");
        testSharedMethods.assertGreater(exchange, skippedProperties, method, entry, "average", "0");
        testSharedMethods.assertGreaterOrEqual(exchange, skippedProperties, method, entry, "baseVolume", "0");
        testSharedMethods.assertGreaterOrEqual(exchange, skippedProperties, method, entry, "quoteVolume", "0");
        object lastString = exchange.safeString(entry, "last");
        object closeString = exchange.safeString(entry, "close");
        assert(isTrue((isTrue((isEqual(closeString, null))) && isTrue((isEqual(lastString, null))))) || isTrue(Precise.stringEq(lastString, closeString)), add("`last` != `close`", logText));
        object baseVolume = exchange.safeString(entry, "baseVolume");
        object quoteVolume = exchange.safeString(entry, "quoteVolume");
        object high = exchange.safeString(entry, "high");
        object low = exchange.safeString(entry, "low");
        if (isTrue(!isTrue((inOp(skippedProperties, "quoteVolume"))) && !isTrue((inOp(skippedProperties, "baseVolume")))))
        {
            if (isTrue(isTrue(isTrue(isTrue((!isEqual(baseVolume, null))) && isTrue((!isEqual(quoteVolume, null)))) && isTrue((!isEqual(high, null)))) && isTrue((!isEqual(low, null)))))
            {
                assert(Precise.stringGe(quoteVolume, Precise.stringMul(baseVolume, low)), add("quoteVolume >= baseVolume * low", logText));
                assert(Precise.stringLe(quoteVolume, Precise.stringMul(baseVolume, high)), add("quoteVolume <= baseVolume * high", logText));
            }
        }
        object vwap = exchange.safeString(entry, "vwap");
        if (isTrue(!isEqual(vwap, null)))
        {
            // todo
            // assert (high !== undefined, 'vwap is defined, but high is not' + logText);
            // assert (low !== undefined, 'vwap is defined, but low is not' + logText);
            // assert (vwap >= low && vwap <= high)
            assert(Precise.stringGe(vwap, "0"), add("vwap is not greater than zero", logText));
            if (isTrue(!isEqual(baseVolume, null)))
            {
                assert(!isEqual(quoteVolume, null), add("baseVolume & vwap is defined, but quoteVolume is not", logText));
            }
            if (isTrue(!isEqual(quoteVolume, null)))
            {
                assert(!isEqual(baseVolume, null), add("quoteVolume & vwap is defined, but baseVolume is not", logText));
            }
        }
        if (isTrue(isTrue(!isTrue((inOp(skippedProperties, "spread"))) && !isTrue((inOp(skippedProperties, "ask")))) && !isTrue((inOp(skippedProperties, "bid")))))
        {
            object askString = exchange.safeString(entry, "ask");
            object bidString = exchange.safeString(entry, "bid");
            if (isTrue(isTrue((!isEqual(askString, null))) && isTrue((!isEqual(bidString, null)))))
            {
                testSharedMethods.assertGreater(exchange, skippedProperties, method, entry, "ask", exchange.safeString(entry, "bid"));
            }
        }
        testSharedMethods.assertSymbol(exchange, skippedProperties, method, entry, "symbol", symbol);
    }

}