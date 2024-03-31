using System;
using System.Globalization;
using CurrencyManager.Library.Exception;

public record CurrencySymbolDto
{
    public static readonly CurrencySymbolDto Gold = new CurrencySymbolDto('X', 'A', 'U');

    private char _character1;
    private char _character2;
    private char _character3;

    public string Text
    {
        get
        {
            return _character1.ToString() + _character2.ToString() + _character3.ToString();
        }
    }

    public CurrencySymbolDto(char character1, char character2, char character3)
    {
        this.ValidateCharacter(character1);
        this.ValidateCharacter(character2);
        this.ValidateCharacter(character3);

        character1 = char.ToUpper(character1);
        character2 = char.ToUpper(character2);
        character3 = char.ToUpper(character3);

        this._character1 = character1;
        this._character2 = character2;
        this._character3 = character3;
    }

    private void ValidateCharacter(char character)
    {
        if (char.IsLetter(character) == false)
        {
            throw new WrongCurrencyCharacterException();
        }
    }
}