using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.Business.Requests;

/// <summary>
/// Delete messages on behalf of a business account.
/// Requires the can_delete_sent_messages business bot right to delete messages sent by the bot itself,
/// or the can_delete_all_messages business bot right to delete any message.
/// </summary>
public class DeleteBusinessMessages : BaseBusinessRequest
{
    /// <summary>
    /// Required
    /// A JSON-serialized list of 1-100 identifiers of messages to delete.
    /// All messages must be from the same chat. See <see cref="!:https://core.telegram.org/bots/api#deletemessage"/> for limitations on which messages can be deleted
    /// </summary>
    public List<int> MessageIds { get; set; }

    protected override IValidationResult Validate() => this.CreateValidation();
}
