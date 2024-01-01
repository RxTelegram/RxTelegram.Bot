using RxTelegram.Bot.Interface.Passport.Enum;

namespace RxTelegram.Bot.Interface.Passport;

public class PassportElementErrorUnspecified : PassportElementError
{
    public override PassportErrorType Source { get; set; } = PassportErrorType.Unspecified;
}
