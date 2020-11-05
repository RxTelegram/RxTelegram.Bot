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

        [ValidationErrorsString("Only InputMediaPhoto, InputMediaDocument, InputMediaAudio or InputMediaVideo allowed")]
        OnlySomeInputMediaTypesAllowed,

        [ValidationErrorsString("Text can only be 4096 chars long")]
        TextTooLong,

        [ValidationErrorsString("Question can only be 1-255 chars long")]
        QuestionTooLong,

        [ValidationErrorsString("Only two to ten Options are allowed")]
        InvalidOptionCount,

        [ValidationErrorsString("Options can only be 1 to 100 Chars long")]
        OptionStringTooLong,

        [ValidationErrorsString("Correct Option is required in Quizmode")]
        CorrectOptionRequired,

        [ValidationErrorsString("At most 100 commands can be specified.")]
        CommandLimit,

        [ValidationErrorsString("Url invalid")]
        UrlInvalid,

        [ValidationErrorsString("Currently supported ports for Webhooks: 443, 80, 88, 8443.")]
        SupportedPortsWebhook,

        [ValidationErrorsString("Heading must be between 1 and 360 if specified")]
        HeadingOutOfRange,

        [ValidationErrorsString("Proximity must be between 1 and 100000")]
        ProximityAlertRadiusOutOfRange,

        [ValidationErrorsString("HorizontalAccuracy must be between 0 and 1500")]
        HorizontalAccuracyOutOfRange

    }
}
