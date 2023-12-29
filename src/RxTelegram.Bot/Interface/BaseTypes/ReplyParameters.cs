using System.Collections.Generic;

namespace RxTelegram.Bot.Interface.BaseTypes;

public class ReplyParameters
{
    public int MessageId { get; set; }

    public ChatId ChatId { get; set; }

    public bool AllowSendingWithoutReply { get; set; }

    public string Quote { get; set; }

    public string QuoteParseMode { get; set; }

    public List<MessageEntity> QuoteEntities { get; set; }

    public int QuotePosition { get; set; }
}
