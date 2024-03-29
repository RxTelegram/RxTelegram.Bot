﻿using System;
using System.Text.RegularExpressions;
using RxTelegram.Bot.Exceptions;

namespace RxTelegram.Bot;

public class BotInfo
{
    private string _token;
    private const string BaseUrl = "https://api.telegram.org/bot";
    private const string BaseFileUrl = "https://api.telegram.org/file/bot";

    /// <summary>
    /// The access token for the bot
    /// </summary>
    public string Token
    {
        get => _token;
        private set
        {
            ValidateToken(value);
            Id = GetBotIdFromToken(value);
            BotUrl = $"{BaseUrl}{value}/";
            BotFileUrl = $"{BaseFileUrl}{value}/";
            _token = value;
        }
    }

    /// <summary>
    /// The identifier for the Bot
    /// </summary>
    public long Id { get; private set; }

    /// <summary>
    /// Base url for the api methods
    /// </summary>
    public string BotUrl { get; private set; }

    /// <summary>
    /// Base url for the files send and received by the bot
    /// </summary>
    public string BotFileUrl { get; private set; }

    /// <summary>
    /// Creates a new BotInfo instance
    /// </summary>
    /// <param name="token">The bot token generated by @botFather</param>
    public BotInfo(string token) => Token = token;

    /// <summary>
    /// Checks if the given token is a valid token based on regex.
    /// </summary>
    /// <param name="token">The bot token generated by @botFather</param>
    /// <exception cref="ArgumentNullException"></exception>
    private static void ValidateToken(string token)
    {
        if (token == null)
        {
            throw new ArgumentNullException(nameof(token));
        }

        const string pattern = "[0-9]{6,19}:[a-zA-Z0-9_-]{34,35}";
        if (!Regex.IsMatch(token, pattern, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100)))
        {
            throw new InvalidTokenException(token);
        }
    }

    /// <summary>
    /// Returns the bot id from a given bot token
    /// </summary>
    /// <param name="token">The bot token generated by @botFather</param>
    /// <returns>Id of the bot</returns>
    /// <exception cref="InvalidTokenException">Is thrown if the token does not contain a valid bot id</exception>
    private static long GetBotIdFromToken(string token)
    {
        var tokenParts = token.Split(':');
        if (tokenParts.Length == 2 && long.TryParse(tokenParts[0], out var id))
        {
            return id;
        }

        throw new InvalidTokenException(token);
    }
}
