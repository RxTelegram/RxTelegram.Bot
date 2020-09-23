using System.Collections.Generic;

namespace RxTelegram.Bot.Interface.Passport
{
    /// <summary>
    ///     Contains information about Telegram Passport data shared with the bot by the user.
    ///     https://core.telegram.org/bots/api#passportdata
    /// </summary>
    public class PassportData
    {
        /// <summary>
        ///     Array with information about documents and other Telegram Passport elements that was shared with the bot
        /// </summary>
        public IEnumerable<EncryptedPassportElement> Data { get; set; }

        /// <summary>
        ///     Encrypted credentials required to decrypt the data
        /// </summary>
        public EncryptedCredentials Credentials { get; set; }
    }
}
