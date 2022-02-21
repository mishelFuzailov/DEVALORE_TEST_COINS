using DEVALORE_TEST_COINS.Utils.DataUtils;

namespace DEVALORE_TEST_COINS.Utils
{
    public class MockDataUtils : IDataUtils
    {
        private GetData gd;
        private string path;
        public MockDataUtils(GetData gd, string path)
        {
            this.gd = gd;
            this.path = path;
        }
        public dynamic GetData()
        {
            return this.gd.GetDataFromFile(this.path);
        }
    }
}
