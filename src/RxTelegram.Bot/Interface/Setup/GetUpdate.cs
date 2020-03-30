using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes.Enums;

namespace RxTelegram.Bot.Interface.Setup
{
    public class GetUpdate
    {
        public int? Offset { get; set; }

        public int? Limit { get; set; }

        public int? Timeout { get; set; }

        public IEnumerable<UpdateType> AllowedUpdates { get; set; }
    }
}
