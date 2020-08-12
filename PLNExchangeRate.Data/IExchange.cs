using PLNExchangeRate.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PLNExchangeRate.Data
{
    public interface IExchange
    {
        Task<Root> GetExchange(string currency);
        double GetChange(double oldValue, double newValue);
    }
}
