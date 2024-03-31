using System;
using System.Globalization;
using CurrencyManager.Library.Exception;
using CurrencyManager.Library.Helper;
using CurrencyManager.Library.Interface;

namespace CurrencyManager.Library.Concrete
{
    public class ForeksCurrency : ICurrency
    {
        public decimal GetExchangeRate(CurrencySymbolDto currencySymbol)
        {
            if (currencySymbol == CurrencySymbolDto.Gold)
            {
                string currencySymbolForWebSite = "gram-altin";
                string sourceHtml = WebHelper.DownloadHtml("https://www.doviz.com");

                try
                {
                    string split1 = sourceHtml.Split($"<span class=\"value\" data-socket-key=\"{currencySymbolForWebSite}\" data-socket-attr=\"s\" data-socket-animate=\"true\">")[1];
                    string resultText = split1.Split("</span>")[0].Replace(',', '-').Replace('.', ',').Replace('-', '.');

                    return Convert.ToDecimal(resultText, CultureInfo.InvariantCulture);
                }
                catch
                {
                    throw new NotFoundCurrencyException(nameof(ForeksCurrency));
                }
            }
            else
            {
                string currencySymbolForWebSite = currencySymbol.Text;
                string sourceHtml = WebHelper.DownloadHtml("https://kur.doviz.com");

                try
                {
                    string split1 = sourceHtml.Split($"<td class=\"text-bold\"  data-socket-key=\"{currencySymbolForWebSite}\" data-socket-attr=\"ask\" data-socket-animate=\"true\" >")[1];
                    string resultText = split1.Split("</td>")[0].Replace(',', '-').Replace('.', ',').Replace('-', '.');

                    return Convert.ToDecimal(resultText, CultureInfo.InvariantCulture);
                }
                catch
                {
                    throw new NotFoundCurrencyException(nameof(ForeksCurrency));
                }
            }
        }
    }
}