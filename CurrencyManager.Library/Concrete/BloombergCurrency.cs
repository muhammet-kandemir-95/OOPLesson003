using System;
using System.Globalization;
using CurrencyManager.Library.Exception;
using CurrencyManager.Library.Helper;
using CurrencyManager.Library.Interface;

namespace CurrencyManager.Library.Concrete
{
    public class BloombergCurrency : ICurrency
    {
        public decimal GetExchangeRate(CurrencySymbolDto currencySymbol)
        {
            if (currencySymbol == CurrencySymbolDto.Gold)
            {
                string sourceHtml = WebHelper.DownloadHtml("https://www.bloomberght.com/altin");

                try
                {
                    string split1 = sourceHtml.Split(@"<span>ALTIN/GR SPOT</span>
							</a>
						</td>
						<td>")[1];
                    string split2 = split1.Split("</td>")[1];
                    string resultText = split2.Split("<td>")[1].Replace(',', '-').Replace('.', ',').Replace('-', '.');

                    return Convert.ToDecimal(resultText, CultureInfo.InvariantCulture);
                }
                catch
                {
                    throw new NotFoundCurrencyException(nameof(BloombergCurrency));
                }
            }
            else
            {
                string currencySymbolForWebSite = currencySymbol.Text;
                string sourceHtml = WebHelper.DownloadHtml("https://www.bloomberght.com/doviz");

                try
                {
                    string split1 = sourceHtml.Split($"<td style=\"vertical-align:middle;\"><i data-type=\"icon2\" data-secid=\"{currencySymbolForWebSite}TRY Curncy\"")[1];
                    string split2 = split1.Split("<td style=\"vertical-align:middle;\">")[3];
                    string resultText = split2.Split("</td>")[0].Replace(',', '-').Replace('.', ',').Replace('-', '.');

                    return Convert.ToDecimal(resultText, CultureInfo.InvariantCulture);
                }
                catch
                {
                    throw new NotFoundCurrencyException(nameof(BloombergCurrency));
                }
            }
        }
    }
}