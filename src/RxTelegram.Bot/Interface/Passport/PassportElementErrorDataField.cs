using RxTelegram.Bot.Interface.Passport.Enum;

namespace RxTelegram.Bot.Interface.Passport;

public class PassportElementErrorDataField : PassportElementError
{
    public override PassportErrorType Source { get; set; } = PassportErrorType.Data;
}
