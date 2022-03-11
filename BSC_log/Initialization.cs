using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BSC_log
{
    public partial class Form1
    {
        private void dataGridView_edit()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns.Add("num", "N");
            dataGridView1.Columns["num"].Width = 30;
            dataGridView1.Columns.Add("time", "Time");
            dataGridView1.Columns["time"].Width = 110;
            dataGridView1.Columns.Add("name", "Token name");
            dataGridView1.Columns["num"].Width = 30;
            dataGridView1.Columns.Add("adr", "Address");
            dataGridView1.Columns["adr"].Width = 220;
            dataGridView1.Columns.Add("swapEtT", "Buy");
            dataGridView1.Columns["swapEtT"].Width = 30;
            dataGridView1.Columns.Add("swapTtE", "Sell");
            dataGridView1.Columns["swapTtE"].Width = 30;
            dataGridView1.Columns.Add("approve", "Appr");
            dataGridView1.Columns["approve"].Width = 30;
            dataGridView1.Columns.Add("kost_b", "Volume buy(BNB)");
            dataGridView1.Columns["kost_b"].Width = 50;
            dataGridView1.Columns.Add("vers", "Compiler Version");
            dataGridView1.Columns["vers"].Width = 125;
            dataGridView1.Columns.Add("cont_proc", "buy/sell %");
            dataGridView1.Columns["cont_proc"].Width = 45;
            dataGridView1.Columns.Add("prov", "Check");
            dataGridView1.Columns["prov"].Width = 60;
            dataGridView1.Columns["prov"].Visible = false;
            dataGridView1.Columns.Add("vers_size", "Contract size");
            dataGridView1.Columns["vers_size"].Width = 50;
            dataGridView1.Columns.Add("abi_size", "Contract ABI size");
            dataGridView1.Columns["abi_size"].Width = 50;
            dataGridView1.Columns.Add("liq", "Liquidity");
            dataGridView1.Columns["liq"].Width = 70;
            dataGridView1.Columns.Add("telegram", "Telegram link");
            dataGridView1.Columns["telegram"].Visible = false;
            dataGridView1.Columns.Add("telegram_online", "Telegram Online");
            dataGridView1.Columns["telegram_online"].Width = 50;
            dataGridView1.Columns.Add("time_unlock", "Time unlock");
            dataGridView1.Columns["time_unlock"].Width = 100;
            dataGridView1.Columns.Add("comment", "Comment");
            dataGridView1.Columns["comment"].Width = 90;
            dataGridView1.Columns.Add("adr_lp", "adr_lp");
            dataGridView1.Columns["adr_lp"].Width = 260;
            dataGridView1.Columns["adr_lp"].Visible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font.FontFamily, 7f, FontStyle.Regular); //жирный курсив размера 16
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            info_label_text = new ToolStripLabel();
            info_label_text.Text = "Click 'Online' to start";
            statusStrip1.Items.Add(info_label_text);
        }
        private void load_key_file()
        {
            try
            {
                using (StreamReader key_file = File.OpenText("config.txt"))
                {
                    string key_file_string = "";
                    while ((key_file_string = key_file.ReadLine()) != null)
                    {
                        if (key_file_string.IndexOf("bscscan_apikey=") != -1)
                        {
                            bscscan_apikey = key_file_string.Substring(key_file_string.IndexOf("bscscan_apikey=") + 15, (key_file_string.Length - key_file_string.IndexOf("bscscan_apikey=") - 15));
                        }
                    }
                }

            }
            catch (Exception error)
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " " + "Error in load_key_file:" + error.Message);
                info_label_text.Text = "Error!!!!! config.txt not found";
                bscscan_apikey = "CK3P8JGQ3EY1AU1923FERNBB4D97ESP2BN";
            }
        }
    }
}