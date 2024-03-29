﻿using RxTelegram.Bot.Interface.BaseTypes.Requests.Base.Interfaces;

namespace RxTelegram.Bot.Interface.BaseTypes;

/// <summary>
///     This Object represents a ForeReply Object https://core.telegram.org/bots/api#forcereply
/// </summary>
public class ForceReply : IReplyMarkup
{
    /// <summary>
    /// Shows reply interface to the user, as if they manually selected the bot‘s message and tapped ’Reply'
    /// </summary>
    public bool Force_Reply { get; set; } = true;

    /// <summary>
    /// Optional. The placeholder to be shown in the input field when the reply is active; 1-64 characters
    /// </summary>
    public string InputFieldPlaceholder { get; set; }

    /// <summary>
    /// Optional. Use this parameter if you want to force reply from specific users only. Targets: 1) users
    /// that are @mentioned in the text of the Message object; 2) if the bot's message is a reply (has reply_to_message_id),
    /// sender of the original message.
    /// </summary>
    public bool Selective { get; set; }
}
