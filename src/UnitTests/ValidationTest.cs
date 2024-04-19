using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using RxTelegram.Bot.Interface.BaseTypes.Requests.Inline;
using RxTelegram.Bot.Interface.InlineMode;
using RxTelegram.Bot.Interface.InlineMode.InlineQueryResults;
using RxTelegram.Bot.Interface.Stickers;
using RxTelegram.Bot.Interface.Stickers.Enums;
using RxTelegram.Bot.Interface.Stickers.Requests;
using RxTelegram.Bot.Interface.Validation;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.UnitTests;

[TestFixture]
public class ValidationTest
{
    [Test]
    public void TestFactoryExists()
    {
        var classesToValidate = Assembly.GetAssembly(typeof(BaseValidation))
                                        ?.GetTypes()
                                        .Where(myType => myType.IsClass &&
                                                         !myType.IsAbstract &&
                                                         myType.IsSubclassOf(typeof(BaseValidation)));
        Assert.That(classesToValidate, Is.Not.Null);
        var objects = classesToValidate.Select(type => (BaseValidation) Activator.CreateInstance(type, null))
                                       .ToList();

        foreach (var o in objects)
        {
            Assert.DoesNotThrow(() => o.IsValid(), $"Type was: {o.GetType()}");
        }
    }

    [Test]
    public void TestInvalid()
    {
        var obj = new CreateNewStickerSet();
        Assert.That(obj.IsValid(), Is.False);
        Assert.That(obj.Errors.Count, Is.EqualTo(5));
        var errors = obj.Errors.Select(x => x.GetMessage)
                        .ToList();
        CollectionAssert.Contains(errors, "(Name): \"Field is not set, but required\"");
        CollectionAssert.Contains(errors, "(UserId): \"ID lower than 1 is not allowed.\"");
        CollectionAssert.Contains(errors, "(Title): \"Field is not set, but required\"");
        CollectionAssert.Contains(errors, "(Name): \"Stickersets Created by bots need to end with _by_<botname> \"");
        CollectionAssert.Contains(errors, "(Stickers): \"Field is not set, but required\"");
    }

    [Test]
    public void TestNestedValid()
    {
        var obj = new AnswerInlineQuery
                  {
                      Results = new[]
                                {
                                    new InlineQueryResultArticle
                                    {
                                        InputMessageContent =
                                            new InputTextMessageContent()
                                    }
                                }
                  };
        Assert.That(obj.IsValid(), Is.False);
        Assert.That(obj.Errors.Count, Is.EqualTo(4));
        var errors = obj.Errors.Select(x => x.GetMessage)
                        .ToList();
        CollectionAssert.Contains(errors, "(Results[0].InputMessageContent.MessageText): \"Field is not set, but required\"");
        CollectionAssert.Contains(errors, "(Results[0].Id): \"Field is not set, but required\"");
        CollectionAssert.Contains(errors, "(Results[0].Title): \"Field is not set, but required\"");
        CollectionAssert.Contains(errors, "(InlineQueryId): \"Field is not set, but required\"");
    }

    [Test]
    public void TestValid()
    {
        var obj = new CreateNewStickerSet
                  {
                      UserId = 2,
                      Name = "StickerSet_by_BlaBot",
                      Title = "Title",
                      Stickers = new List<InputSticker>()
                  };
        Assert.That(obj.IsValid());
        Assert.That(obj.Errors.Count, Is.EqualTo(0));
    }

    [Test]
    public void ValidationErrorStringAttributePresentTest()
    {
        foreach (var value in Enum.GetValues<ValidationErrors>())
        {
            var memInfo = value.GetType().GetMember(value.ToString());
            var attributes = memInfo[0]
                .GetCustomAttributes(typeof(ValidationErrorsStringAttribute), false);
            Assert.That(attributes.FirstOrDefault(), Is.Not.Null);
        }
    }
}
