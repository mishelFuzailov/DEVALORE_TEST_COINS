using DEVALORE_TEST_COINS.Models;
using DEVALORE_TEST_COINS.Resp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DEVALORE_TEST_COINS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CoinsController : ControllerBase
    {
        CoinsUtils cu;
        public CoinsController() {
            string ProdOrDev = "Prod";
            this.cu = new CoinsUtils();
        }

        [HttpGet]
        public List<Coin> GetLowerRateCoins(double rate)
        {
            return this.cu.Lower_Rates(rate);
        }


    }
}
