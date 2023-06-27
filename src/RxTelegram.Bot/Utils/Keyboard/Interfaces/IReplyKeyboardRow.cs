using RxTelegram.Bot.Interface.BaseTypes;

namespace RxTelegram.Bot.Utils.Keyboard.Interfaces;

public interface IReplyKeyboardRow
{
    public IReplyKeyboardRow AddTextButton(string text);

    public IReplyKeyboardRow AddRequestContactButton(string text);

    public IReplyKeyboardRow AddRequestLocationButton(string text);

    public IReplyKeyboardRow AddRequestPollButton(string text, KeyboardButtonPollType pollType);

    public IReplyKeyboardBuilder EndRow();
}
