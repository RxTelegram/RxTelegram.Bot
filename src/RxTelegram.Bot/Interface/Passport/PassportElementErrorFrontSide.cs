using RxTelegram.Bot.Interface.Passport.Enum;

namespace RxTelegram.Bot.Interface.Passport;

public class PassportElementErrorFrontSide : PassportElementError
{
    public override PassportErrorType Source { get; set; } = PassportErrorType.FrontSide;
}
