namespace RxTelegram.Bot.Interface.ChatBackground;

/// <summary>
/// The background is taken directly from a built-in chat theme.
/// </summary>
public class BackgroundTypeChatTheme : BackgroundType
{
    /// <summary>
    /// Type of the background, always “chat_theme”
    /// </summary>
    public override string Type { get; } = "chat_theme";

    /// <summary>
    /// Name of the chat theme, which is usually an emoji
    /// </summary>
    public string ThemeName { get; set; }

}
