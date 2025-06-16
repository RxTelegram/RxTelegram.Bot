namespace RxTelegram.Bot.Interface.Business;

/// <summary>
/// Represents the rights of a business bot.
/// </summary>
public class BusinessBotRights
{
    /// <summary>
    /// Optional. True, if the bot can send and edit messages in the private chats that had incoming messages in the last 24 hours
    /// </summary>
    public bool? CanReply { get; set; }

    /// <summary>
    /// Optional. True, if the bot can mark incoming private messages as read
    /// </summary>
    public bool? CanReadMessages { get; set; }

    /// <summary>
    /// Optional. True, if the bot can delete messages sent by the bot
    /// </summary>
    public bool? CanDeleteSentMessages { get; set; }

    /// <summary>
    /// Optional. True, if the bot can delete all private messages in managed chats
    /// </summary>
    public bool? CanDeleteAllMessages { get; set; }

    /// <summary>
    /// Optional. True, if the bot can edit the first and last name of the business account
    /// </summary>
    public bool? CanEditName { get; set; }

    /// <summary>
    /// Optional. True, if the bot can edit the bio of the business account
    /// </summary>
    public bool? CanEditBio { get; set; }

    /// <summary>
    /// Optional. True, if the bot can edit the profile photo of the business account
    /// </summary>
    public bool? CanEditProfilePhoto { get; set; }

    /// <summary>
    /// Optional. True, if the bot can edit the username of the business account
    /// </summary>
    public bool? CanEditUsername { get; set; }

    /// <summary>
    /// Optional. True, if the bot can change the privacy settings pertaining to gifts for the business account
    /// </summary>
    public bool? CanChangeGiftSettings { get; set; }

    /// <summary>
    /// Optional. True, if the bot can view gifts and the amount of Telegram Stars owned by the business account
    /// </summary>
    public bool? CanViewGiftsAndStars { get; set; }

    /// <summary>
    /// Optional. True, if the bot can convert regular gifts owned by the business account to Telegram Stars
    /// </summary>
    public bool? CanConvertGiftsToStars { get; set; }

    /// <summary>
    /// Optional. True, if the bot can transfer and upgrade gifts owned by the business account
    /// </summary>
    public bool? CanTransferAndUpgradeGifts { get; set; }

    /// <summary>
    /// Optional. True, if the bot can transfer Telegram Stars received by the business account to its own account, or use them to upgrade and transfer gifts
    /// </summary>
    public bool? CanTransferStars { get; set; }

    /// <summary>
    /// Optional. True, if the bot can post, edit and delete stories on behalf of the business account
    /// </summary>
    public bool? CanManageStories { get; set; }
}
