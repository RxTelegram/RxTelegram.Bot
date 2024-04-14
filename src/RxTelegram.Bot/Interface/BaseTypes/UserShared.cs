using System.Collections.Generic;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// This object contains information about the user whose identifier was shared with the bot using a <see cref="KeyboardButtonRequestUsers"/> button.
/// </summary>
public class UsersShared
{
    /// <summary>
    /// Identifier of the request
    /// </summary>
    public int RequestId { get; set; }

    /// <summary>
    /// Information about users shared with the bot.
    /// </summary>
    public List<SharedUser> UserId { get; set; }
}
