using System;

namespace CurrencyManager.Library.Exception
{
    public class NotFoundCurrencyException : ApplicationException
    {
        public NotFoundCurrencyException(string serviceName) : base($"The related currency could not be found in {serviceName}!")
        { }
    }
}