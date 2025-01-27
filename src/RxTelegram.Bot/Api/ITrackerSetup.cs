using RxTelegram.Bot.Interface.BaseTypes.Enums;
using System.Collections.Generic;

namespace RxTelegram.Bot.Api;

public interface ITrackerSetup
{
  void Set(IEnumerable<UpdateType> types);
}
