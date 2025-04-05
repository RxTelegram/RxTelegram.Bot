using System;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using RxTelegram.Bot.Api;
using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.InlineMode;
using RxTelegram.Bot.Interface.Payments;
using RxTelegram.Bot.Interface.Reaction;
using RxTelegram.Bot.Interface.Setup;

namespace RxTelegram.Bot.UnitTests;

[TestFixture]
public class UpdateManagerTest
{
    private ITelegramBot _telegramBotMock = Substitute.For<ITelegramBot>();

    public static Array GetUpdateTypes() => Enum.GetValues(typeof(UpdateType));

    [SetUp]
    public void TestInitialize() => _telegramBotMock = Substitute.For<ITelegramBot>();

    [Test]
    public void TestGetUpdateTypes()
    {
        var botInfo = new BotInfo("123456:ABC-DEFG1234ghIkl-zyx57W2v1u123ew11");
        var telegram = new TelegramBot(botInfo);
        var updateManager = new UpdateManager(telegram);
        updateManager.Message.Subscribe();
        updateManager.EditedChannelPost.Subscribe();

        var updateTypes = updateManager.UpdateTypes.ToList();
        Assert.That(updateTypes.Count, Is.EqualTo(2));
        CollectionAssert.Contains(updateTypes, UpdateType.Message);
        CollectionAssert.Contains(updateTypes, UpdateType.EditedChannelPost);
    }

    [Test]
    public void Constructor_InitializesCorrectly()
    {
        // Arrange
        var updateManager = new UpdateManager(_telegramBotMock);

        // Assert
        Assert.That(updateManager.Update, Is.Not.Null);
        Assert.That(updateManager.Message, Is.Not.Null);
        Assert.That(updateManager.EditedMessage, Is.Not.Null);
        Assert.That(updateManager.InlineQuery, Is.Not.Null);
        Assert.That(updateManager.ChosenInlineResult, Is.Not.Null);
        Assert.That(updateManager.CallbackQuery, Is.Not.Null);
        Assert.That(updateManager.ChannelPost, Is.Not.Null);
        Assert.That(updateManager.EditedChannelPost, Is.Not.Null);
        Assert.That(updateManager.ShippingQuery, Is.Not.Null);
        Assert.That(updateManager.PreCheckoutQuery, Is.Not.Null);
        Assert.That(updateManager.Poll, Is.Not.Null);
        Assert.That(updateManager.PollAnswer, Is.Not.Null);
        Assert.That(updateManager.MyChatMember, Is.Not.Null);
        Assert.That(updateManager.ChatMember, Is.Not.Null);
        Assert.That(updateManager.ChatJoinRequest, Is.Not.Null);
        Assert.That(updateManager.ChatBoost, Is.Not.Null);
        Assert.That(updateManager.RemovedChatBoost, Is.Not.Null);
    }

    [Test]
    [TestCaseSource(nameof(GetUpdateTypes))]
    public void Subscribe_Should_Add_Observer_And_Retain_In_Observers_List(UpdateType updateType)
    {
        // Arrange
        var updateObserverMock = Substitute.For<IObserver<Update>>();

        // Act
        var updateManager = new UpdateManager(_telegramBotMock);
        updateManager.Subscribe(updateType, updateObserverMock);

        // Assert
        Assert.That(updateManager.GetObservers(updateType), Contains.Item(updateObserverMock));
    }

    [Test]
    [TestCaseSource(nameof(GetUpdateTypes))]
    public async Task Remove_Should_Remove_Observer_From_Observers_List(UpdateType updateType)
    {
        // Arrange
        var updateObserverMock = Substitute.For<IObserver<Update>>();
        var updateManager = new UpdateManager(_telegramBotMock);

        // Act
        await updateManager.RunUpdateSafe();
        updateManager.Subscribe(updateType, updateObserverMock);
        updateManager.Remove(updateType, updateObserverMock);

        // Assert
        CollectionAssert.DoesNotContain(updateManager.GetObservers(updateType), updateObserverMock);
    }

    [Test]
    public void Given_TelegramBotException_On_RunUpdateSafe_Should_Handle_Exception()
    {
        // Arrange
        _telegramBotMock.GetUpdate(default)
                        .ThrowsForAnyArgs(new Exception());

        // Assert
        Assert.DoesNotThrowAsync(() =>
                                 {
                                     var updateManager = new UpdateManager(_telegramBotMock);
                                     updateManager.RunUpdateSafe().GetAwaiter().GetResult();
                                     return Task.CompletedTask;
                                 });
    }

    [Test]
    public void Given_NoObserver_On_RunUpdate_Should_Return()
    {
        // Arrange
        var updateManager = new UpdateManager(_telegramBotMock);

        // Assert
        Assert.DoesNotThrowAsync(() =>
        {
            updateManager.RunUpdate().GetAwaiter().GetResult();
            return Task.CompletedTask;
        });
    }

