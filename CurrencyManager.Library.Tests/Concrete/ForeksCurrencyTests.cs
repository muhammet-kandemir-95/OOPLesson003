using System;
using CurrencyManager.Library.Concrete;
using CurrencyManager.Library.Exception;

namespace CurrencyManager.Library.Tests.Concrete
{
    public class ForeksCurrencyTests
    {
        [Fact]
        public void ForeksCurrency_ShouldWorkCorrect_WhenSymbolIsGold()
        {
            // Arrange
            ForeksCurrency foreksCurrency = new ForeksCurrency();
            CurrencySymbolDto goldCurrencySymbol = new CurrencySymbolDto('X', 'A', 'U');

            // Act
            decimal result = foreksCurrency.GetExchangeRate(goldCurrencySymbol);
            
            // Assert
            Assert.True(result > 0);
        }

        [Theory]
        [InlineData("EUR")]
        [InlineData("USD")]
        [InlineData("JPY")]
        [InlineData("CNY")]
        [InlineData("GBP")]
        [InlineData("PKR")]
        [InlineData("AED")]
        public void ForeksCurrency_ShouldWorkCorrect_WhenSymbolIsValid(string currencySymbolText)
        {
            // Arrange
            ForeksCurrency foreksCurrency = new ForeksCurrency();
            CurrencySymbolDto currencySymbol = new CurrencySymbolDto(currencySymbolText[0], currencySymbolText[1], currencySymbolText[2]);

            // Act
            decimal result = foreksCurrency.GetExchangeRate(currencySymbol);
            
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
        public void ForeksCurrency_ShouldThrowException_WhenCurrencyIsUnknown(string currencySymbolText)
        {
            // Arrange
            ForeksCurrency foreksCurrency = new ForeksCurrency();
            CurrencySymbolDto currencySymbol = new CurrencySymbolDto(currencySymbolText[0], currencySymbolText[1], currencySymbolText[2]);

            // Assert
            Assert.Throws<NotFoundCurrencyException>(() =>
            {
                foreksCurrency.GetExchangeRate(currencySymbol);
            });
        }
    }
}