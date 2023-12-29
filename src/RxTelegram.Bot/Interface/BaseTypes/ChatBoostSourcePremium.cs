using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// The boost was obtained by subscribing to Telegram Premium or by gifting a Telegram Premium subscription to another user.
/// </summary>
public class ChatBoostSourcePremium : ChatBoostSource
{
    /// <summary>
    /// Source of the boost, always “premium”
    /// </summary>
    public override ChatBoostSourceType Source { get; protected set; } = ChatBoostSourceType.Premium;

    /// <summary>
    /// User that boosted the chat
    /// </summary>
    public User User { get; set; }
}
