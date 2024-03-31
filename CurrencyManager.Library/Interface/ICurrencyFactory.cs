using System;

namespace CurrencyManager.Library.Interface
{
    public interface ICurrencyFactory
    {
        public ICurrency CreateCurrency(string name);
    }
}