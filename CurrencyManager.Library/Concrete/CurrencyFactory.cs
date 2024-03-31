using System;
using CurrencyManager.Library.Interface;

namespace CurrencyManager.Library.Concrete
{
    public class CurrencyFactory : ICurrencyFactory
    {
        public ICurrency CreateCurrency(string name)
        {
            switch (name.ToLower())
            {
                case "foreks":
                    return new ForeksCurrency();
                case "bloomberg":
                    return new BloombergCurrency();
                case "hurriyet":
                    return new HurriyetCurrency();
                default:
                    return null;
            }
        }
    }
}