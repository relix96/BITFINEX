using BITFINEX.Class;
using BITFINEX.API;

API api = new API();

//Set parameters to call the API
int sort = 0;
int limit = 120;

while (true)
{
    // Get the Millisecond start time
    Int64 start = DateTimeOffset.UtcNow.AddHours(-1).ToUnixTimeMilliseconds();

    // Get the Millisecond end time
    Int64 end = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    List<Trade> trades = await api.GetTrades(limit, start.ToString(), end.ToString(), sort);
    Console.WriteLine("Name: BTC/EUR");
    Console.WriteLine($"Max Price: {trades[limit - 1].Price} EUR");
    Console.WriteLine($"Min Price: {trades[0].Price} EUR");
    Console.WriteLine($"Average Price:{Trade.CalculateAverage(trades, limit)} EUR \n");

    Thread.Sleep(10000);



}





