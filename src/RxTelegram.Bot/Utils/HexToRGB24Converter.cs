using System;
using System.Globalization;

namespace RxTelegram.Bot.Utils;

public static class HexToRgb24
{
    public static int Convert(string hexColor)
    {
        var formatHexString = FormatHexString(hexColor);
        if (formatHexString.Length != 6)
        {
            throw new ArgumentException("Invalid hex color", nameof(hexColor));
        }
        return int.Parse(formatHexString, NumberStyles.HexNumber);
    }

    public static bool TryConvert(string hexColor, out int result)
    {
        var formatHexString = FormatHexString(hexColor);
        if (formatHexString.Length == 6)
        {
            return int.TryParse(FormatHexString(hexColor), NumberStyles.HexNumber, null, out result);
        }

        result = -1;
        return false;
    }

    private static string FormatHexString(string hexColor)
    {
        hexColor = hexColor.TrimStart('#');
        if (hexColor.Length == 3)
        {
            hexColor = string.Concat(hexColor[0], hexColor[0], hexColor[1], hexColor[1], hexColor[2], hexColor[2]);
        }

        return hexColor;
    }
}