    [Test]
    public void Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_Observers()
    {
        // Arrange
        var observer = Substitute.For<IObserver<Update>>();
        var updateManager = new UpdateManager(_telegramBotMock);
        var disposableAll = updateManager.Update.Subscribe(observer);
        var updates = new[] { new Update { Message = new Message() } };

        // Act
        updateManager.DistributeUpdates(updates);

        // Assert
        observer.Received()
                   .OnNext(updates.Single());
        disposableAll.Dispose();
    }

    [Test]
    [TestCaseSource(nameof(GetUpdateTypes))]
    public void OnException_WhenCalled_DistributesExceptionToObservers(UpdateType updateType)
    {
        // Arrange
        var telegramBotMock = Substitute.For<ITelegramBot>();
        var updateManager = new UpdateManager(telegramBotMock);
        var observer1Mock = Substitute.For<IObserver<Update>>();
        var observer2Mock = Substitute.For<IObserver<Update>>();
        // Assuming that Subscribe method works as expected and adds observers correctly
        updateManager.Subscribe(updateType, observer1Mock);
        updateManager.Subscribe(updateType, observer2Mock);

        var exception = new Exception();

        // Act
        try
        {
            updateManager.OnException(exception);
        }
        catch
        {
            // ignored
        }

        // Assert
        observer1Mock.Received()
                     .OnError(exception);
        observer2Mock.Received()
                     .OnError(exception);
    }

    #region UpdateTypes

    [Test]
    public void Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_MessageObservers()
    {
        // Arrange
        var observer = Substitute.For<IObserver<Message>>();
        var updateManager = new UpdateManager(_telegramBotMock);
        var disposableAll = updateManager.Message.Subscribe(observer);
        var updates = new[] { new Update { Message = new Message() } };

        // Act
        updateManager.DistributeUpdates(updates);

        // Assert
        observer.Received()
                   .OnNext(updates.Single()
                                  .Message);
        disposableAll.Dispose();
    }

    [Test]
    public void Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_EditedMessageObservers()
    {
        // Arrange
        var observer = Substitute.For<IObserver<Message>>();
        var updateManager = new UpdateManager(_telegramBotMock);
        var disposableAll = updateManager.EditedMessage.Subscribe(observer);
        var updates = new[] { new Update { EditedMessage = new Message() } };

        // Act
        updateManager.DistributeUpdates(updates);

        // Assert
        observer.Received()
                   .OnNext(updates.Single()
                                  .EditedMessage);
        disposableAll.Dispose();
    }

    [Test]
    public void Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_InlineQueryObservers()
    {
        // Arrange
        var observer = Substitute.For<IObserver<InlineQuery>>();
        var updateManager = new UpdateManager(_telegramBotMock);
        var disposableAll = updateManager.InlineQuery.Subscribe(observer);
        var updates = new[] { new Update { InlineQuery = new InlineQuery() } };

        // Act
        updateManager.DistributeUpdates(updates);

        // Assert
        observer.Received()
                   .OnNext(updates.Single()
                                  .InlineQuery);
        disposableAll.Dispose();
    }

    [Test]
    public void Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_ChosenInlineResultObservers()
    {
        // Arrange
        var observer = Substitute.For<IObserver<ChosenInlineResult>>();
        var updateManager = new UpdateManager(_telegramBotMock);
        var disposableAll = updateManager.ChosenInlineResult.Subscribe(observer);
        var updates = new[] { new Update { ChosenInlineResult = new ChosenInlineResult() } };

        // Act
        updateManager.DistributeUpdates(updates);

        // Assert
        observer.Received()
                   .OnNext(updates.Single()
                                  .ChosenInlineResult);
        disposableAll.Dispose();
    }

    [Test]
    public void Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_CallbackQueryObservers()
    {
        // Arrange
        var observer = Substitute.For<IObserver<CallbackQuery>>();
        var updateManager = new UpdateManager(_telegramBotMock);
        var disposableAll = updateManager.CallbackQuery.Subscribe(observer);
        var updates = new[] { new Update { CallbackQuery = new CallbackQuery() } };

        // Act
        updateManager.DistributeUpdates(updates);

        // Assert
        observer.Received()
                   .OnNext(updates.Single()
                                  .CallbackQuery);
        disposableAll.Dispose();
    }

    [Test]
    public void Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_ChannelPostObservers()
    {
        // Arrange
        var observer = Substitute.For<IObserver<Message>>();
        var updateManager = new UpdateManager(_telegramBotMock);
        var disposableAll = updateManager.ChannelPost.Subscribe(observer);
        var updates = new[] { new Update { ChannelPost = new Message() } };

        // Act
        updateManager.DistributeUpdates(updates);

        // Assert
        observer.Received()
                   .OnNext(updates.Single()
                                  .ChannelPost);
        disposableAll.Dispose();
    }

    [Test]
    public void Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_EditedChannelPostObservers()
    {
        // Arrange
        var observer = Substitute.For<IObserver<Message>>();
        var updateManager = new UpdateManager(_telegramBotMock);
        var disposableAll = updateManager.EditedChannelPost.Subscribe(observer);
        var updates = new[] { new Update { EditedChannelPost = new Message() } };

        // Act
        updateManager.DistributeUpdates(updates);

        // Assert
        observer.Received()
                   .OnNext(updates.Single()
                                  .EditedChannelPost);
        disposableAll.Dispose();
    }

