using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method to unban a previously kicked user in a supergroup or channel. The user will not return to the group or channel
    /// automatically, but will be able to join via link, etc. The bot must be an administrator for this to work.
    /// By default, this method guarantees that after the call the user is not a member of the chat, but will be able to join it.
    /// So if the user is a member of the chat they will also be removed from the chat.
    /// If you don't want this, use the parameter <see cref="OnlyIfBanned"/>. Returns True on success.
    /// </summary>
    public class UnbanChatMember : BaseRequest
    {
        /// <summary>
        /// Unique identifier of the target user
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Do nothing if the user is not banned
        /// </summary>
        public bool? OnlyIfBanned { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
