using RxTelegram.Bot.Interface.Payments;
using RxTelegram.Bot.Utils.MultiType;

namespace RxTelegram.Bot.Interface.BaseTypes.Enums;

public enum TransactionPartnerType
{
    [ImplementationType(typeof(TransactionPartnerUser))]
    User,

    [ImplementationType(typeof(TransactionPartnerFragment))]
    Fragment,


    [ImplementationType(typeof(TransactionPartnerTelegramAds))]
    TelegramAds,

    [ImplementationType(typeof(TransactionPartnerOther))]
    Other,

    [ImplementationType(typeof(TransactionPartnerTelegramApi))]
    TelegramApi,

    [ImplementationType(typeof(TransactionPartnerAffiliateProgram))]
    AffiliateProgram,

    [ImplementationType(typeof(TransactionPartnerChat))]
    Chat
}
