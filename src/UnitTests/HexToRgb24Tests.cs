using System;
using NUnit.Framework;
using RxTelegram.Bot.Utils;

namespace RxTelegram.Bot.UnitTests;

[TestFixture]
public class HexToRgb24Tests
{
    [TestCase("#FF0000", ExpectedResult = 16711680)] // Red
    [TestCase("#00FF00", ExpectedResult = 65280)] // Green
    [TestCase("#0000FF", ExpectedResult = 255)] // Blue
    [TestCase("#000000", ExpectedResult = 0)] // Black
    [TestCase("#FFFFFF", ExpectedResult = 16777215)] // White
    [TestCase("#ABCDEF", ExpectedResult = 11259375)] // Random color
    public int Convert_ValidHexColor_ReturnsRgbValue(string hexColor) => HexToRgb24.Convert(hexColor);

    [TestCase("#0000000")]
    [TestCase("#00000000")]
    public void Convert_InvalidHexLength_ThrowsArgumentException(string hexColor) =>
        Assert.Throws<ArgumentException>(() => HexToRgb24.Convert(hexColor));

    [TestCase("#G00000")]
    [TestCase("#00000G")]
    public void Convert_InvalidHexColor_ThrowsFormatException(string hexColor) =>
        Assert.Throws<FormatException>(() => HexToRgb24.Convert(hexColor));

    [TestCase("#0000000")]
    [TestCase("#00000000")]
    public void TryConvert_InvalidHexLength_ThrowsArgumentException(string hexColor) =>
        Assert.That(HexToRgb24.TryConvert(hexColor, out _), Is.False);

    [TestCase("#G00000")]
    [TestCase("#00000G")]
    public void TryConvert_InvalidHexColor_ThrowsFormatException(string hexColor) =>
        Assert.That(HexToRgb24.TryConvert(hexColor, out _), Is.False);

    [TestCase("#FF0000", ExpectedResult = true)] // Red
    [TestCase("#00FF00", ExpectedResult = true)] // Green
    [TestCase("#0000FF", ExpectedResult = true)] // Blue
    [TestCase("#000000", ExpectedResult = true)] // Black
    [TestCase("#FFFFFF", ExpectedResult = true)] // White
    [TestCase("#ABCDEF", ExpectedResult = true)] // Random color
    [TestCase("#G00000", ExpectedResult = false)]
    [TestCase("#00000G", ExpectedResult = false)]
    [TestCase("#0000000", ExpectedResult = false)]
    [TestCase("#00000000", ExpectedResult = false)]
    public bool TryConvert_ValidHexColor_ReturnsTrue(string hexColor) => HexToRgb24.TryConvert(hexColor, out _);

    [TestCase("#FF0000", 16711680)] // Red
    [TestCase("#00FF00", 65280)] // Green
    [TestCase("#0000FF", 255)] // Blue
    [TestCase("#000000", 0)] // Black
    [TestCase("#FFFFFF", 16777215)] // White
    [TestCase("#ABCDEF", 11259375)] // Random color
    public void TryConvert_ValidHexColor_ReturnsRgbValue(string hexColor, int expected)
    {
        HexToRgb24.TryConvert(hexColor, out var result);
        Assert.That(result, Is.EqualTo(expected));
    }

}
