using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// The boost was obtained by the creation of Telegram Premium gift codes to boost a chat.
/// Each such code boosts the chat 4 times for the duration of the corresponding Telegram Premium subscription.
/// </summary>
public class ChatBoostSourceGiftCode : ChatBoostSource
{
    /// <summary>
    /// Source of the boost, always “gift_code”
    /// </summary>
    public override ChatBoostSourceType Source { get; set; } = ChatBoostSourceType.GiftCode;

    /// <summary>
    /// User for which the gift code was created
    /// </summary>
    public User User { get; set; }
}
