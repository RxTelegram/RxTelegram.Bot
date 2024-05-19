using RxTelegram.Bot.Interface.BaseTypes;

namespace RxTelegram.Bot.Interface.Business;

public class BusinessLocation
{
    /// <summary>
    /// Address of the business
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Optional. Location of the business
    /// </summary>
    public Location Location { get; set; }
}
