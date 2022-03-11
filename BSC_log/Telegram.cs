using RestSharp;
using System;

namespace BSC_log
{
    public partial class Form1
    {
        async void telegam_online(string address, int num)
        {
            var client = new RestClient("https://" + address);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            Int32 online = 0;
            if (response.Content.ToString().IndexOf("members,") != -1)
                online = Convert.ToInt32(response.Content.ToString().Substring(response.Content.ToString().IndexOf("members,") + 8, (response.Content.ToString().IndexOf("online") - response.Content.ToString().IndexOf("members,") - 8)).Replace(" ", ""));
            dataGridView1.Rows[Convert.ToInt32(num)].Cells["telegram_online"].Value = online.ToString();
        }
    }
}