using System;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
/// This object represents changes in the status of a chat member.
/// </summary>
public class ChatMemberUpdated
{
    /// <summary>
    /// Chat the user belongs to
    /// </summary>
    public Chat Chat { get; set; }

    /// <summary>
    /// Performer of the action, which resulted in the change
    /// </summary>
    public User From { get; set; }

    /// <summary>
    /// Date the change was done in Unix time
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Previous information about the chat member
    /// </summary>
    public ChatMember OldChatMember { get; set; }

    /// <summary>
    /// New information about the chat member
    /// </summary>
    public ChatMember NewChatMember { get; set; }

    /// <summary>
    /// Optional. Chat invite link, which was used by the user to join the chat; for joining by invite link events only.
    /// </summary>
    public ChatInviteLink InviteLink { get; set; }

    /// <summary>
    /// Optional. True, if the user joined the chat via a chat folder invite link
    /// </summary>
    public bool ViaChatFolderInviteLink { get; set; }
}
