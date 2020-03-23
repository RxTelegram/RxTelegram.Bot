namespace TelegramInterface.Passport
{
    /// <summary>
    /// This object represents a file uploaded to Telegram Passport.
    /// Currently all Telegram Passport files are in JPEG format when decrypted and don't exceed 10MB.
    /// <see cref="https://core.telegram.org/bots/api#passportfile"/>
    /// </summary>
    public class PassportFile
    {
        /// <summary>
        /// Identifier for this file, which can be used to download or reuse the file
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// Unique identifier for this file, which is supposed to be the same over time and for different bots.
        /// Can't be used to download or reuse the file.
        /// </summary>
        public string FileUniqueId { get; set; }

        /// <summary>
        /// File size
        /// </summary>
        public int FileSize { get; set; }

        /// <summary>
        /// Unix time when the file was uploaded
        /// </summary>
        public int FileDate { get; set; }
    }
}
