﻿namespace RxTelegram.Bot.Interface.Passport;

/// <summary>
///     Contains data required for decrypting and authenticating <see cref="EncryptedPassportElement" /> .
///     See the https://core.telegram.org/passport#receiving-information for a complete description of the data decryption
///     and authentication processes.
/// </summary>
public class EncryptedCredentials
{
    /// <summary>
    ///     Base64-encoded encrypted JSON-serialized data with unique user's payload,
    ///     data hashes and secrets required for <see cref="EncryptedPassportElement" /> decryption and authentication
    /// </summary>
    public string Data { get; set; }

    /// <summary>
    ///     Base64-encoded data hash for data authentication
    /// </summary>
    public string Hash { get; set; }

    /// <summary>
    ///     Base64-encoded secret, encrypted with the bot's public RSA key, required for data decryption
    /// </summary>
    public string Secret { get; set; }
}