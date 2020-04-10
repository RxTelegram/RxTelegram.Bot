using RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Messages;

namespace RxTelegram.Bot.Interface.BaseTypes.Enums
{
    public enum ChatActions
    {
        /// <summary>
        /// <see cref="SendMessage"/>
        /// </summary>
        Typing,

        /// <summary>
        /// <see cref="SendPhoto"/>
        /// </summary>
        UploadPhoto,

        /// <summary>
        /// <see cref="SendVideo"/>
        /// </summary>
        RecordVideo,

        /// <summary>
        /// <see cref="SendVideo"/>
        /// </summary>
        UploadVideo,

        /// <summary>
        /// <see cref="SendAudio"/>
        /// </summary>
        RecordAudio,

        /// <summary>
        /// <see cref="SendAudio"/>
        /// </summary>
        UploadAudio,

        /// <summary>
        /// <see cref="SendDocument"/>
        /// </summary>
        UploadDocument,

        /// <summary>
        /// <see cref="SendLocation"/>
        /// </summary>
        FindLocation,

        /// <summary>
        /// <see cref="SendVideo"/>
        /// </summary>
        RecordVideoNote,

        /// <summary>
        /// <see cref="SendVideo"/>
        /// </summary>
        UploadVideoNote
    }
}
