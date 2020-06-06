using System.Runtime.Serialization;

namespace RxTelegram.Bot.Interface.BaseTypes.Enums
{
    public enum ThumbMimeType
    {
        [EnumMember(Value = "image/jpeg")]
        Jpeg,

        [EnumMember(Value = "image/gif")]
        Gif,

        [EnumMember(Value = "video/mp4")]
        Mp4
    }
}
