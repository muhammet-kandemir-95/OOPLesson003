using System;
using System.Globalization;
using CurrencyManager.Library.Concrete;
using CurrencyManager.Library.Exception;
using CurrencyManager.Library.Interface;

namespace CurrencyManager.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CurrencyFactory currencyFactory = new CurrencyFactory();

            while (true)
            {
                ICurrency currency;
                while (true)
                {
                    Console.WriteLine("Servisler;");
                    Console.WriteLine("- Foreks: foreks");
                    Console.WriteLine("- Bloomberg: bloomberg");
                    Console.WriteLine("- Hürriyet: hurriyet");
                    Console.Write("Lütfen kullanmak istediğiniz servisin adını giriniz: ");
                    string serviceName = Console.ReadLine();

                    currency = currencyFactory.CreateCurrency(serviceName);

                    if (currency != null)
                    {
                        break;
                    }

                    Console.WriteLine("Girdiğiniz servis adı geçersizdir. Lütfen tekrar deneyiniz!");
                }

                CurrencySymbolDto currencySymbol;
                while (true)
                {
                    Console.Write("Öğrenmek istediğiniz döviz cinsini üç karakter olarak giriniz(Ör. USD, EUR, XAU(Altın)): ");
                    string currencySymbolText = Console.ReadLine();

                    if (currencySymbolText.Length != 3)
                    {
                        Console.WriteLine("Döviz cinsi 3 karakterden az veya fazla olamaz. Lütfen tekrar deneyiniz!");
                        continue;
                    }

                    try
                    {
                        currencySymbol = new CurrencySymbolDto(currencySymbolText[0], currencySymbolText[1], currencySymbolText[2]);
                        break;
                    }
                    catch (WrongCurrencyCharacterException)
                    {
                        Console.WriteLine("Döviz cinsi sadece ingiliz alfabesindeki harflerden oluşmalıdır!");
                        continue;
                    }
                }

                try
                {
                    decimal currencyExchangeRate = currency.GetExchangeRate(currencySymbol);
                    Console.WriteLine();
                    Console.WriteLine($"{currencySymbol.Text}: {currencyExchangeRate.ToString(new CultureInfo("tr-TR"))} TRY");
                }
                catch (NotFoundCurrencyException)
                {
                    Console.WriteLine("Girilen döviz cinsi bulunamadı!");
                }
                catch
                {
                    Console.WriteLine("Bilinmeyen bir hata meydana geldi. Daha sonra tekrar deneyiniz.");
                }

                Console.WriteLine("----------------------------------------------------------------");
            }
        }
    }
}