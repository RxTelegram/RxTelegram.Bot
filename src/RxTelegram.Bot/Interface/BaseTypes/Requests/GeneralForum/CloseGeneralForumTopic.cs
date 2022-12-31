using RxTelegram.Bot.Interface.BaseTypes.Requests.Base;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.Interface.BaseTypes.Requests.GeneralForum;

public class CloseGeneralForumTopic : BaseRequest
{
    protected override IValidationResult Validate() => this.CreateValidation();
}
