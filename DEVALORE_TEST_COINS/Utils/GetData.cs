using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Windows;
using DEVALORE_TEST_COINS.Models;
using System.IO;

namespace DEVALORE_TEST_COINS.Utils
{
    public class GetData
    {
        public GetData() { }
        public dynamic GetDataFromApi (string base_url, string api_key=null)
        {
            var URL = new UriBuilder(base_url);
            var query = HttpUtility.ParseQueryString(string.Empty);

            // if there is a key
            if (api_key != null)
            {
                query["access_key"] = api_key;
            }

            URL.Query = query.ToString();
            var client = new WebClient();
            client.Headers.Add("Accepts", "application/json");
            client.Headers.Add("Accept", "application/json");
            string json = client.DownloadString(URL.ToString());
            dynamic data = JValue.Parse(json);

            return data.rates;
        }

        public dynamic GetDataFromFile(string file_name)
        {
            dynamic data = JValue.Parse(File.ReadAllText(file_name));
            return data.rates;
        }
    }
}
