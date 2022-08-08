using BITFINEX.Class;
using BITFINEX.API;

API api = new API();

//Set parameters to call the API
int sort = 0;
int limit = 10000;

while (true)
{
    // Get the Millisecond start time
    Int64 start = DateTimeOffset.Now.AddHours(-1).ToUnixTimeMilliseconds();

    // Get the Millisecond end time
    Int64 end = DateTimeOffset.Now.ToUnixTimeMilliseconds();

    List<Trade> trades = await api.GetTrades(limit, start.ToString(), end.ToString(), sort);
    Console.WriteLine("Name: BTC/EUR");
    Console.WriteLine($"Max Price: {Trade.getMax(trades)} EUR");
    Console.WriteLine($"Min Price: {Trade.getMin(trades)} EUR");
    Console.WriteLine($"Average Price:{Trade.CalculateAverage(trades)} EUR \n");

    Thread.Sleep(10000);



}





