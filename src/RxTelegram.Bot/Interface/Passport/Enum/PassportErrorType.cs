using RxTelegram.Bot.Utils.MultiType;

namespace RxTelegram.Bot.Interface.Passport.Enum;

public enum PassportErrorType
{
    [ImplementationType(typeof(PassportElementErrorDataField))]
    Data,

    [ImplementationType(typeof(PassportElementErrorFile))]
    File,

    [ImplementationType(typeof(PassportElementErrorFiles))]
    Files,

    [ImplementationType(typeof(PassportElementErrorFrontSide))]
    FrontSide,

    [ImplementationType(typeof(PassportElementErrorReverseSide))]
    ReverseSide,

    [ImplementationType(typeof(PassportElementErrorSelfie))]
    Selfie,

    [ImplementationType(typeof(PassportElementErrorTranslationFile))]
    TranslationFile,

    [ImplementationType(typeof(PassportElementErrorTranslationFiles))]
    TranslationFiles,

    [ImplementationType(typeof(PassportElementErrorUnspecified))]
    Unspecified
}
