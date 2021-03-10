using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.InlineMode;
using RxTelegram.Bot.Interface.Payments;

namespace RxTelegram.Bot.Interface.Setup
{
    /// <summary>
    /// This object represents an incoming update.
    /// </summary>
    /// <remarks>
    /// Only one of the optional parameters can be present in any given update.
    /// </remarks>
    public class Update
    {
        /// <summary>
        /// The update's unique identifier. Update identifiers start from a certain positive number and increase sequentially.
        /// This ID becomes especially handy if you're using Webhooks, since it allows you to ignore repeated updates or to
        /// restore the correct update sequence, should they get out of order.
        /// </summary>
        public int UpdateId { get; set; }

        /// <summary>
        /// Optional. New incoming message of any kind — text, photo, sticker, etc.
        /// </summary>
        public Message Message { get; set; }

        /// <summary>
        /// Optional. New version of a message that is known to the bot and was edited
        /// </summary>
        public Message EditedMessage { get; set; }

        /// <summary>
        /// Optional. New incoming inline query
        /// </summary>
        public InlineQuery InlineQuery { get; set; }

        /// <summary>
        /// Optional. The result of a inline query that was chosen by a user and sent to their chat partner
        /// </summary>
        public ChosenInlineResult ChosenInlineResult { get; set; }

        /// <summary>
        /// Optional. New incoming callback query
        /// </summary>
        public CallbackQuery CallbackQuery { get; set; }

        /// <summary>
        /// Optional. New incoming channel post of any kind — text, photo, sticker, etc.
        /// </summary>
        public Message ChannelPost { get; set; }

        /// <summary>
        /// Optional. New version of a channel post that is known to the bot and was edited
        /// </summary>
        public Message EditedChannelPost { get; set; }

        /// <summary>
        /// Optional. New incoming shipping query. Only for invoices with flexible price
        /// </summary>
        public ShippingQuery ShippingQuery { get; set; }

        /// <summary>
        /// Optional. New incoming pre-checkout query. Contains full information about checkout
        /// </summary>
        public PreCheckoutQuery PreCheckoutQuery { get; set; }

        /// <summary>
        /// New poll state. Bots receive only updates about polls, which are sent or stopped by the bot
        /// </summary>
        public Poll Poll { get; set; }

        /// <summary>
        /// Optional. A user changed their answer in a non-anonymous poll. Bots receive new votes only in polls that were sent by the bot itself.
        /// </summary>
        public PollAnswer PollAnswer { get; set; }

        /// <summary>
        /// Optional. The bot's chat member status was updated in a chat. For private chats, this update is received only when the bot is
        /// blocked or unblocked by the user.
        /// </summary>
        public ChatMemberUpdated MyChatMember { get; set; }

        public ChatMemberUpdated ChatMember { get; set; }
    }
}
