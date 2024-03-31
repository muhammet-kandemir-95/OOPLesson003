using System;

namespace CurrencyManager.Library.Interface
{
    public interface ICurrency
    {
        public decimal GetExchangeRate(CurrencySymbolDto currencySymbol);
    }
}