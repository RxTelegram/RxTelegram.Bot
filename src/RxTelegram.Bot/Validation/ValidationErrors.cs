namespace RxTelegram.Bot.Validation
{
    public enum ValidationErrors
    {
        /// <summary>
        /// Indicates that an id lower than 1 is invalid.
        /// </summary>
        [ValidationErrorsString("ID lower than 1 is not allowed.")]
        IdLowerThanOne,

        /// <summary>
        /// Indicates that a field is required
        /// </summary>
        [ValidationErrorsString("Field is not set, but required")]
        FieldRequired,

        /// <summary>
        /// Indicates that only one of two or more properties can be set.
        /// </summary>
        [ValidationErrorsString("Only one of there properties can be set")]
        OnlyOnePropertyCanBeSet,

        /// <summary>
        /// Indicates that at least one of the properties need to be set.
        /// </summary>
        [ValidationErrorsString("One of these properties need to be set")]
        NonePropertySet,

        /// <summary>
        /// Indicates that the sticker set name is invalid, because it does not end with "_by_<botname>"
        /// </summary>
        [ValidationErrorsString("Stickersets Created by bots need to end with _by_<botname> ")]
        InvalidStickerName,

        /// <summary>
        /// Indicates that inlineMessageId, chatId or messageId needs to be set.
        /// </summary>
        [ValidationErrorsString("InlineMessageId, ChatId or MessageId is required.")]
        InlineMessageIdChatIdMessageIdRequiredOr,

        /// <summary>
        /// Indicates that inlineMessageId or chatId AND messageID needs to be set.
        /// </summary>
        [ValidationErrorsString("InlineMessageId or ChatId and MessageId required.")]
        InlineMessageIdOrChatIdAndMessageId,

        /// <summary>
        /// Indicates that only InputMediaPhoto or InputMediaVideo are allowed.
        /// </summary>
        [ValidationErrorsString("Only InputMediaPhoto, InputMediaDocument, InputMediaAudio or InputMediaVideo allowed")]
        OnlySomeInputMediaTypesAllowed,

        /// <summary>
        /// Indicates that the text exceeds the limit of 4096 chars.
        /// </summary>
        [ValidationErrorsString("Text can only be 4096 chars long")]
        TextTooLong,

        /// <summary>
        /// Indicates that the question exceeds the limit of 1-255 chars.
        /// </summary>
        [ValidationErrorsString("Question can only be 1-255 chars long")]
        QuestionTooLong,

        /// <summary>
        /// Indicates that only two of ten options are allowed.
        /// </summary>
        [ValidationErrorsString("Only two to ten Options are allowed")]
        InvalidOptionCount,

        /// <summary>
        /// Indicates that the option string length can only be between 1 and 100.
        /// </summary>
        [ValidationErrorsString("Options can only be 1 to 100 Chars long")]
        OptionStringTooLong,

        /// <summary>
        /// Indicates that a correct option is required in quizmode.
        /// </summary>
        [ValidationErrorsString("Correct Option is required in Quizmode")]
        CorrectOptionRequired,

        /// <summary>
        /// Indicates that only 100 commands can be set.
        /// </summary>
        [ValidationErrorsString("At most 100 commands can be specified.")]
        CommandLimit,

        /// <summary>
        /// Indicates that the given url is invalid
        /// </summary>
        [ValidationErrorsString("Url invalid")]
        UrlInvalid,

        /// <summary>
        /// Indicates that the given webhook port is not supported.
        /// </summary>
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
