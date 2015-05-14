namespace Realm.Library.Ai.Test
{
    public static class Helper
    {
        public static FakeAiBrain GetBrain()
        {
            return new FakeAiBrain(new FakeEntity(1, "test"), new MessageContext(), new FakeBehavior());
        }
    }
}
