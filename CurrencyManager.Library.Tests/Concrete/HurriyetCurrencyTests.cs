using System;
using CurrencyManager.Library.Concrete;
using CurrencyManager.Library.Exception;

namespace CurrencyManager.Library.Tests.Concrete
{
    public class HurriyetCurrencyTests
    {
        [Fact]
        public void HurriyetCurrency_ShouldWorkCorrect_WhenSymbolIsGold()
        {
            // Arrange
            HurriyetCurrency hurriyetCurrency = new HurriyetCurrency();
            CurrencySymbolDto goldCurrencySymbol = new CurrencySymbolDto('X', 'A', 'U');

            // Act
            decimal result = hurriyetCurrency.GetExchangeRate(goldCurrencySymbol);
            
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
        public void HurriyetCurrency_ShouldWorkCorrect_WhenSymbolIsValid(string currencySymbolText)
        {
            // Arrange
            HurriyetCurrency hurriyetCurrency = new HurriyetCurrency();
            CurrencySymbolDto currencySymbol = new CurrencySymbolDto(currencySymbolText[0], currencySymbolText[1], currencySymbolText[2]);

            // Act
            decimal result = hurriyetCurrency.GetExchangeRate(currencySymbol);
            
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
        public void HurriyetCurrency_ShouldThrowException_WhenCurrencyIsUnknown(string currencySymbolText)
        {
            // Arrange
            HurriyetCurrency hurriyetCurrency = new HurriyetCurrency();
            CurrencySymbolDto currencySymbol = new CurrencySymbolDto(currencySymbolText[0], currencySymbolText[1], currencySymbolText[2]);

            // Assert
            Assert.Throws<NotFoundCurrencyException>(() =>
            {
                hurriyetCurrency.GetExchangeRate(currencySymbol);
            });
        }
    }
}