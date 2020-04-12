using RxTelegram.Bot.Interface.Validation;

namespace RxTelegram.Bot.Validation
{
    public enum ValidationErrors
    {
        [ValidationErrorsString("ID lower than 1 is not allowed.")]
        IdLowerThanOne,

        [ValidationErrorsString("Field is not set, but required")]
        FieldRequired,

        [ValidationErrorsString("Only one of there properties can be set")]
        OnlyOnePropertyCanBeSet,

        [ValidationErrorsString("One of these properties need to be set")]
        NonePropertySet,

        [ValidationErrorsString("Stickersets Created by bots need to end with _by_<botname> ")]
        InvalidStickerName,

        [ValidationErrorsString("InlineMessageId, ChatId or MessageId is required.")]
        InlineMessageIdChatIdMessageIdRequiredOr,

        [ValidationErrorsString("InlineMessageId or ChatId and MessageId required.")]
        InlineMessageIdOrChatIdAndMessageId,

        [ValidationErrorsString("Only InputMediaPhoto or InputMediaVideo allowed")]
        OnlyInputMediaPhotoOrInputMediaVideo,

        [ValidationErrorsString("Text can only be 4096 chars long")]
        TextTooLong,

        [ValidationErrorsString("Question can only be 1-255 chars long")]
        QuestionTooLong,

        [ValidationErrorsString("Only two to ten Options are allowed")]
        InvalidOptionCount,

        [ValidationErrorsString("Options can only be 1 to 100 Chars long")]
        OptionStringTooLong,

        [ValidationErrorsString("Correct Option is required in Quizmode")]
        CorrectOptionRequired
    }
}
