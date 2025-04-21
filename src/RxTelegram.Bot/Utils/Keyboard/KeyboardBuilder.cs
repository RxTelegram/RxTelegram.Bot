using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.Games;
using RxTelegram.Bot.Utils.Keyboard.Interfaces;

namespace RxTelegram.Bot.Utils.Keyboard;

public class KeyboardBuilder : IReplyKeyboardRow, IReplyKeyboardBuilder, IInlineKeyboardBuilder, IInlineKeyboardRow
{
    private readonly List<List<KeyboardButton>> _keyboard = new();
    private List<KeyboardButton> _row = new();

    private readonly List<List<InlineKeyboardButton>> _inlineKeyboard = new();
    private List<InlineKeyboardButton> _inlineRow = new();

    private KeyboardBuilder()
    {
    }

    #region ReplyKeyboard

    public static IReplyKeyboardBuilder CreateReplyKeyboard() => new KeyboardBuilder();

    IEnumerable<IEnumerable<KeyboardButton>> IReplyKeyboardBuilder.Build() => _keyboard;

    public IReplyKeyboardRow BeginRow()
    {
        _row = new List<KeyboardButton>();
        return this;
    }

    IReplyKeyboardBuilder IReplyKeyboardRow.EndRow()
    {
        _keyboard.Add(_row);
        _row = new List<KeyboardButton>();
        return this;
    }

    #region ReplyKeyboardButton

    public IReplyKeyboardRow AddTextButton(string text)
    {
        _row.Add(new KeyboardButton { Text = text });
        return this;
    }

    public IReplyKeyboardRow AddRequestContactButton(string text)
    {
        _row.Add(new KeyboardButton { RequestContact = true, Text = text });
        return this;
    }

    public IReplyKeyboardRow AddRequestLocationButton(string text)
    {
        _row.Add(new KeyboardButton { RequestLocation = true, Text = text });
        return this;
    }

    public IReplyKeyboardRow AddRequestPollButton(string text, KeyboardButtonPollType pollType)
    {
        _row.Add(new KeyboardButton { RequestPoll = pollType, Text = text });
        return this;
    }

    #endregion

    #endregion

    #region InlineKeyboard

    public static IInlineKeyboardBuilder CreateInlineKeyboard() => new KeyboardBuilder();
    IEnumerable<IEnumerable<InlineKeyboardButton>> IInlineKeyboardBuilder.Build() => _inlineKeyboard;

    IInlineKeyboardRow IInlineKeyboardBuilder.BeginRow()
    {
        _inlineRow = new List<InlineKeyboardButton>();
        return this;
    }

    IInlineKeyboardBuilder IInlineKeyboardRow.EndRow()
    {
        _inlineKeyboard.Add(_inlineRow);
        _inlineRow = new List<InlineKeyboardButton>();
        return this;
    }

    #region InlineKeyboardButton

    public IInlineKeyboardRow AddUrl(string text, string url)
    {
        _inlineRow.Add(new InlineKeyboardButton
                       {
                           Text = text,
                           Url = url
                       });
        return this;
    }

    public IInlineKeyboardRow AddLoginUrl(string text, LoginUrl loginUrl)
    {
        _inlineRow.Add(new InlineKeyboardButton
                       {
                           Text = text,
                           LoginUrl = loginUrl
                       });
        return this;
    }

    public IInlineKeyboardRow AddLoginUrl(string text, string loginUrl)
    {
        _inlineRow.Add(new InlineKeyboardButton
                       {
                           Text = text,
                           LoginUrl = new LoginUrl
                                      {
                                          Url = loginUrl
                                      }
                       });
        return this;
    }

    public IInlineKeyboardRow AddCallbackData(string text, string callbackData)
    {
        _inlineRow.Add(new InlineKeyboardButton
                       {
                           Text = text, CallbackData = callbackData
                       });
        return this;
    }

    public IInlineKeyboardRow AddCallbackGame(string text)
    {
        _inlineRow.Add(new InlineKeyboardButton
                       {
                           Text = text, CallbackGame = new CallbackGame()
                       });
        return this;
    }

    public IInlineKeyboardRow AddCopyText(string text, string copyText)
    {
        _inlineRow.Add(new InlineKeyboardButton
                       {
                           Text = text,
                           CopyText = new CopyTextButton()
                           {
                                Text = copyText
                           }
                       });
        return this;
    }

    public IInlineKeyboardRow AddButton(InlineKeyboardButton button)
    {
        _inlineRow.Add(button);
        return this;
    }

    public IInlineKeyboardRow AddSwitchInlineQuery(string text, string switchInlineQuery)
    {
        _inlineRow.Add(new InlineKeyboardButton { Text = text, SwitchInlineQuery = switchInlineQuery });
        return this;
    }

    public IInlineKeyboardRow AddSetSwitchInlineQueryCurrentChat(string text, string switchInlineQueryCurrentChat)
    {
        _inlineRow.Add(new InlineKeyboardButton
                       {
                           Text = text,
                           SwitchInlineQueryCurrentChat = switchInlineQueryCurrentChat
                       });
        return this;
    }

    public IInlineKeyboardRow AddPay(string text, bool pay)
    {
        _inlineRow.Add(new InlineKeyboardButton
                       {
                           Text = text,
                           Pay = pay
                       });
        return this;
    }

    public IInlineKeyboardRow AddWebApp(string text, string url)
    {
        _inlineRow.Add(new InlineKeyboardButton
                       {
                           Text = text,
                           WebApp = new WebAppInfo
                                    {
                                        Url = url
                                    }
                       });
        return this;
    }

    #endregion

    #endregion
}
