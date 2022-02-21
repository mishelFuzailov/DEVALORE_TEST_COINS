using System.Collections.Generic;
using DEVALORE_TEST_COINS.Models;
using DEVALORE_TEST_COINS.Utils;
using DEVALORE_TEST_COINS.Utils.DataUtils;

namespace DEVALORE_TEST_COINS.Resp
{
    // This class include all functions for coins api
    public class CoinsUtils
    {
        GetData gd;
        IDataUtils dataUtils;
        WriteToLog wtl;

        public CoinsUtils(string ProdOrDev = "Prod") { 
            this.gd = new GetData();
            if (ProdOrDev == "Prod") {
                string base_url = $"http://api.exchangeratesapi.io/v1/latest";
                string key = "b1e104a203992a1a9c89a232a6dc4d22";
                this.dataUtils = new RealDataUtils(gd, base_url, key); 
            }
            else {
                string path = @"C:\Users\mishe\source\repos\DEVALORE_TEST_COINS\DEVALORE_TEST_COINS\MockData.json";
                this.dataUtils = new MockDataUtils(gd, path); 
            }
            this.wtl = new WriteToLog("log.txt");
        }

        public List<Coin> getData()
        {
            dynamic data = this.dataUtils.GetData();

            List<Coin> all_coins = new List<Coin>();
            foreach (dynamic item in data)
            {
                all_coins.Add(new Coin { Symbol = item.Name, Rate = item.Value});
            }
            return all_coins;
        }

        public List<Coin> Lower_Rates(double rate)
        {
            // create new list for ret
            List<Coin> lower_rates = new List<Coin>();
            // get all coins
            List<Coin> all_coins = getData();
            foreach (Coin coin in all_coins)
            {
                if (coin.Rate < rate) { lower_rates.Add(coin);}
            }

            // write to log
            this.wtl.Log(CreateLogMessage(rate, lower_rates.Count));

            return lower_rates;
        }

        public string CreateLogMessage(double rate, int num_of_coins)
        {
            string message = string.Empty;
            message += "Rate Value: " + rate.ToString() + "\n";
            message += "Num of coins returned: " + num_of_coins.ToString();
            return message;
        } 
    }
}
