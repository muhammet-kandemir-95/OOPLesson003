using System;
using CurrencyManager.Library.Exception;

namespace CurrencyManager.Library.Tests.Model
{
    public class CurrencySymbolTests
    {
        [Theory]
        [InlineData('5', '5', '5')]
        [InlineData('1', 'A', '1')]
        [InlineData('1', 'a', '1')]
        [InlineData('B', 'B', '2')]
        [InlineData('b', 'b', '2')]
        [InlineData('4', 'c', 'E')]
        [InlineData('4', 'c', 'e')]
        [InlineData('4', 'C', 'e')]
        public void CurrencySymbol_ShouldNotAllowNumberCharacters(char c1, char c2, char c3)
        {
            // Arrange

            // Assert
            Assert.Throws<WrongCurrencyCharacterException>(() =>
            {
                // Act
                CurrencySymbol currency = new CurrencySymbol(c1, c2, c3);
            });
        }
        
        [Theory]
        [InlineData('!', '-', '*')]
        [InlineData('!', 'A', '-')]
        [InlineData('*', 'a', '!')]
        [InlineData('B', 'B', '-')]
        [InlineData('b', 'b', '*')]
        [InlineData('!', 'c', 'E')]
        [InlineData('-', 'c', 'e')]
        [InlineData('*', 'C', 'e')]
        public void CurrencySymbol_ShouldNotAllowSpecialCharacters(char c1, char c2, char c3)
        {
            // Arrange

            // Assert
            Assert.Throws<WrongCurrencyCharacterException>(() =>
            {
                // Act
                CurrencySymbol currency = new CurrencySymbol(c1, c2, c3);
            });
        }

        [Theory]
        [InlineData('u', 's', 'd')]
        [InlineData('u', 'S', 'd')]
        [InlineData('u', 's', 'D')]
        [InlineData('u', 'S', 'D')]
        [InlineData('U', 'S', 'd')]
        [InlineData('U', 's', 'D')]
        [InlineData('U', 'S', 'D')]
        [InlineData('e', 'u', 'r')]
        [InlineData('x', 'a', 'u')]
        [InlineData('a', 'u', 'd')]
        [InlineData('g', 'b', 'p')]
        [InlineData('j', 'p', 'y')]
        [InlineData('c', 'n', 'y')]
        [InlineData('p', 'k', 'r')]
        public void CurrencySymbol_ShouldWorkWithoutException(char c1, char c2, char c3)
        {
            // Arrange

            // Act
            CurrencySymbol currency = new CurrencySymbol(c1, c2, c3);

            // Assert
        }


        [Theory]
        [InlineData('u', 's', 'd', "USD")]
        [InlineData('u', 'S', 'd', "USD")]
        [InlineData('u', 's', 'D', "USD")]
        [InlineData('u', 'S', 'D', "USD")]
        [InlineData('U', 'S', 'd', "USD")]
        [InlineData('U', 's', 'D', "USD")]
        [InlineData('U', 'S', 'D', "USD")]
        [InlineData('e', 'u', 'r', "EUR")]
        [InlineData('x', 'a', 'u', "XAU")]
        [InlineData('a', 'u', 'd', "AUD")]
        [InlineData('g', 'b', 'p', "GBP")]
        [InlineData('j', 'p', 'y', "JPY")]
        [InlineData('c', 'n', 'y', "CNY")]
        [InlineData('p', 'k', 'r', "PKR")]
        public void CurrencySymbol_ShouldWorkCorrectly(char c1, char c2, char c3, string result)
        {
            // Arrange

            // Act
            CurrencySymbol currency = new CurrencySymbol(c1, c2, c3);

            // Assert
            Assert.Equal(result, currency.Text);
        }
    }
}