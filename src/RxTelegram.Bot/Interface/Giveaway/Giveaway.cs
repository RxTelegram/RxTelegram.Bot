using System;
using System.Collections.Generic;
using RxTelegram.Bot.Interface.BaseTypes;

namespace RxTelegram.Bot.Interface.Giveaway;

/// <summary>
/// This object represents a message about a scheduled giveaway.
/// </summary>
public class Giveaway
{
    /// <summary>
    /// The list of chats which the user must join to participate in the giveaway
    /// </summary>
    public List<Chat> Chats { get; set; }

    /// <summary>
    /// Point in time (Unix timestamp) when winners of the giveaway will be selected
    /// </summary>
    public DateTime WinnersSelectionDate { get; set; }

    /// <summary>
    /// The number of users which are supposed to be selected as winners of the giveaway
    /// </summary>
    public int WinnerCount { get; set; }

    /// <summary>
    /// Optional. True, if only users who join the chats after the giveaway started should be eligible to win
    /// </summary>
    public bool OnlyNewMembers { get; set; }

    /// <summary>
    /// Optional. True, if the list of giveaway winners will be visible to everyone
    /// </summary>
    public bool HasPublicWinners { get; set; }

    /// <summary>
    /// Optional. Description of additional giveaway prize
    /// </summary>
    public string PrizeDescription { get; set; }

    /// <summary>
    /// Optional. A list of two-letter ISO 3166-1 alpha-2 country codes indicating the countries from which eligible users for the giveaway must come.
    /// If empty, then all users can participate in the giveaway. Users with a phone number that was bought on Fragment can always participate in giveaways.
    /// </summary>
    public List<string> CountryCodes { get; set; }

    /// <summary>
    /// Optional. The number of months the Telegram Premium subscription won from the giveaway will be active for
    /// </summary>
    public int PremiumSubscriptionMonthCount { get; set; }
}
