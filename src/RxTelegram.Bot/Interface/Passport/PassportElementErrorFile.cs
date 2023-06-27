namespace RxTelegram.Bot.Interface.Passport;

public class PassportElementErrorFile : PassportElementError
{
    public override string Source { get; } = "file";
}