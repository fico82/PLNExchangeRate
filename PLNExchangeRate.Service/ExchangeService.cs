using System;
using System.Threading.Tasks;
using System.Net.Http;
using PLNExchangeRate.Data.Models;
using Newtonsoft.Json;
using PLNExchangeRate.Data;

namespace PLNExchangeRate.Service
{
    public class ExchangeService : IExchange
    {
        private HttpClient Client = new HttpClient
        {
            BaseAddress = new Uri("http://api.nbp.pl/"),
        };

        public async Task<Root> GetExchange(string currency)
        {
            var deserialized = new Root();
                var response = await Client.GetAsync("api/exchangerates/rates/a/" + currency + "/last/2/?format=json");
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    deserialized = JsonConvert.DeserializeObject<Root>(result);
                }
            return deserialized;
        }

        public double GetChange(double oldValue, double newValue)
        {
            double change = 0;
            if (newValue > oldValue) {change=(newValue-oldValue)/oldValue;}
            if (newValue < oldValue) {change=(oldValue-newValue)/oldValue;change=-(change);}
            change = (Math.Round(change, 5))*100;
            return change;
        }
    }
}
