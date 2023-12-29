namespace RxTelegram.Bot.Interface.BaseTypes;

public class LinkPreviewOptions
{
    /// <summary>
    /// Optional. True, if the link preview is disabled
    /// </summary>
    public bool IsDisabled { get; set; }

    /// <summary>
    /// Optional. URL to use for the link preview. If empty, then the first URL found in the message text will be used
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// Optional. True, if the media in the link preview is suppposed to be shrunk;
    /// ignored if the URL isn't explicitly specified or media size change isn't supported for the preview
    /// </summary>
    public bool PreferSmallMedia { get; set; }

    /// <summary>
    /// Optional. True, if the media in the link preview is suppposed to be enlarged;
    /// ignored if the URL isn't explicitly specified or media size change isn't supported for the preview
    /// </summary>
    public bool PreferLargeMedia { get; set; }

    /// <summary>
    /// Optional. True, if the link preview must be shown above the message text;
    /// otherwise, the link preview will be shown below the message text
    /// </summary>
    public bool ShowAboveText { get; set; }
}
