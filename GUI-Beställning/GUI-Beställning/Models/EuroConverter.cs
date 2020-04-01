using GUI_Beställning.Models.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace GUI_Beställning.Models
{
    public class EuroConverter
    {
        public float EuroRate()
        {
            ExchangeRates fileNames = new ExchangeRates();
            using (HttpClient httpClient = new HttpClient())
            {
                //httpClient.DefaultRequestHeaders.Add(HeaderNames.Authorization, "Bearer " + GetJWT());
                string uri = "https://api.exchangeratesapi.io/latest?symbols=USD";

                //HttpResponseMessage response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    StreamReader reader = new StreamReader(await response.Content.ReadAsStreamAsync(), Encoding.UTF8);
                    string dataFromWebapi = reader.ReadToEnd();
                    fileNames = System.Text.Json.JsonSerializer.Deserialize<ExchangeRates>(dataFromWebapi);
                }
            }
            Order = fileNames;
        }
    }
}
