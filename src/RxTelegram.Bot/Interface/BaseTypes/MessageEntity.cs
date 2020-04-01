﻿namespace RxTelegram.Bot.Interface.BaseTypes
{
    /// <summary>
    /// This object represents one special entity in a text message. For example, hashtags, usernames, URLs, etc.
    /// </summary>
    public class MessageEntity
    {
        /// <summary>
        /// Type of the entity
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Offset in UTF-16 code units to the start of the entity
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Length of the entity in UTF-16 code units
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Optional. For “text_link” only, url that will be opened after user taps on the text
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Optional. For “text_mention” only, the mentioned user
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Optional. For “pre” only, the programming language of the entity text
        /// </summary>
        public string Language { get; set; }
    }
}