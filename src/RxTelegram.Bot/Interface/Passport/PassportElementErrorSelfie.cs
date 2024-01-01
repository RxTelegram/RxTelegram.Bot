using RxTelegram.Bot.Interface.Passport.Enum;

namespace RxTelegram.Bot.Interface.Passport;

public class PassportElementErrorSelfie : PassportElementError
{
    public override PassportErrorType Source { get; set; } = PassportErrorType.Selfie;
}
