using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITFINEX.Class
{
    [Serializable]
    public class Trade
    {        
        public int Id { get; set; }
        public Int64 Mts { get; set ; }
        public float Amount { get ; set; }
        public float Price { get ; set ; }
        public float Rate { get ; set ; }
        public Int64 Period { get; set ; }
        

        public Trade() { }

        /// <summary>
        /// Calculate the average prices of the price trades.
        /// </summary>
        /// <param name="trades"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static float CalculateAverage(List<Trade> trades, int limit)
        {
            float average = 0;
            foreach (Trade t in trades)
            {
                average += t.Price;
            }
            return average / limit;
        }

    }

  


}
