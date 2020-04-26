namespace RxTelegram.Bot.Interface.BaseTypes
{
    public class ChatId
    {
        public static implicit operator ChatId(string username) => new ChatId
                                                                   {
                                                                       Username =  username
                                                                   };

        public static implicit operator ChatId(int identifier) => new ChatId
                                                                  {
                                                                      Identifier = identifier
                                                                  };

        public static implicit operator ChatId(long identifier) => new ChatId
                                                                   {
                                                                       Identifier = identifier
                                                                   };

        private ChatId()
        {
        }

        /// <summary>
        /// Unique identifier for the chat
        /// </summary>
        public long? Identifier { get; set; }

        /// <summary>
        /// Username of the channel (in the format @channelusername)
        /// </summary>
        public string Username { get; set; }

        internal bool HasValue => Identifier.HasValue || !string.IsNullOrEmpty(Username);
    }
}
