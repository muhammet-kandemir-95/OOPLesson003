using System;

namespace CurrencyManager.Library.Exception
{
    public class WrongCurrencyCharacterException : ApplicationException
    {
        public WrongCurrencyCharacterException() : base("Currency symbols must consist of only letters!")
        { }
    }
}