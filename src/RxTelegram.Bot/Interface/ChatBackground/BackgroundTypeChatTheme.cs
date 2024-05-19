using RxTelegram.Bot.Interface.ChatBackground.Enums;

namespace RxTelegram.Bot.Interface.ChatBackground;

/// <summary>
/// The background is taken directly from a built-in chat theme.
/// </summary>
public class BackgroundTypeChatTheme : BackgroundType
{
    /// <summary>
    /// Type of the background, always “chat_theme”
    /// </summary>
    public override BackgroundTypes Type { get; set; } = BackgroundTypes.ChatTheme;

    /// <summary>
    /// Name of the chat theme, which is usually an emoji
    /// </summary>
    public string ThemeName { get; set; }
}
