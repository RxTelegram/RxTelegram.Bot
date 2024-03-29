﻿namespace RxTelegram.Bot.Interface.Stickers;

/// <summary>
/// The part of the face relative to which the mask should be placed. One of "forehead", "eyes", "mouth", or "chin".
/// </summary>
public enum MaskPositionPoint
{
    /// <summary>
    /// The forehead
    /// </summary>
    Forehead,

    /// <summary>
    /// The eyes
    /// </summary>
    Eyes,

    /// <summary>
    /// The mouth
    /// </summary>
    Mouth,

    /// <summary>
    /// The chin
    /// </summary>
    Chin
}