    [Test]
    public void Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_ShippingQueryObservers()
    {
        // Arrange
        var observer = Substitute.For<IObserver<ShippingQuery>>();
        var updateManager = new UpdateManager(_telegramBotMock);
        var disposableAll = updateManager.ShippingQuery.Subscribe(observer);
        var updates = new[] { new Update { ShippingQuery = new ShippingQuery() } };

        // Act
        updateManager.DistributeUpdates(updates);

        // Assert
        observer.Received()
                   .OnNext(updates.Single()
                                  .ShippingQuery);
        disposableAll.Dispose();
    }

    [Test]
    public void Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_PreCheckoutQueryObservers()
    {
        // Arrange
        var observer = Substitute.For<IObserver<PreCheckoutQuery>>();
        var updateManager = new UpdateManager(_telegramBotMock);
        var disposableAll = updateManager.PreCheckoutQuery.Subscribe(observer);
        var updates = new[] { new Update { PreCheckoutQuery = new PreCheckoutQuery() } };

        // Act
        updateManager.DistributeUpdates(updates);

        // Assert
        observer.Received()
                   .OnNext(updates.Single()
                                  .PreCheckoutQuery);
        disposableAll.Dispose();
    }

    [Test]
    public void Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_PollObservers()
    {
        // Arrange
        var observer = Substitute.For<IObserver<Poll>>();
        var updateManager = new UpdateManager(_telegramBotMock);
        var disposableAll = updateManager.Poll.Subscribe(observer);
        var updates = new[] { new Update { Poll = new Poll() } };

        // Act
        updateManager.DistributeUpdates(updates);

        // Assert
        observer.Received()
                   .OnNext(updates.Single()
                                  .Poll);
        disposableAll.Dispose();
    }

    [Test]
    public void Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_PollAnswerObservers()
    {
        // Arrange
        var observer = Substitute.For<IObserver<PollAnswer>>();
        var updateManager = new UpdateManager(_telegramBotMock);
        var disposableAll = updateManager.PollAnswer.Subscribe(observer);
        var updates = new[] { new Update { PollAnswer = new PollAnswer() } };

        // Act
        updateManager.DistributeUpdates(updates);

        // Assert
        observer.Received()
                   .OnNext(updates.Single()
                                  .PollAnswer);
        disposableAll.Dispose();
    }

    private void Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_Observers<T>(
        Update update,
        Func<UpdateManager,IObservable<T>> observable,
        Func<Update, T> selector)
    {
        // Arrange
        var observer = Substitute.For<IObserver<T>>();
        var updateManager = new UpdateManager(_telegramBotMock);
        var disposableAll = observable(updateManager).Subscribe(observer);
        Update[] updates = [update];

        // Act
        updateManager.DistributeUpdates(updates);

        // Assert
        observer.Received()
                   .OnNext(selector(updates.Single()));
        disposableAll.Dispose();
    }

    [Test]
    public void Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_ChatMemberObservers()
        => Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_Observers(
            new Update { ChatMember = new ChatMemberUpdated() },
            (UpdateManager updateManager) => updateManager.ChatMember,
            (Update update) => update.ChatMember);

    [Test]
    public void Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_MyChatMemberObservers()
        => Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_Observers(
            new Update { MyChatMember = new ChatMemberUpdated() },
            (UpdateManager updateManager) => updateManager.MyChatMember,
            (Update update) => update.MyChatMember);

    [Test]
    public void Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_ChatJoinRequestObservers()
        => Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_Observers(
            new Update { ChatJoinRequest = new ChatJoinRequest() },
            (UpdateManager updateManager) => updateManager.ChatJoinRequest,
            (Update update) => update.ChatJoinRequest);

    [Test]
    public void Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_ChatBoostObservers()
        => Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_Observers(
            new Update { ChatBoost = new ChatBoostUpdated() },
            (UpdateManager updateManager) => updateManager.ChatBoost,
            (Update update) => update.ChatBoost);

    [Test]
    public void Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_RemovedChatBoostObservers()
        => Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_Observers(
            new Update { RemovedChatBoost = new ChatBoostRemoved() },
            (UpdateManager updateManager) => updateManager.RemovedChatBoost,
            (Update update) => update.RemovedChatBoost);

    [Test]
    public void Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_MessageReactionObservers()
        => Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_Observers(
            new Update { MessageReaction = new MessageReactionUpdated() },
            (UpdateManager updateManager) => updateManager.MessageReaction,
            (Update update) => update.MessageReaction);

    [Test]
    public void Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_MessageReactionCountObservers()
        => Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_Observers(
            new Update { MessageReactionCount = new MessageReactionCountUpdated() },
            (UpdateManager updateManager) => updateManager.MessageReactionCount,
            (Update update) => update.MessageReactionCount);

    #endregion
}
