using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Chats;

public class SendChatAction : BaseRequest
{
    /// <summary>
    /// Unique identifier of the business connection on behalf of which the message will be sent
    /// </summary>
    public string BusinessConnectionId { get; set; }

    /// <summary>
    /// Required
    /// Type of action to broadcast. Choose one, depending on what the user is about to receive: typing for text messages,
    /// upload_photo for photos, record_video or upload_video for videos, record_audio or upload_audio for audio files,
    /// upload_document for general files, find_location for location data, record_video_note or upload_video_note for video notes.
    /// </summary>
    public ChatActions Action { get; set; }

    /// <summary>
    /// Unique identifier for the target message thread; supergroups only
    /// </summary>
    public long MessageThreadId { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
