using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Utils.Keyboard;

namespace RxTelegram.Bot.UnitTests;

[TestFixture]
public class KeyboardBuilderTest
{
    private static List<List<T>> GetKeyboardList<T>(IEnumerable<IEnumerable<T>> keyboard) => keyboard.Select(x => x.ToList())
        .ToList();

    [Test]
    public void CreateReplyKeyboard_ShouldBuild_WithOneRow()
    {
        var keyboard = KeyboardBuilder.CreateReplyKeyboard()
                                      .BeginRow()
                                      .AddTextButton("test")
                                      .EndRow()
                                      .Build();
        var keyboardList = GetKeyboardList(keyboard);
        Assert.AreEqual("test", keyboardList[0][0].Text);
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
        var keyboardList = GetKeyboardList(keyboard);
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
        var keyboardList = GetKeyboardList(keyboard);

        Assert.AreEqual(linkText, keyboardList[0][0].Text);
        Assert.AreEqual(url, keyboardList[0][0].Url);
        Assert.AreEqual(payText, keyboardList[0][1].Text);
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
        Assert.AreEqual(linkText, keyboardList[0][0].Text);
        Assert.AreEqual(url, keyboardList[0][0].Url);
        Assert.AreEqual(payText, keyboardList[0][1].Text);
        Assert.AreEqual(linkText + "2", keyboardList[1][0].Text);
        Assert.AreEqual(url + "2", keyboardList[1][0].Url);
        Assert.AreEqual(payText + "2", keyboardList[1][1].Text);
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

    [Test]
    public void CreateReplyKeyboard_ShouldBuild_WithAddRequestLocationButton()
    {
        // Arrange
        const string requestLocation = "RequestLocation";

        // Act
        var keyboard = KeyboardBuilder.CreateReplyKeyboard()
                                      .BeginRow()
                                      .AddRequestLocationButton(requestLocation)
                                      .EndRow()
                                      .Build();

        // Assert
        var keyboardList = GetKeyboardList(keyboard);
        Assert.AreEqual(requestLocation, keyboardList[0][0].Text);
    }

    [Test]
    public void CreateReplyKeyboard_ShouldBuilt_WithAddRequestPollButton()
    {
        // Arrange
        const string requestPoll = "RequestPoll";

        // Act
        var keyboard = KeyboardBuilder.CreateReplyKeyboard()
                                      .BeginRow()
                                      .AddRequestPollButton(requestPoll, new KeyboardButtonPollType { Type = PollType.Quiz })
                                      .EndRow()
                                      .Build();

        // Assert
        var keyboardList = GetKeyboardList(keyboard);
        Assert.AreEqual(requestPoll, keyboardList[0][0].Text);
        Assert.AreEqual(PollType.Quiz, keyboardList[0][0].RequestPoll.Type);
    }

    [Test]
    public void CreateReplyKeyboard_ShouldBuild_WithAddTextButton()
    {
        const string buttonTitle = "test";

        var replyKeyboardBuilder = KeyboardBuilder.CreateReplyKeyboard()
                                                  .BeginRow()
                                                  .AddTextButton(buttonTitle)
                                                  .EndRow()
                                                  .Build();
        var keyboardList = GetKeyboardList(replyKeyboardBuilder);
        Assert.AreEqual(buttonTitle, keyboardList[0][0].Text);
    }

    [Test]
    public void CreateReplyKeyboard_ShouldBuild_WithAddRequestContactButton()
    {
        const string buttonTitle = "test";

        var replyKeyboardBuilder = KeyboardBuilder.CreateReplyKeyboard()
                                                  .BeginRow()
                                                  .AddRequestContactButton(buttonTitle)
                                                  .EndRow()
                                                  .Build();
        var keyboardList = GetKeyboardList(replyKeyboardBuilder);

        Assert.IsTrue(keyboardList[0][0].RequestContact);
        Assert.AreEqual(buttonTitle, keyboardList[0][0].Text);
    }

    [Test]
    public void CreateInlineKeyboard_ShouldBuild_WithAddUrl()
    {
        const string buttonTitle = "test";
        const string url = "http://test.com";

        var inlineKeyboardBuilder = KeyboardBuilder.CreateInlineKeyboard()
                                                   .BeginRow()
                                                   .AddUrl(buttonTitle, url)
                                                   .EndRow()
                                                   .Build()
                                                   .ToList();
        var keyboardList = GetKeyboardList(inlineKeyboardBuilder);


        Assert.AreEqual(buttonTitle, keyboardList[0][0].Text);
        Assert.AreEqual(url, keyboardList[0][0].Url);
    }

    [Test]
    public void CreateInlineKeyboard_ShouldBuild_WithAddCallbackGame()
    {
        const string callbackData = "test";

        var inlineKeyboardBuilder = KeyboardBuilder.CreateInlineKeyboard()
                                                   .BeginRow()
                                                   .AddCallbackGame(callbackData)
                                                   .EndRow()
                                                   .Build()
                                                   .ToList();
        var keyboardList = GetKeyboardList(inlineKeyboardBuilder);


        Assert.AreEqual(callbackData, keyboardList[0][0].Text);
    }

    [Test]
    public void CreateInlineKeyboard_ShouldBuild_WithAddSwitchInlineQuery()
    {
        const string text = "test";
        const string switchInlineQuery = "this is a scam";


        var inlineKeyboardBuilder = KeyboardBuilder.CreateInlineKeyboard()
                                                   .BeginRow()
                                                   .AddSwitchInlineQuery(text, switchInlineQuery)
                                                   .EndRow()
                                                   .Build()
                                                   .ToList();
        var keyboardList = GetKeyboardList(inlineKeyboardBuilder);


        Assert.AreEqual(text, keyboardList[0][0].Text);
        Assert.AreEqual(switchInlineQuery, keyboardList[0][0].SwitchInlineQuery);
    }

    [Test]
    public void CreateInlineKeyboard_ShouldBuild_WithAddSetSwitchInlineQueryCurrentChat()
    {
        const string text = "test";
        const string switchInlineQueryCurrentChat = "this is a scam";


        var inlineKeyboardBuilder = KeyboardBuilder.CreateInlineKeyboard()
                                                   .BeginRow()
                                                   .AddSetSwitchInlineQueryCurrentChat(text, switchInlineQueryCurrentChat)
                                                   .EndRow()
                                                   .Build()
                                                   .ToList();
        var keyboardList = GetKeyboardList(inlineKeyboardBuilder);


        Assert.AreEqual(text, keyboardList[0][0].Text);
        Assert.AreEqual(switchInlineQueryCurrentChat, keyboardList[0][0].SwitchInlineQueryCurrentChat);
    }

    [Test]
    public void CreateInlineKeyboard_ShouldBuild_WithAddWebApp()
    {
        const string text = "test";
        const string url = "http://example.com";


        var inlineKeyboardBuilder = KeyboardBuilder.CreateInlineKeyboard()
                                                   .BeginRow()
                                                   .AddWebApp(text, url)
                                                   .EndRow()
                                                   .Build()
                                                   .ToList();
        var keyboardList = GetKeyboardList(inlineKeyboardBuilder);


        Assert.AreEqual(text, keyboardList[0][0].Text);
        Assert.AreEqual(url, keyboardList[0][0].WebApp.Url);
    }

    [Test]
    public void CreateInlineKeyboard_ShouldBuild_WithAddLoginUrl()
    {
        const string buttonTitle = "test";
        const string url = "http://test.com";

        var inlineKeyboardBuilder = KeyboardBuilder.CreateInlineKeyboard()
                                                   .BeginRow()
                                                   .AddLoginUrl(buttonTitle, url)
                                                   .EndRow()
                                                   .Build()
                                                   .ToList();
        var keyboardList = GetKeyboardList(inlineKeyboardBuilder);


        Assert.AreEqual(buttonTitle, keyboardList[0][0].Text);
        Assert.AreEqual(url, keyboardList[0][0].LoginUrl.Url);
    }

    [Test]
    public void CreateInlineKeyboard_ShouldBuild_WithAddLoginUrlObject()
    {
        const string buttonTitle = "test";
        var loginUrl = new LoginUrl
                       {
                           Url = "TestUrl",
                           BotUsername = "BotUsername",
                           ForwardText = "ForwardText",
                           RequestWriteAccess = true
                       };

        var inlineKeyboardBuilder = KeyboardBuilder.CreateInlineKeyboard()
                                                   .BeginRow()
                                                   .AddLoginUrl(buttonTitle, loginUrl)
                                                   .EndRow()
                                                   .Build()
                                                   .ToList();
        var keyboardList = GetKeyboardList(inlineKeyboardBuilder);


        Assert.AreEqual(buttonTitle, keyboardList[0][0].Text);
        Assert.AreEqual(loginUrl.Url, keyboardList[0][0].LoginUrl.Url);
        Assert.AreEqual(loginUrl.BotUsername, keyboardList[0][0].LoginUrl.BotUsername);
        Assert.AreEqual(loginUrl.ForwardText, keyboardList[0][0].LoginUrl.ForwardText);
        Assert.AreEqual(loginUrl.RequestWriteAccess, keyboardList[0][0].LoginUrl.RequestWriteAccess);
    }

    [Test]
    public void CreateInlineKeyboard_ShouldBuild_WithAddCallbackData()
    {
        const string buttonTitle = "test";
        const string payload = "payload";

        var inlineKeyboard = KeyboardBuilder.CreateInlineKeyboard()
                                            .BeginRow()
                                            .AddCallbackData(buttonTitle, payload)
                                            .EndRow()
                                            .Build();

        var keyboardList = GetKeyboardList(inlineKeyboard);
        Assert.AreEqual(buttonTitle, keyboardList[0][0].Text);
        Assert.AreEqual(payload, keyboardList[0][0].CallbackData);
    }
}
