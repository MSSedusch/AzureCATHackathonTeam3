using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace StockProWebApi.Controllers
{
    public class PredictionController : ApiController
    {
        public class Input
        {
            public string frequency;
            public string horizon;
            public string date;
            public string value;
        }

        public AuthenticationHeaderValue CreateBasicHeader(string username, string password)
        {
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(username + ":" + password);
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }
        // GET api/values 
        public IEnumerable<string> Get()
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

            return new string[] { scoreResult };
        }

        // GET api/values/5 
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values 
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
        }
    }
}