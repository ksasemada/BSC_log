using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSC_log
{
    public class Transaction
    {
        public string blockHash { get; set; }
        public string blockNumber { get; set; }
        public string from { get; set; }
        public string gas { get; set; }
        public string gasPrice { get; set; }
        public string hash { get; set; }
        public string Input { get; set; }
        public string nonce { get; set; }
        public string to { get; set; }
        public string transactionIndex { get; set; }
        public string value { get; set; }
        public string type { get; set; }
        public string v { get; set; }
        public string r { get; set; }
        public string s { get; set; }
    }
    public class Result_eth_getBlockByNumber_class
    {
        public string difficulty { get; set; }
        public string extraData { get; set; }
        public string gasLimit { get; set; }
        public string gasUsed { get; set; }
        public string hash { get; set; }
        public string logsBloom { get; set; }
        public string miner { get; set; }
        public string mixHash { get; set; }
        public string nonce { get; set; }
        public string number { get; set; }
        public string parentHash { get; set; }
        public string receiptsRoot { get; set; }
        public string sha3Uncles { get; set; }
        public string size { get; set; }
        public string stateRoot { get; set; }
        public string timestamp { get; set; }
        public string totalDifficulty { get; set; }
        public List<Transaction> transactions { get; set; }
        public string transactionsRoot { get; set; }
        public List<object> uncles { get; set; }
    }
    public class eth_getBlockByNumber_class
    {
        public string jsonrpc { get; set; }
        public int id { get; set; }
        public Result_eth_getBlockByNumber_class result { get; set; }
    }
    public class GetTransactionReceipt
    {
        public string logIndex { get; set; }
        public List<string> topics { get; set; }
        public string blockNumber { get; set; }
        public string transactionIndex { get; set; }
        public string blockHash { get; set; }
        public bool removed { get; set; }
        public string address { get; set; }
        public string data { get; set; }
        public string transactionHash { get; set; }
    }
    public class Result_getsourcecode
    {
        public string SourceCode { get; set; }
        public string ABI { get; set; }
        public string ContractName { get; set; }
        public string CompilerVersion { get; set; }
        public string OptimizationUsed { get; set; }
        public string Runs { get; set; }
        public string ConstructorArguments { get; set; }
        public string EVMVersion { get; set; }
        public string Library { get; set; }
        public string LicenseType { get; set; }
        public string Proxy { get; set; }
        public string Implementation { get; set; }
        public string SwarmSource { get; set; }
    }
    public class getsourcecode
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<Result_getsourcecode> result { get; set; }
    }
    public class Error
    {
        public int code { get; set; }
        public string data { get; set; }
        public string message { get; set; }
    }
    public class response_BscDataseedBinanceOrg_error
    {
        public string jsonrpc { get; set; }
        public int id { get; set; }
        public Error error { get; set; }
    }
    public class response_BscDataseedBinanceOrg
    {
        public string jsonrpc { get; set; }
        public int id { get; set; }
        public string result { get; set; }
    }
    public class honeypotStatus
    {
        public string status { get; set; }
    }
}
