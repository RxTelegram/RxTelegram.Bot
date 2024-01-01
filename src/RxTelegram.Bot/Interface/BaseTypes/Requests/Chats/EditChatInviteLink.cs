using System;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;

/// <summary>
/// Use this method to edit a non-primary invite link created by the bot.
/// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
/// </summary>
public class EditChatInviteLink : BaseRequest
{
    /// <summary>
    /// The invite link to edit
    /// </summary>
    public string InviteLink { get; set; }

    /// <summary>
    /// Invite link name; 0-32 characters
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Point in time (Unix timestamp) when the link will expire
    /// </summary>
    public DateTime ExpireDate { get; set; }

    /// <summary>
    /// Maximum number of users that can be members of the chat simultaneously after joining the chat via this invite link; 1-99999
    /// </summary>
    public int MemberLimit { get; set; }

    /// <summary>
    /// True, if users joining the chat via the link need to be approved by chat administrators.
    /// If True, member_limit can't be specified
    /// </summary>
    public bool? CreatesJoinRequest { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
