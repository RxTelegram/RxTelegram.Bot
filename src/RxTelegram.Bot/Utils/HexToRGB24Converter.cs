using System;
using System.Globalization;

namespace RxTelegram.Bot.Utils;

public class HexToRgb24
{
    public int Convert(string hexColor) => int.Parse(FormatHexString(hexColor), NumberStyles.HexNumber);

    public bool TryConvert(string hexColor, out int result) => int.TryParse(FormatHexString(hexColor), NumberStyles.HexNumber, null, out result);

    private static string FormatHexString(string hexColor)
    {
        hexColor = hexColor.TrimStart('#');
        if (hexColor.Length == 3)
        {
            hexColor = string.Concat(hexColor[0], hexColor[0], hexColor[1], hexColor[1], hexColor[2], hexColor[2]);
        }
        else if (hexColor.Length != 6)
        {
            throw new ArgumentException("Hex color must be 3 or 6 characters long.");
        }

        return hexColor;
    }
}
