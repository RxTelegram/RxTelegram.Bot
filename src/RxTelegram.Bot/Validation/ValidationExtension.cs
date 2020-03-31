using RxTelegram.Bot.Interface.BaseTypes.Requests.Attachments;

namespace RxTelegram.Bot.Interface.Validation
{
    public static class ValidationExtension
    {
        public static bool IsNull(this InputFile inputFile) => inputFile == null;
        public static bool IsNotNull(this InputFile inputFile) => inputFile != null;
    }
}
