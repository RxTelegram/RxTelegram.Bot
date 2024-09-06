using RxTelegram.Bot.Interface.BaseTypes;

namespace RxTelegram.Bot.Interface.Payments;

public class PaidMediaPurchased
{
    public User From { get; set; }

    public string PaidMediaPayload { get; set; }
}
