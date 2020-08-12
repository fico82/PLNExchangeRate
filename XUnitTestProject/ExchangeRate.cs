using System;
using Xunit;
using PLNExchangeRate.Data.Models;
using System.Collections.Generic;
using PLNExchangeRate.Data;
using PLNExchangeRate.Service;

namespace XUnitTestProject
{
    public class ExchangeRate
    {
        private readonly IExchange EService = new ExchangeService();

        [Fact]
        public void TestAverage()
        {
           
            List<Rate> ratesList = new List<Rate>();
            ratesList.Add(new Rate() { no = "152/A/NBP/2020", effectiveDate = "2020-08-06", mid = 4.4101 });
            ratesList.Add(new Rate() { no = "153/A/NBP/2020", effectiveDate = "2020-08-07", mid = 4.4139 });
            var PLN = new Root { table = "A", currency = "euro", code = "EUR", rates = ratesList };

            double changeUSD = EService.GetChange(PLN.rates[0].mid, PLN.rates[1].mid);

            Assert.Equal(0.086, changeUSD);
        }
    }
}
