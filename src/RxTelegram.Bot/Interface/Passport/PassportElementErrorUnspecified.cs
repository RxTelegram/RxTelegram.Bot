namespace RxTelegram.Bot.Interface.Passport;

public class PassportElementErrorUnspecified : PassportElementError
{
    public override string Source { get; } = "unspecified";
}