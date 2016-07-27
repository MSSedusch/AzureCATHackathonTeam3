using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestMLConsoleApp
{
    public class Input
    {
        public string frequency;
        public string horizon;
        public string date;
        public string value;
    }

    

    class Program
    {
        public static AuthenticationHeaderValue CreateBasicHeader(string username, string password)
        {
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(username + ":" + password);
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }

        /*
         * http://microsoftazuremachinelearning.azurewebsites.net/ArimaForecasting.aspx
         * Frequency - Frequency should be an integer greater than 1 representing the frequency of observations. For example, for monthly data, frequency = "12"; weekly = "52"; daily = "365"
Horizon - Horizon should be a positive integer representing the number of future data points to predict. For example, for monthly data, horizon means the number of future months to predict
Date - Time series dates (The lengths of Date and Value should be the same; date should be in the format of ‘mm/dd/yyyy’ and should be separated by semicolon; there should not be missing dates)
Value - Time series values (The lengths of Date and Value should be the same; values should be separated by semicolon)
Output
Forecast1, Forecast2, ... - Forecast for time 1, 2, ..., e.g., Forecast1: 6605.90210900797, Forecast2: 6481.26482503371, ...
         * 
         * */
        static void Main(string[] args)
        {
            var input = new Input() { frequency = "1", horizon = "1", date = "07/20/2016;07/21/2016;07/22/2016;07/23/2016;07/24/2016;07/25/2016;07/26/2016;07/27/2016 ", value = "900000;870000;760000;990000;1050000;890000;900000;770000" };
            var json = JsonConvert.SerializeObject(input);
            var acitionUri = "https://api.datamarket.azure.com/data.ashx/aml_labs/arima/v1/Score";//"PutAPIURLHere,e.g.https://api.datamarket.azure.com/..../v1/Score";
            var httpClient = new HttpClient();

            //go to https://datamarket.azure.com/account

            httpClient.DefaultRequestHeaders.Authorization = CreateBasicHeader("raramani@microsoft.com", "zBO5kR2a0mxAP16wZYvR4MKgePZEDpLmxAMlAc9RVmg");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = httpClient.PostAsync(acitionUri, new StringContent(json));
            var result = response.Result.Content;
            var scoreResult = result.ReadAsStringAsync().Result;
        }
    }
}
