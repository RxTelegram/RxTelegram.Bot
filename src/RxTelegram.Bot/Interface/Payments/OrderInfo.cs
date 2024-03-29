﻿namespace RxTelegram.Bot.Interface.Payments;

/// <summary>
///     This object represents information about an order. https://core.telegram.org/bots/api#orderinfo"
/// </summary>
public class OrderInfo
{
    /// <summary>
    ///     Optional. User name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Optional. User's phone number
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    ///     Optional. User email
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    ///     Optional. User shipping address
    /// </summary>
    public ShippingAddress ShippingAddress { get; set; }
}