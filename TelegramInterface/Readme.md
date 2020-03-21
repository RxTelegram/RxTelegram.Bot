# C# Implementation of the Telegram Bots API
This project contains a basic implementation of the 4.6 Version of the Telegram Bots Api.


## There are just a few Types missing.

### Inline mode
Only the base Result type is implemented as an abstract class. For further Details see [Inline Query Result](https://core.telegram.org/bots/api#inlinequeryresult).
* InlineQueryResultCachedAudio
* InlineQueryResultCachedDocument
* InlineQueryResultCachedGif
* InlineQueryResultCachedMpeg4Gif
* InlineQueryResultCachedPhoto
* InlineQueryResultCachedSticker
* InlineQueryResultCachedVideo
* InlineQueryResultCachedVoice
* InlineQueryResultArticle
* InlineQueryResultAudio
* InlineQueryResultContact
* InlineQueryResultGame
* InlineQueryResultDocument
* InlineQueryResultGif
* InlineQueryResultLocation
* InlineQueryResultMpeg4Gif
* InlineQueryResultPhoto
* InlineQueryResultVenue
* InlineQueryResultVideo
* InlineQueryResultVoice

### Telegram Passport
Only the base Error type is implemented as an abstract class. For further Details see [PassportElementError](https://core.telegram.org/bots/api#passportelementerror).
* PassportElementErrorDataField
* PassportElementErrorFrontSide
* PassportElementErrorReverseSide
* PassportElementErrorSelfie
* PassportElementErrorFile
* PassportElementErrorFiles
* PassportElementErrorTranslationFile
* PassportElementErrorTranslationFiles
* PassportElementErrorUnspecified

## Todos
* Create Enums for all string fields in the api types that can only contain a specified number of values, so we can map them easily.

(Last Updated: 21/03/2020)
