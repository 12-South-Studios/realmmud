namespace Realm.Server
{
    public interface ILoopProcessor
    {
        void Start();
        void Stop();
        bool IsRunning { get; }

    }
}
