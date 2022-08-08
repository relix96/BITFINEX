using System;
using BITFINEX.Class;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace BITFINEX.API
{
    public class API
    {
        /// <summary>
        /// Gets a list of BTC/EUR trades for the last hour.
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public async Task<List<Trade>> GetTrades(int limit, string start, string end, int sort)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api-pub.bitfinex.com/v2/trades/tBTCEUR/hist?limit={limit}&start={start}&end={end}&sort={sort}"),

            };

            using (var response = await client.SendAsync(request))
            {
                try
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string body = await response.Content.ReadAsStringAsync();

                        if (!string.IsNullOrEmpty(body))
                        {
                            JArray tradesJson = (JArray)JsonConvert.DeserializeObject(body);
                            return GetTradeList(tradesJson);
                        }

                        else
                        {
                            Console.WriteLine("No trades were found!"); 
                            return null;
                        }
                    }
                    else return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

            }


        }
        /// <summary>
        /// Received a JArray and returns a List<Trade> order by price.
        /// </summary>
        /// <param name="tradesJSON"></param>
        /// <returns></returns>
        private List<Trade> GetTradeList(JArray tradesJSON)
        {
            List<Trade> trades = new List<Trade>();

            try
            {
                trades = tradesJSON.AsEnumerable().Select(t => new Trade() { Id = (int)t[0], Mts = (Int64)t[1], Amount = (float)t[2], Price = (float)t[3] }).ToList();
          
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return trades;
        }
    }
}