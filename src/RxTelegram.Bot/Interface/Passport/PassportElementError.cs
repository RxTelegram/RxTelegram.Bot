using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.Passport.Enum;
using RxTelegram.Bot.Utils.MultiType;

namespace RxTelegram.Bot.Interface.Passport;

/// <summary>
///     This object represents an error in the Telegram Passport element which was submitted that should be resolved by the user.
///     It should be one of https://core.telegram.org/bots/api#passportelementerror
/// </summary>
public abstract class PassportElementError : IMultiTypeClassBySource<PassportErrorType>
{
    /// <summary>
    ///     Error source
    /// </summary>
    public abstract PassportErrorType Source { get; set; }

    /// <summary>
    ///     Name of the data field which has the error
    /// </summary>
    public string FieldName { get; set; }

    /// <summary>
    ///     Base64-encoded data hash
    /// </summary>
    public string DataHash { get; set; }

    /// <summary>
    ///     ErrorMessage
    /// </summary>
    public string Message { get; set; }

    public ElementType Type { get; set; }
}
