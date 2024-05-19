using System.Collections.Generic;

namespace RxTelegram.Bot.Interface.Business;

public class BusinessOpeningHours
{
    /// <summary>
    /// Unique name of the time zone for which the opening hours are defined
    /// </summary>
    public string TimeZoneName { get; set; }

    /// <summary>
    /// List of time intervals describing business opening hours
    /// </summary>
    public List<BusinessOpeningHoursInterval> OpeningHours { get; set; }
}
