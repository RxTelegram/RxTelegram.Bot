using RxTelegram.Bot.Interface.Passport.Enum;

namespace RxTelegram.Bot.Interface.Passport;

public class PassportElementErrorReverseSide : PassportElementError
{
    public override PassportErrorType Source { get; set; } = PassportErrorType.ReverseSide;
}
