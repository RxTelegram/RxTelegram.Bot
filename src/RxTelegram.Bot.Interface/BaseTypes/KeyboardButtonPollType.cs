using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.BaseTypes
{
    public class KeyboardButtonPollType
    {
        /// <summary>
        /// Optional. If quiz is passed, the user will be allowed to create only polls in the quiz mode.
        /// If regular is passed, only regular polls will be allowed. Otherwise, the user will be allowed to create a poll of any type.
        /// </summary>
        public PollType Type { get; set; }
    }
}
