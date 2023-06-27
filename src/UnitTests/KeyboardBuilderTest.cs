using System.Linq;
using NUnit.Framework;
using RxTelegram.Bot.Utils.Keyboard;

namespace RxTelegram.Bot.UnitTests;

[TestFixture]
public class KeyboardBuilderTest
{
    [Test]
    public void CreateReplyKeyboard_ShouldBuild_WithOneRow()
    {
        var keyboard = KeyboardBuilder.CreateReplyKeyboard()
                                      .BeginRow()
                                      .AddTextButton("test")
                                      .EndRow()
                                      .Build();
        var row1 = keyboard.First();
        var button1 = row1.First();
        Assert.AreEqual("test", button1.Text);
    }

    [Test]
    public void CreateReplyKeyboard_ShouldBuild_WithTwoRows()
    {
        var keyboard = KeyboardBuilder.CreateReplyKeyboard()
                                      .BeginRow()
                                      .AddTextButton("test")
                                      .EndRow()
                                      .BeginRow()
                                      .AddTextButton("test2")
                                      .EndRow()
                                      .Build();
        var keyboardList = keyboard.Select(x => x.ToList())
                                   .ToList();
        Assert.AreEqual("test", keyboardList[0][0].Text);
        Assert.AreEqual("test2", keyboardList[1][0].Text);
    }

    [Test]
    public void CreateInlineKeyboard_ShouldBuild_WithOneRow()
    {
        const string url = "https://niklas-weimann.de/";
        const string linkText = "Click here!";
        const string payText = "Pay here!";
        var keyboard = KeyboardBuilder.CreateInlineKeyboard()
                                      .BeginRow()
                                      .AddUrl(linkText, url)
                                      .AddPay(payText, true)
                                      .EndRow()
                                      .Build();
        var keyboardList = keyboard.Select(x => x.ToList())
                                   .ToList();
        Assert.AreEqual(linkText, keyboardList[0][0]
                            .Text);
        Assert.AreEqual(url, keyboardList[0][0].Url);
        Assert.AreEqual(payText, keyboardList[0][1]
                            .Text);
    }

    [Test]
    public void CreateInlineKeyboard_ShouldBuild_WithTwoRows()
    {
        const string url = "https://niklas-weimann.de/";
        const string linkText = "Click here!";
        const string payText = "Pay here!";
        var keyboard = KeyboardBuilder.CreateInlineKeyboard()
                                      .BeginRow()
                                      .AddUrl(linkText, url)
                                      .AddPay(payText, true)
                                      .EndRow()
                                      .BeginRow()
                                      .AddUrl(linkText + "2", url + "2")
                                      .AddPay(payText + "2", true)
                                      .EndRow()
                                      .Build();
        var keyboardList = keyboard.Select(x => x.ToList())
                                   .ToList();
        Assert.AreEqual(linkText, keyboardList[0][0]
                            .Text);
        Assert.AreEqual(url, keyboardList[0][0].Url);
        Assert.AreEqual(payText, keyboardList[0][1]
                            .Text);
        Assert.AreEqual(linkText + "2", keyboardList[1][0]
                            .Text);
        Assert.AreEqual(url + "2", keyboardList[1][0].Url);
        Assert.AreEqual(payText + "2", keyboardList[1][1]
                            .Text);
    }

    [Test]
    public void AsReplyKeyboardMarkup_ShouldConvert_WithKeyboardGiven()
    {
        var keyboard = KeyboardBuilder.CreateReplyKeyboard()
                                      .BeginRow()
                                      .EndRow()
                                      .Build()
                                      .AsReplyKeyboardMarkup();
        Assert.AreEqual(1, keyboard.Keyboard.Count());
        Assert.AreEqual(0, keyboard.Keyboard.First()
                                   .Count());
    }

    [Test]
    public void AsInlineKeyboardMarkup_ShouldConvert_WithKeyboardGiven()
    {
        var keyboard = KeyboardBuilder.CreateInlineKeyboard()
                                      .BeginRow()
                                      .EndRow()
                                      .Build()
                                      .AsInlineKeyboardMarkup();
        Assert.AreEqual(1, keyboard.InlineKeyboard.Count());
        Assert.AreEqual(0, keyboard.InlineKeyboard.First()
                                   .Count());
    }
}