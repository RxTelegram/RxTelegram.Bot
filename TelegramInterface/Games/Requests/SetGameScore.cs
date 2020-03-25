﻿using TelegramInterface.Games.Requests.Base;

namespace TelegramInterface.Games.Requests
{
    /// <summary>
    /// Use this method to set the score of the specified user in a game. On success, if the message was sent by the bot, returns the
    /// edited Message, otherwise returns True. Returns an error, if the new score is not greater than the user's current score in the
    /// chat and force is False.
    /// </summary>
    public class SetGameScore : BaseRequest
    {
        /// <summary>
        /// User identifier
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// New score, must be non-negative
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Pass True, if the high score is allowed to decrease. This can be useful when fixing mistakes or banning cheaters
        /// </summary>
        public bool Force { get; set; }

        /// <summary>
        /// Pass True, if the game message should not be automatically edited to include the current scoreboard
        /// </summary>
        public bool DisableEditMessage { get; set; }

        /// <summary>
        /// Required if inline_message_id is not specified. Identifier of the sent message
        /// </summary>
        public int MessageId { get; set; }

        /// <summary>
        /// Required if chat_id and message_id are not specified. Identifier of the inline message
        /// </summary>
        public string InlineMessageId { get; set; }
    }
}