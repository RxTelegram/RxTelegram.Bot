using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats
{
    /// <summary>
    /// Use this method to set default chat permissions for all members. The bot must be an administrator in the group or a supergroup for
    /// this to work and must have the can_restrict_members admin rights. Returns True on success.
    /// </summary>
    public class SetChatPermissions : BaseRequest
    {
        /// <summary>
        /// Required
        /// New default chat permissions
        /// </summary>
        public ChatPermissions Permissions { get; set; }

        /// <summary>
        /// Pass True if chat permissions are set independently.
        /// Otherwise, the can_send_other_messages and can_add_web_page_previews permissions will imply the
        /// can_send_messages,
        /// can_send_audios,
        /// can_send_documents,
        /// can_send_photos,
        /// can_send_videos,
        /// can_send_video_notes,
        /// and can_send_voice_notes permissions; the can_send_polls permission will imply the can_send_messages permission.
        /// </summary>
        public bool? UseIndependentChatPermissions { get; set; }

        protected override IValidationResult Validate() => this.CreateValidation();
    }
}
