namespace RxTelegram.Bot.Utils.MultiType;

public interface IMultiTypeClassBySource<out T>
{
    public T Source { get; }
}
