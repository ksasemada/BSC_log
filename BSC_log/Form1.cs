using Nethereum.Util;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSC_log
{
    public partial class Form1 : Form
    {
        string bscscan_apikey = "";
        ToolStripLabel info_label_text;
        Nethereum.Web3.Web3 web3 = new Web3("https://bsc-dataseed.binance.org:443");
        Int32 block_kol = 0;
        Int32 token_kol = 0;
        string[] token_all_array = new string[5000000];

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView_edit();
            load_key_file();
        }
        private void start_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (start_checkBox.Checked)
            {
                online_timer.Enabled = true;
                block_number_info();
            }
            else
            {
                online_timer.Enabled = false;
            }
        }
        async void block_number_info() 
        {
            try
            {
                var block = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
                if (block != null)
                    if (scan_block_textBox.Text == "13618739")
                    {
                        scan_block_textBox.Text = block.ToString();
                        scan_block_end_textBox.Text = block.ToString();
                    }
                    else
                    {
                        scan_block_end_textBox.Text = block.ToString();
                    }
            }
            catch (Exception error)
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " " + "Error in block_number_info:" + error.Message);
            }
        }
        private void online_timer_Tick(object sender, EventArgs e)
        {
            block_number_info();
            if (scan_block_textBox.Text != scan_block_end_textBox.Text)
            {
                scan_block(Convert.ToInt32(scan_block_textBox.Text) + 1, Convert.ToInt32(scan_block_end_textBox.Text));
                scan_block_textBox.Text = scan_block_end_textBox.Text;
            }
        }
        private void scan_block_button_Click(object sender, EventArgs e) //Manual scan
        {
            scan_block(Convert.ToInt32(scan_block_textBox.Text), Convert.ToInt32(scan_block_end_textBox.Text));
        }
        async void scan_block(Int64 block, Int64 block_end)
        {
            //Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " scan_block:" + block + " " + block_end);
            try
            {
                for (Int64 num_block = block; num_block <= block_end; num_block++)
                {
                    int error_ = 0;
                e1:
                    var block_ = "0x" + (num_block).ToString("X");
                    var client = new RestClient("https://bsc-dataseed1.binance.org:443/");
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("Content-Type", "application/json");
                    var cancellationTokenSource = new CancellationTokenSource();
                    var body = @"{" + "\n" +
                    @"	""jsonrpc"":""2.0""," + "\n" +
                    @"	""method"":""eth_getBlockByNumber""," + "\n" +
                    @"	""params"":[" + "\n" +
                    @"		""" + block_ +
                    @""", " + "\n" +
                    @"		true" + "\n" +
                    @"	]," + "\n" +
                    @"	""id"":1" + "\n" +
                    @"}";
                    request.AddParameter("application/json", body, ParameterType.RequestBody);
                    var response =
                        await client.ExecuteAsync(request, cancellationTokenSource.Token);
                    var eth_getBlockByNumber_string = response.Content;
                    var eth_getBlockByNumber = JsonConvert.DeserializeObject<eth_getBlockByNumber_class>(eth_getBlockByNumber_string);
                    try
                    {
                        if (eth_getBlockByNumber.result == null)
                        {
                            error_++; if (error_ < 30)
                            {
                                await Task.Delay(300);
                                //Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " web3 scan_block:" + block + " " + "rescan");
                                goto e1;
                            }
                            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Error block: " + num_block);
                            goto exit_c;
                        }
                        block_kol++;
                        DateTime time_start = DateTime.Now;
                        foreach (Transaction list in eth_getBlockByNumber.result.transactions)
                        {
                            if (list.Input.ToString().Length > 10)
                            {
                                string MethodID = list.Input.ToString().Substring(0, 10);
                                //Console.WriteLine(MethodID);
                                processing(list, MethodID);
                                /*switch (MethodID)
                                {
                                    case "0xb6f9de95": //swapExactETHForTokensSupportingFeeOnTransferTokens
                                        Console.WriteLine("swapExactETHForTokensSupportingFeeOnTransferTokens");
                                        break;
                                    case "0x791ac947": //swapExactTokensForETHSupportingFeeOnTransferTokens
                                        Console.WriteLine("swapExactTokensForETHSupportingFeeOnTransferTokens");
                                        break;
                                    case "0x18cbafe5": //swapExactTokensForETH
                                        Console.WriteLine("swapExactTokensForETH");
                                        break;
                                    case "0x095ea7b3": //approve
                                        Console.WriteLine("approve");
                                        break;
                                    case "0xe8e33700": //addLiquidity
                                        Console.WriteLine("addLiquidity");
                                        break;
                                    case "0xf305d719": //addLiquidityETH
                                        Console.WriteLine("addLiquidityETH");
                                        break;
                                    case "0x0d295980": //tradingStatus
                                        Console.WriteLine("tradingStatus");
                                        break;
                                    case "0x8a8c523c": //enableTrading
                                        Console.WriteLine("enableTrading");
                                        break;
                                    case "0x7b9e987a": //SetupEnableTrading
                                        Console.WriteLine("SetupEnableTrading");
                                        break;
                                    case "0xfb201b1d": //setPrivateTradingStatus
                                        Console.WriteLine("setPrivateTradingStatus");
                                        break;
                                    case "0x64be5b39": //lock
                                        Console.WriteLine("lock");
                                        break;
                                    case "0x6167aa61": //lockTokens
                                        Console.WriteLine("lockTokens");
                                        break;
                                    case "0xe6a478b3": //lockTokens
                                        Console.WriteLine("lockTokens");
                                        break;
                                    case "0x5b0d5984": //removeLiquidityETHWithPermitSupportingFeeOnTransferTokens
                                        Console.WriteLine("removeLiquidityETHWithPermitSupportingFeeOnTransferTokens");
                                        break;
                                    case "0x2195995c": //removeLiquidityWithPermit
                                        Console.WriteLine("removeLiquidityWithPermit");
                                        break;
                                    default:
                                        Console.WriteLine(MethodID + " ???");
                                        break;
                                }*/
                            }
                        }
                        Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Current block " + num_block + " Time of processing:" + (DateTime.Now - time_start).ToString("ssfff") + "ms.");
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Error:" + error.Message);
                    }
                    info_update();
                exit_c: { }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Error in scan_block:" + error.Message);
            }
        }
        string token_address(Transaction list, string MethodID)
        {
            string token = "";
            if (((MethodID == "0xb6f9de95") | (MethodID == "0x7ff36ab5")) & (list.Input.ToString().Length > 40)) //buy token
            {

                token = "0x" + list.Input.ToString().Substring(list.Input.ToString().Length - 40, 40);
            }
            if (((MethodID == "0x791ac947") | (MethodID == "0x18cbafe5")) & (list.Input.ToString().Length > 458)) //sell token
            {
                token = "0x" + list.Input.ToString().Substring(64 * 7 - 30, 40);
            }
            if (MethodID == "0x095ea7b3")
            {
                token = list.to;
            }
            if (((MethodID == "0xe8e33700") | (MethodID == "0xf305d719")) & (list.Input.ToString().Length > 74))
            {
                token = "0x" + list.Input.ToString().Substring(34, 40);
            }
            if ((MethodID == "0x0d295980") | (MethodID == "0x8a8c523c") | (MethodID == "0x7b9e987a") | (MethodID == "0x6f73a4fe") | (MethodID == "0xfb201b1d"))
            {
                token = list.to.ToString();
            }
            if ((MethodID == "0x64be5b39") & (list.Input.ToString().Length > 138)) //lockTokens
            {
                token = "0x" + list.Input.ToString().Substring(98, 40);
            }
            if (((MethodID == "0x6167aa61") | (MethodID == "0xe6a478b3")) & (list.Input.ToString().Length > 74)) //lockTokens
            {
                token = "0x" + list.Input.ToString().Substring(34, 40);
            }
            if (((MethodID == "0x5b0d5984") | (MethodID == "0x2195995c")) & (list.Input.ToString().Length > 74)) //removeLiquidityETHWithPermitSupportingFeeOnTransferTokens or removeLiquidityWithPermit
            {
                token = "0x" + list.Input.ToString().Substring(34, 40);
            }
            return token;
        }
        void processing(Transaction list, string MethodID)
        {
            int num = 0;
            var token = token_address(list, MethodID);
            if (token != "")
            {
                for (Int32 a = 0; a < token_kol; a++)
                {
                    if (token_all_array[a] == token)
                    {
                        num = a;
                        goto end2;
                    }
                }
                dataGridView1.Rows.Add();
                token_all_array[token_kol] = token;
                dataGridView1.Rows[token_kol].Visible = false;
                dataGridView1.Rows[token_kol].Cells["num"].Value = token_kol + 1;
                dataGridView1.Rows[token_kol].Cells["time"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                dataGridView1.Rows[token_kol].Cells["name"].Value = "?????";
                dataGridView1.Rows[token_kol].Cells["adr"].Value = token;
                num = token_kol;
                token_kol++;
            }
        end2: { }
            analysis_transaction(list, MethodID, token, num);
        }
        void token_visible(Transaction list, string MethodID, string token, int num, bool visible)
        {
            if (visible) dataGridView1.Rows[num].Visible = true;
            load_data_token(token, list, num);
            load_contract_detals(list, MethodID, token, num);
            analysis_percent(token, list, num);
            //analysis_honeypotStatus(list, MethodID, token, num);
        }
        async void load_contract_detals(Transaction list, string MethodID, string token, int num)
        {
            DateTime time_vyp = DateTime.Now;
            var requestUri = "https://api.bscscan.com/api?module=contract&action=getsourcecode&address=" + token + "&apikey="+ bscscan_apikey;
            var client = new RestClient(requestUri);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var getsourcecode = JsonConvert.DeserializeObject<getsourcecode>(response.Content.ToString());
                var contract = getsourcecode.result[0].SourceCode.ToString();
                dataGridView1.Invoke(new Action(() => dataGridView1.Rows[num].Cells["vers"].Value = getsourcecode.result[0].CompilerVersion.ToString()));
                dataGridView1.Invoke(new Action(() => dataGridView1.Rows[num].Cells["vers_size"].Value = getsourcecode.result[0].SourceCode.ToString().Length.ToString()));
                dataGridView1.Invoke(new Action(() => dataGridView1.Rows[num].Cells["abi_size"].Value = getsourcecode.result[0].ABI.ToString().Length.ToString()));

                string telegram_link = "";
                if (contract.IndexOf("t.me") != -1)
                {
                    telegram_link = contract.Substring(contract.IndexOf("t.me"), 80);
                    int dl = telegram_link.Length;
                    if (telegram_link.IndexOf(" ") != -1) if (dl > telegram_link.IndexOf(" ")) dl = telegram_link.IndexOf(" ");
                    if (telegram_link.IndexOf("\n") != -1) if (dl > telegram_link.IndexOf("\n")) dl = telegram_link.IndexOf("\n");
                    if (telegram_link.IndexOf("\r") != -1) if (dl > telegram_link.IndexOf("\r")) dl = telegram_link.IndexOf("\r");
                    if (telegram_link.IndexOf("\\n") != -1) if (dl > telegram_link.IndexOf("\\n")) dl = telegram_link.IndexOf("\\n");
                    if (telegram_link.IndexOf("\\r") != -1) if (dl > telegram_link.IndexOf("\\r")) dl = telegram_link.IndexOf("\\r");
                    telegram_link = telegram_link.Substring(0, dl);
                    dataGridView1.Invoke(new Action(() => dataGridView1.Rows[num].Cells["telegram"].Value = telegram_link));
                    telegam_online(telegram_link, num);
                }
            }
        }
        void info_update()
        {
            info_label_text.Text = "Number of processed blocks:" + block_kol + ". Number of tokens in the database:" + token_kol;
        }
        async void load_data_token(string token, Transaction list, Int32 num)
        {
            const string abi = @"[{""inputs"":[{""internalType"":""string"",""name"":""name"",""type"":""string""},{""internalType"":""string"",""name"":""symbol"",""type"":""string""},{""internalType"":""uint256"",""name"":""initialBalance"",""type"":""uint256""},{""internalType"":""address payable"",""name"":""feeReceiver"",""type"":""address""}],""stateMutability"":""payable"",""type"":""constructor""},{""anonymous"":false,""inputs"":[{""indexed"":true,""internalType"":""address"",""name"":""owner"",""type"":""address""},{""indexed"":true,""internalType"":""address"",""name"":""spender"",""type"":""address""},{""indexed"":false,""internalType"":""uint256"",""name"":""value"",""type"":""uint256""}],""name"":""Approval"",""type"":""event""},{""anonymous"":false,""inputs"":[{""indexed"":true,""internalType"":""address"",""name"":""previousOwner"",""type"":""address""},{""indexed"":true,""internalType"":""address"",""name"":""newOwner"",""type"":""address""}],""name"":""OwnershipTransferred"",""type"":""event""},{""anonymous"":false,""inputs"":[{""indexed"":true,""internalType"":""address"",""name"":""from"",""type"":""address""},{""indexed"":true,""internalType"":""address"",""name"":""to"",""type"":""address""},{""indexed"":false,""internalType"":""uint256"",""name"":""value"",""type"":""uint256""}],""name"":""Transfer"",""type"":""event""},{""inputs"":[{""internalType"":""address"",""name"":""owner"",""type"":""address""},{""internalType"":""address"",""name"":""spender"",""type"":""address""}],""name"":""allowance"",""outputs"":[{""internalType"":""uint256"",""name"":"""",""type"":""uint256""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[{""internalType"":""address"",""name"":""spender"",""type"":""address""},{""internalType"":""uint256"",""name"":""amount"",""type"":""uint256""}],""name"":""approve"",""outputs"":[{""internalType"":""bool"",""name"":"""",""type"":""bool""}],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[{""internalType"":""address"",""name"":""account"",""type"":""address""}],""name"":""balanceOf"",""outputs"":[{""internalType"":""uint256"",""name"":"""",""type"":""uint256""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[],""name"":""decimals"",""outputs"":[{""internalType"":""uint8"",""name"":"""",""type"":""uint8""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[{""internalType"":""address"",""name"":""spender"",""type"":""address""},{""internalType"":""uint256"",""name"":""subtractedValue"",""type"":""uint256""}],""name"":""decreaseAllowance"",""outputs"":[{""internalType"":""bool"",""name"":"""",""type"":""bool""}],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[],""name"":""generator"",""outputs"":[{""internalType"":""string"",""name"":"""",""type"":""string""}],""stateMutability"":""pure"",""type"":""function""},{""inputs"":[],""name"":""getOwner"",""outputs"":[{""internalType"":""address"",""name"":"""",""type"":""address""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[{""internalType"":""address"",""name"":""spender"",""type"":""address""},{""internalType"":""uint256"",""name"":""addedValue"",""type"":""uint256""}],""name"":""increaseAllowance"",""outputs"":[{""internalType"":""bool"",""name"":"""",""type"":""bool""}],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[],""name"":""name"",""outputs"":[{""internalType"":""string"",""name"":"""",""type"":""string""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[],""name"":""owner"",""outputs"":[{""internalType"":""address"",""name"":"""",""type"":""address""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[],""name"":""renounceOwnership"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[],""name"":""symbol"",""outputs"":[{""internalType"":""string"",""name"":"""",""type"":""string""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[],""name"":""totalSupply"",""outputs"":[{""internalType"":""uint256"",""name"":"""",""type"":""uint256""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[{""internalType"":""address"",""name"":""recipient"",""type"":""address""},{""internalType"":""uint256"",""name"":""amount"",""type"":""uint256""}],""name"":""transfer"",""outputs"":[{""internalType"":""bool"",""name"":"""",""type"":""bool""}],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[{""internalType"":""address"",""name"":""sender"",""type"":""address""},{""internalType"":""address"",""name"":""recipient"",""type"":""address""},{""internalType"":""uint256"",""name"":""amount"",""type"":""uint256""}],""name"":""transferFrom"",""outputs"":[{""internalType"":""bool"",""name"":"""",""type"":""bool""}],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[{""internalType"":""address"",""name"":""newOwner"",""type"":""address""}],""name"":""transferOwnership"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[],""name"":""version"",""outputs"":[{""internalType"":""string"",""name"":"""",""type"":""string""}],""stateMutability"":""view"",""type"":""function""}]";
            try
            {
                var name_token = await web3.Eth.GetContract(abi, token).GetFunction("name").CallAsync<string>();
                dataGridView1.Rows[num].Cells["name"].Value = name_token;
            }
            catch (Exception error)
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " " + "Error in load_data_token:" + error.Message);
                dataGridView1.Rows[num].Cells["name"].Value = "error";
            }
            try
            {
                if (list != null)
                {
                    var req = web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(list.hash).Result;
                    if (req != null)
                    {
                        //Console.WriteLine("list:"+ list+" "+ list.hash);
                        if (req.Logs.Count != 0)
                        {
                            var adr_lp = JsonConvert.DeserializeObject<GetTransactionReceipt>(req.Logs.Last.ToString()).address.ToString();
                            dataGridView1.Rows[num].Cells["adr_lp"].Value = adr_lp;
                        }
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " " + "Error in adr_lp:" + error.Message);
                dataGridView1.Rows[num].Cells["adr_lp"].Value = "error";

            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells["cont_proc"].Selected) {dataGridView1.Rows[e.RowIndex].Cells["cont_proc"].Value = ""; analysis_percent(dataGridView1.Rows[e.RowIndex].Cells["adr"].EditedFormattedValue.ToString(), null, e.RowIndex); }

            if (dataGridView1.Rows[e.RowIndex].Cells["adr"].Selected)
            {
                using (Process process = new Process())
                { System.Diagnostics.Process.Start("chrome.exe", "https://poocoin.app/tokens/" + dataGridView1.Rows[e.RowIndex].Cells["adr"].EditedFormattedValue.ToString()); };
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["vers"].Selected) 
                using (Process process = new Process())
                {
                    System.Diagnostics.Process.Start("chrome.exe", "https://bscscan.com/address/" + dataGridView1.Rows[e.RowIndex].Cells["adr"].EditedFormattedValue.ToString() + "#code");
                };
            if (dataGridView1.Rows[e.RowIndex].Cells["vers_size"].Selected) 
                using (Process process = new Process())
                {
                    System.Diagnostics.Process.Start("chrome.exe", "https://bscscan.com/token/" + dataGridView1.Rows[e.RowIndex].Cells["adr"].EditedFormattedValue.ToString());
                };
            if (dataGridView1.Rows[e.RowIndex].Cells["telegram_online"].Selected) using (Process process = new Process())
                {
                    System.Diagnostics.Process.Start("chrome.exe", dataGridView1.Rows[e.RowIndex].Cells["telegram"].EditedFormattedValue.ToString());
                };
        }
    }
    public class dataGridView1 : DataGridView
    {
        public dataGridView1()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.DoubleBuffer |
              ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }
    }
}
