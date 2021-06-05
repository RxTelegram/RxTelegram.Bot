using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.InlineMode
{
    /// <summary>
    /// This object represents an incoming inline query. When the user sends an empty query, your bot could return some default or trending results.
    /// </summary>
    public class InlineQuery
    {
        /// <summary>
        /// Unique identifier for this query
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        public User From { get; set; }

        /// <summary>
        /// Text of the query
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Optional. Sender location, only for bots that request user location
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// Offset of the results to be returned, can be controlled by the bot
        /// </summary>
        public string Offset { get; set; }

        /// <summary>
        /// Optional. Type of the chat, from which the inline query was sent. Can be either “sender” for a private chat with the
        /// inline query sender, “private”, “group”, “supergroup”, or “channel”.
        /// The chat type should be always known for requests sent from official clients and most third-party clients,
        /// unless the request was sent from a secret chat
        /// </summary>
        public ChatType ChatType { get; set; }
    }
}
