using System;
using System.Globalization;
using CurrencyManager.Library.Exception;
using CurrencyManager.Library.Helper;
using CurrencyManager.Library.Interface;

namespace CurrencyManager.Library.Concrete
{
    public class HurriyetCurrency : ICurrency
    {
        public decimal GetExchangeRate(CurrencySymbolDto currencySymbol)
        {
            string currencySymbolForWebSite;

            if (currencySymbol == CurrencySymbolDto.Gold)
            {
                currencySymbolForWebSite = "GLDGR";
            }
            else
            {
                currencySymbolForWebSite = currencySymbol.Text + "TRY";
            }

            string sourceHtml = WebHelper.DownloadHtml("https://bigpara.hurriyet.com.tr/doviz/");

            if (sourceHtml.Contains($"\",\"Sembol\":\"{currencySymbolForWebSite}\",\"Alis\":") == false)
            {
                currencySymbolForWebSite = currencySymbolForWebSite.Replace("TRY", "");
            }

            try
            {
                string split1 = sourceHtml.Split($"\",\"Sembol\":\"{currencySymbolForWebSite}\",\"Alis\":")[1];
                string split2 = split1.Split("}")[0];
                string resultText = split2.Split("Satis\":")[1];

                return Convert.ToDecimal(resultText, CultureInfo.InvariantCulture);
            }
            catch
            {
                throw new NotFoundCurrencyException(nameof(HurriyetCurrency));
            }
        }
    }
}