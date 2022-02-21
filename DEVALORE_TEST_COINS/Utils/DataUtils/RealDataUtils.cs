using DEVALORE_TEST_COINS.Utils.DataUtils;
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
namespace DEVALORE_TEST_COINS.Utils
{
    public class RealDataUtils : IDataUtils
    {
        GetData gd;
        private string base_url;
        private string api_key;
        public RealDataUtils(GetData gd, string base_url, string api_key)
        {
            this.gd = gd;
            this.base_url = base_url;
            this.api_key = api_key;
        }

        public dynamic GetData()
        {
            return this.gd.GetDataFromApi(this.base_url, this.api_key);
        }
    }
}
