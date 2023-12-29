using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.Messages;

/// <summary>
/// Use this method to delete multiple messages simultaneously.
/// If some of the specified messages can't be found, they are skipped. Returns True on success.
/// </summary>
public class DeleteMessages : BaseRequest
{
    /// <summary>
    /// Identifiers of 1-100 messages to delete. See <see cref="DeleteMessage"/> for limitations on which messages can be deleted
    /// </summary>
    public List<long> MessageIds { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
