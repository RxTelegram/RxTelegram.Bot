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
        Assert.That(keyboardList[0][0].Text, Is.EqualTo("test"));
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
        Assert.That(keyboardList[0][0].Text, Is.EqualTo("test"));
        Assert.That(keyboardList[1][0].Text, Is.EqualTo("test2"));
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

        Assert.That(keyboardList[0][0].Text, Is.EqualTo(linkText));
        Assert.That(keyboardList[0][0].Url, Is.EqualTo(url));
        Assert.That(keyboardList[0][1].Text, Is.EqualTo(payText));
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
        Assert.That(keyboardList[0][0].Text, Is.EqualTo(linkText));
        Assert.That(keyboardList[0][0].Url, Is.EqualTo(url));
        Assert.That(keyboardList[0][1].Text, Is.EqualTo(payText));
        Assert.That(keyboardList[1][0].Text, Is.EqualTo(linkText + "2"));
        Assert.That(keyboardList[1][0].Url, Is.EqualTo(url + "2"));
        Assert.That(keyboardList[1][1].Text, Is.EqualTo(payText + "2"));
    }

    [Test]
    public void AsReplyKeyboardMarkup_ShouldConvert_WithKeyboardGiven()
    {
        var keyboard = KeyboardBuilder.CreateReplyKeyboard()
                                      .BeginRow()
                                      .EndRow()
                                      .Build()
                                      .AsReplyKeyboardMarkup();
        Assert.That(keyboard.Keyboard.Count(), Is.EqualTo(1));
        Assert.That(keyboard.Keyboard.First()
                                   .Count(), Is.EqualTo(0));
    }

    [Test]
    public void AsInlineKeyboardMarkup_ShouldConvert_WithKeyboardGiven()
    {
        var keyboard = KeyboardBuilder.CreateInlineKeyboard()
                                      .BeginRow()
                                      .EndRow()
                                      .Build()
                                      .AsInlineKeyboardMarkup();
        Assert.That(keyboard.InlineKeyboard.Count(), Is.EqualTo(1));
        Assert.That(keyboard.InlineKeyboard.First()
                                   .Count(), Is.EqualTo(0));
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
        Assert.That(keyboardList[0][0].Text, Is.EqualTo(requestLocation));
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
        Assert.That(keyboardList[0][0].Text, Is.EqualTo(requestPoll));
        Assert.That(keyboardList[0][0].RequestPoll.Type, Is.EqualTo(PollType.Quiz));
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
        Assert.That(keyboardList[0][0].Text, Is.EqualTo(buttonTitle));
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

        Assert.That(keyboardList[0][0].RequestContact, Is.True);
        Assert.That(keyboardList[0][0].Text, Is.EqualTo(buttonTitle));
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


        Assert.That(keyboardList[0][0].Text, Is.EqualTo(buttonTitle));
        Assert.That(keyboardList[0][0].Url, Is.EqualTo(url));
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


        Assert.That(keyboardList[0][0].Text, Is.EqualTo(callbackData));
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


        Assert.That(keyboardList[0][0].Text, Is.EqualTo(text));
        Assert.That(keyboardList[0][0].SwitchInlineQuery, Is.EqualTo(switchInlineQuery));
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


        Assert.That(keyboardList[0][0].Text, Is.EqualTo(text));
        Assert.That(keyboardList[0][0].SwitchInlineQueryCurrentChat, Is.EqualTo(switchInlineQueryCurrentChat));
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


        Assert.That(keyboardList[0][0].Text, Is.EqualTo(text));
        Assert.That(keyboardList[0][0].WebApp.Url, Is.EqualTo(url));
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


        Assert.That(keyboardList[0][0].Text, Is.EqualTo(buttonTitle));
        Assert.That(keyboardList[0][0].LoginUrl.Url, Is.EqualTo(url));
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


        Assert.That(keyboardList[0][0].Text, Is.EqualTo(buttonTitle));
        Assert.That(keyboardList[0][0].LoginUrl.Url, Is.EqualTo(loginUrl.Url));
        Assert.That(keyboardList[0][0].LoginUrl.BotUsername, Is.EqualTo(loginUrl.BotUsername));
        Assert.That(keyboardList[0][0].LoginUrl.ForwardText, Is.EqualTo(loginUrl.ForwardText));
        Assert.That(keyboardList[0][0].LoginUrl.RequestWriteAccess, Is.EqualTo(loginUrl.RequestWriteAccess));
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
        Assert.That(keyboardList[0][0].Text, Is.EqualTo(buttonTitle));
        Assert.That(keyboardList[0][0].CallbackData, Is.EqualTo(payload));
    }
}
