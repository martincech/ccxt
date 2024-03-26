using ccxt;
namespace Tests;

// PLEASE DO NOT EDIT THIS FILE, IT IS GENERATED AND WILL BE OVERWRITTEN:
// https://github.com/ccxt/ccxt/blob/master/CONTRIBUTING.md#how-to-contribute-code


public partial class testMainClass : BaseTest
{
    async static public Task testSignIn(Exchange exchange, object skippedProperties)
    {
        object method = "signIn";
        if (isTrue(getValue(exchange.has, method)))
        {
            await exchange.signIn();
        }
    }

}