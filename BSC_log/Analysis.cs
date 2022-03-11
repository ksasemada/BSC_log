using Nethereum.Util;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Drawing;
using System.Globalization;
using System.Numerics;
using System.Threading;

namespace BSC_log
{
    public partial class Form1 
    {
        void analysis_liquidity(Transaction list, string MethodID, string token, int num)
        {
            if (MethodID == "0xf305d719")
            {
                double token_liq = (float)((Int64)(BigInteger.Parse(list.Input.ToString().Substring(226, 40), NumberStyles.HexNumber) / 10000000000000)) / 100000.0;
                BigInteger token_liqa = (BigInteger)((BigInteger)(BigInteger.Parse(list.Input.ToString().Substring(162, 40), NumberStyles.HexNumber) / 1000)) / 100000;
                dataGridView1.Rows[num].Cells["liq"].Value = token_liq.ToString("F2") + " BNB";
            }
            if (MethodID == "0xe8e33700")
            {
                var tokena = "0x" + list.Input.ToString().Substring(34, 40);
                var token_liq = "0x" + list.Input.ToString().Substring(98, 40);
                double tokena_liqa = (float)((Int64)(BigInteger.Parse(list.Input.ToString().Substring(162, 40), NumberStyles.HexNumber) / 10000000000000)) / 100000.0;
                double tokena_liq = (Int64)(BigInteger.Parse(list.Input.ToString().Substring(226, 40), NumberStyles.HexNumber) / 1000000000000000000);
                string token_name = "";
                if (tokena == "0xe9e7cea3dedca5984780bafc599bd69add087d56") token_name = " BUSD";
                if (tokena == "0xb46d67fb63770052a07d5b7c14ed858a8c90f825") token_name = " USDT";
                if (tokena == "0xbb4cdb9cbd36b01bd1cbaebf2de08d9173bc095c") token_name = " BNB";
                if (token_name != "")
                {
                    dataGridView1.Rows[num].Cells["liq"].Value = tokena_liqa.ToString("F1") + token_name;
                }
            }
            if (addLiquidity_checkBox.Checked)
            {
                if (dataGridView1.Rows[num].Cells["liq"].Value != null) token_visible(list, MethodID, token, num, true);
            }
            else
                if (dataGridView1.Rows[num].Cells["liq"].Value != null) token_visible(list, MethodID, token, num, false);
        }
        void analysis_lockTokens(Transaction list, string MethodID, string token, int num)
        {
            for (Int32 a = 0; a < token_kol; a++)
            {
                if (dataGridView1.Rows[a].Cells["adr_lp"].Value != null)
                {
                    //Console.WriteLine(" adr_lp " + dataGridView1.Rows[Convert.ToInt32(a)].Cells["adr_lp"].Value);
                    if (dataGridView1.Rows[a].Cells["adr_lp"].Value.ToString() == token)
                    {
                        //Console.WriteLine(" ok ");
                        System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                        BigInteger time_unlock = 0;
                        if ((MethodID == "0x6167aa61") | (MethodID == "0xe6a478b3")) time_unlock = (BigInteger)(BigInteger.Parse(list.Input.ToString().Substring(162, 40), NumberStyles.HexNumber));
                        if (MethodID == "0x64be5b39") time_unlock = (BigInteger)(BigInteger.Parse(list.Input.ToString().Substring(290, 40), NumberStyles.HexNumber));
                        dataGridView1.Rows[a].Cells["time_unlock"].Value = dtDateTime.AddSeconds((double)time_unlock).ToLocalTime().ToString("yyyy-MM-dd HH:mm");
                        dataGridView1.Rows[a].Cells["comment"].Value = "Lock Tokens";
                        if (lockTokens_checkBox.Checked) dataGridView1.Rows[a].Visible = true;
                        if ((list.to == "0x7ee058420e5937496f5a2096f04caa7721cf70cc") | (list.to == "0xae7e6cabad8d80f0b4e1c4dde2a5db7201ef1252") | (list.to == "0x3f4d6bf08cb7a003488ef082102c2e6418a4551e") | (list.to == "0xc765bddb93b0d1c1a88282ba0fa6b2d00e3e0c83"))
                        {
                            dataGridView1.Rows[Convert.ToInt32(a)].Cells["time_unlock"].Style.BackColor = Color.Honeydew;
                        }
                        else
                            dataGridView1.Rows[Convert.ToInt32(a)].Cells["time_unlock"].Style.BackColor = Color.Salmon;
                    }
                }
            }
        }
        void analysis_tradingStatus(Transaction list, string MethodID, string token, int num)
        {
            if (trading_checkBox.Checked)
            {
                if (dataGridView1.Rows[num].Cells["liq"].Value != null) token_visible(list, MethodID, token, num, true);
            }
            else
                if (dataGridView1.Rows[num].Cells["liq"].Value != null) token_visible(list, MethodID, token, num, false);
        }
        void analysis_transaction(Transaction list, string MethodID, string token, int num)
        {
            if (((MethodID == "0xb6f9de95") | (MethodID == "0x7ff36ab5")) & (list.Input.ToString().Length > 40)) //buy token
            {
                if (dataGridView1.Rows[num].Cells["swapEtT"].Value != null)
                {
                    dataGridView1.Rows[num].Cells["swapEtT"].Value = Convert.ToInt32(dataGridView1.Rows[num].Cells["swapEtT"].Value.ToString()) + 1;
                }
                else
                {
                    dataGridView1.Rows[num].Cells["swapEtT"].Value = "1";
                    //if (dataGridView1.Rows[num].Cells["name"].Value.ToString() == "?????") token_visible(list, MethodID, token, num);
                }
                if (dataGridView1.Rows[num].Cells["kost_b"].Value != null)
                {
                    if (list.value.ToString().Length <= 18)
                    {
                        dataGridView1.Rows[num].Cells["kost_b"].Value = (Convert.ToSingle(dataGridView1.Rows[num].Cells["kost_b"].Value.ToString().Replace(".", ",")) + (Convert.ToSingle(Convert.ToInt64(list.value.ToString(), 16) / 1000000000000) / 1000000)).ToString("F2");
                    }
                }
                else
                {
                    if (list.value.ToString().Length <= 18) dataGridView1.Rows[num].Cells["kost_b"].Value = (Convert.ToSingle(Convert.ToInt64(list.value.ToString(), 16) / 1000000000000) / 1000000).ToString("F2");
                }

            }
            if (((MethodID == "0x791ac947") | (MethodID == "0x18cbafe5")) & (list.Input.ToString().Length > 458)) //sell token
            {
                if (dataGridView1.Rows[num].Cells["swapTtE"].Value != null)
                {
                    dataGridView1.Rows[num].Cells["swapTtE"].Value = Convert.ToInt32(dataGridView1.Rows[num].Cells["swapTtE"].Value.ToString()) + 1;
                }
                else
                {
                    dataGridView1.Rows[num].Cells["swapTtE"].Value = "1";
                    //if (dataGridView1.Rows[num].Cells["name"].Value.ToString() == "?????") token_visible(list, MethodID, token, num);
                }
            }
            if (MethodID == "0x095ea7b3")
            {
                if (dataGridView1.Rows[num].Cells["approve"].Value != null)
                {
                    dataGridView1.Rows[num].Cells["approve"].Value = Convert.ToInt32(dataGridView1.Rows[num].Cells["approve"].Value.ToString()) + 1;
                }
                else
                {
                    dataGridView1.Rows[num].Cells["approve"].Value = "1";
                    //if (dataGridView1.Rows[num].Cells["name"].Value.ToString() == "?????") token_visible(list, MethodID, token, num);
                }
            }
            if (((MethodID == "0xe8e33700") | (MethodID == "0xf305d719")) & (list.Input.ToString().Length > 74)) // addLiquidity
            {
                dataGridView1.Rows[num].Cells["comment"].Value = "Add Liquidity";
                analysis_liquidity(list, MethodID, token, num);
            }
            if ((MethodID == "0x0d295980") | (MethodID == "0x8a8c523c") | (MethodID == "0x7b9e987a") | (MethodID == "0x6f73a4fe") | (MethodID == "0xfb201b1d")) //tradingStatus
            {
                dataGridView1.Rows[num].Cells["comment"].Value = "Сhanged Trading Status";
                analysis_tradingStatus(list, MethodID, token, num);
            }
            if ((MethodID == "0x64be5b39") & (list.Input.ToString().Length > 138)) //lockTokens
            {
                analysis_lockTokens(list, MethodID, token, num);
            }
            if (((MethodID == "0x6167aa61") | (MethodID == "0xe6a478b3")) & (list.Input.ToString().Length > 74)) //lockTokens
            {
                analysis_lockTokens(list, MethodID, token, num);
            }
            if (((MethodID == "0x5b0d5984") | (MethodID == "0x2195995c")) & (list.Input.ToString().Length > 74)) //removeLiquidityETHWithPermitSupportingFeeOnTransferTokens or removeLiquidityWithPermit
            {
                dataGridView1.Rows[num].Cells["comment"].Value = "Remove Liquidity"; dataGridView1.Rows[num].Cells["liq"].Style.BackColor = Color.Salmon;
                //if (dataGridView1.Rows[num].Cells["name"].Value.ToString() == "?????") token_visible(list, MethodID, token, num);
            }
        }
        async void analysis_percent(string token, Transaction list, Int32 num)
        {
            try
            {
                token = token.Replace("0x", "");
                var client = new RestClient("https://bsc-dataseed1.binance.org:443/");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                var cancellationTokenSource = new CancellationTokenSource();
                var body = @"{" + "\n" +
                @"	""jsonrpc"":""2.0""," + "\n" +
                @"	""method"":""eth_call""," + "\n" +
                @"	""params"":[{" + "\n" +
                @"		""from"": ""0x8894e0a0c962cb723c1976a4421c95949be2d4e3""," + "\n" +
                @"		""to"": ""0x2bf75fd2fab5fc635a4c6073864c708dfc8396fc""," + "\n" +
                @"		""gas"": ""0x2aea540""," + "\n" +
                @"		""value"": ""0x20d2e12546d434""," + "\n" +
                @"		""data"":""0xd66383cb000000000000000000000000" + token +
                @"""" + "\n" +
                @"	}, ""latest""]," + "\n" +
                @"	""id"":1" + "\n" +
                @"}";

                request.AddParameter("application/json", body, ParameterType.RequestBody);

                var response =
                    await client.ExecuteAsync(request, cancellationTokenSource.Token);
                if (response.Content.ToString().IndexOf("error") == -1)
                {
                    var response_string = JsonConvert.DeserializeObject<response_BscDataseedBinanceOrg>(response.Content).result.ToString().Replace("0x", "");
                    string[] response_string_array = new string[6];
                    response_string_array[0] = response_string.Substring(0, 64);
                    response_string_array[1] = response_string.Substring(64, 64);
                    response_string_array[2] = response_string.Substring(128, 64);
                    response_string_array[3] = response_string.Substring(192, 64);
                    response_string_array[4] = response_string.Substring(256, 64);
                    response_string_array[5] = response_string.Substring(320, 64);
                    BigDecimal buyExpectedOut = (BigInteger.Parse(response_string_array[0], NumberStyles.HexNumber));
                    BigDecimal buyActualOut = (BigInteger.Parse(response_string_array[1], NumberStyles.HexNumber));
                    BigDecimal sellExpectedOut = (BigInteger.Parse(response_string_array[2], NumberStyles.HexNumber));
                    BigDecimal sellActualOut = (BigInteger.Parse(response_string_array[3], NumberStyles.HexNumber));
                    BigDecimal buyGasUsed = (BigInteger.Parse(response_string_array[4], NumberStyles.HexNumber) / 1000);
                    BigDecimal sellGasUsed = (BigInteger.Parse(response_string_array[5], NumberStyles.HexNumber) / 1000);
                    var buy_tax = ((double)(((buyExpectedOut - buyActualOut) / buyExpectedOut * 100 * 10) / 10)).ToString("F0");
                    var sell_tax = ((double)(((sellExpectedOut - sellActualOut) / sellExpectedOut * 100 * 10) / 10)).ToString("F0");
                    dataGridView1.Rows[num].Cells["cont_proc"].Value = buy_tax + "/" + sell_tax;
                    if ((Convert.ToDouble(buy_tax.Replace(".", ",")) > 30) | (Convert.ToDouble(sell_tax.Replace(".", ",")) > 30)) dataGridView1.Rows[num].Cells["cont_proc"].Style.BackColor = Color.Salmon;
                }
                else
                {
                    var response_string = JsonConvert.DeserializeObject<response_BscDataseedBinanceOrg_error>(response.Content).error.message;
                    dataGridView1.Rows[num].Cells["cont_proc"].Value = response_string;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " " + "Error in proc_info_ask:" + error.Message);
                dataGridView1.Rows[num].Cells["name_t"].Value = "error";

            }
        }
        async void analysis_honeypotStatus(Transaction list, string MethodID, string token, int num)
        {
            try
            {
                if (dataGridView1.Columns["prov"].Visible == false) dataGridView1.Columns["prov"].Visible = true;
                string adr = "https://honeypot.api.rugdoc.io/api/honeypotStatus.js?address=" + token + "&chain=bsc";
                var client = new RestClient(adr);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = await client.ExecuteAsync(request);
                if (response.Content.ToString().IndexOf("status") != -1)
                {
                    var honeypotStatus = JsonConvert.DeserializeObject<honeypotStatus>(response.Content.ToString());
                    dataGridView1.Rows[Convert.ToInt32(num)].Cells["prov"].Value = honeypotStatus.status.ToString();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " " + "Error in honeypotStatus:" + error.Message);
            }
        }
    }
}