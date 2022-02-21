# DEVALORE_TEST_COINS

flow : 
CoinsUtils  create a specific object of IDataUtils (RealDataUtils or MockDataUtils) according to the string ProdOrDev in the constructor,
and insert to it a new object of GetData.
I seperated the classes GetData and IDataUtils in case we need to implement another way for "GetData" in IDataUtils.

then, the controller activate the function Lower_Rates in CoinsUtils and this activate getData() method in CoinsUtils that get data from IDataUtils and insert
it into list of coins. (list of coins is a specific way to seperate json, so I used it in CoinsUtils).
after get the data, Lower_Rates checks the coins with lower rate than the parameter rate and return list of these coins. 
