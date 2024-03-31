using System;
using CurrencyManager.Library.Concrete;
using CurrencyManager.Library.Exception;

namespace CurrencyManager.Library.Tests.Concrete
{
    public class BloombergCurrencyTests
    {
        [Fact]
        public void BloombergCurrency_ShouldWorkCorrect_WhenSymbolIsGold()
        {
            // Arrange
            BloombergCurrency bloombergCurrency = new BloombergCurrency();
            CurrencySymbolDto goldCurrencySymbol = new CurrencySymbolDto('X', 'A', 'U');

            // Act
            decimal result = bloombergCurrency.GetExchangeRate(goldCurrencySymbol);
            
            // Assert
            Assert.True(result > 0);
        }

        [Theory]
        [InlineData("EUR")]
        [InlineData("USD")]
        [InlineData("JPY")]
        [InlineData("GBP")]
        [InlineData("CHF")]
        [InlineData("SAR")]
        [InlineData("NOK")]
        public void BloombergCurrency_ShouldWorkCorrect_WhenSymbolIsValid(string currencySymbolText)
        {
            // Arrange
            BloombergCurrency bloombergCurrency = new BloombergCurrency();
            CurrencySymbolDto currencySymbol = new CurrencySymbolDto(currencySymbolText[0], currencySymbolText[1], currencySymbolText[2]);

            // Act
            decimal result = bloombergCurrency.GetExchangeRate(currencySymbol);
            
            // Assert
            Assert.True(result > 0);
        }

        [Theory]
        [InlineData("ASD")]
        [InlineData("CCC")]
        [InlineData("FJE")]
        [InlineData("XLS")]
        [InlineData("GJT")]
        [InlineData("PRG")]
        public void BloombergCurrency_ShouldThrowException_WhenCurrencyIsUnknown(string currencySymbolText)
        {
            // Arrange
            BloombergCurrency bloombergCurrency = new BloombergCurrency();
            CurrencySymbolDto currencySymbol = new CurrencySymbolDto(currencySymbolText[0], currencySymbolText[1], currencySymbolText[2]);

            // Assert
            Assert.Throws<NotFoundCurrencyException>(() =>
            {
                bloombergCurrency.GetExchangeRate(currencySymbol);
            });
        }
    }
}