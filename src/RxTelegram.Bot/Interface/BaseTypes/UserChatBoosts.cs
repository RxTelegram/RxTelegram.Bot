using System.Collections.Generic;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// This object represents a list of boosts added to a chat by a user.
/// </summary>
public class UserChatBoosts
{
    /// <summary>
    /// The list of boosts added to the chat by the user
    /// </summary>
    public List<ChatBoost> Boosts { get; set; }
}
