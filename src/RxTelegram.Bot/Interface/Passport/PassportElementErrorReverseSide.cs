﻿namespace RxTelegram.Bot.Interface.Passport
{
    public class PassportElementErrorReverseSide : PassportElementError
    {
        public override string Source { get; } = "reverse_side";
    }
}
