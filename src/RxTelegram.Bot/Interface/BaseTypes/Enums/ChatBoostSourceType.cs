using RxTelegram.Bot.Utils.MultiType;

namespace RxTelegram.Bot.Interface.BaseTypes.Enums;

public enum ChatBoostSourceType
{
    [ImplementationType(typeof(ChatBoostSourcePremium))]
    Premium,

    [ImplementationType(typeof(ChatBoostSourceGiftCode))]
    GiftCode,

    [ImplementationType(typeof(ChatBoostSourceGiveaway))]
    Giveaway
}
