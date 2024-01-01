using RxTelegram.Bot.Interface.Passport.Enum;

namespace RxTelegram.Bot.Interface.Passport;

public class PassportElementErrorTranslationFile : PassportElementError
{
    public override PassportErrorType Source { get; set; } = PassportErrorType.TranslationFile;
}
