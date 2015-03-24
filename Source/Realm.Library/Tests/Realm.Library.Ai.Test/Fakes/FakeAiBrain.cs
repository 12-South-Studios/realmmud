using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Library.Ai.Test
// ReSharper restore CheckNamespace
{
    public class FakeAiBrain : AiAgent
    {
        public FakeAiBrain(IEntity owner, IMessageContext handler, IBehavior behavior)
            : base(owner, handler, behavior)
        {

        }

        public override void OnTick()
        {
            CurrentState.Execute();
        }

        public override IAiState NeedState()
        {
            return new FakeAiState("test", new FakeAiBrain(Owner, new MessageContext(), new FakeBehavior()));
        }
    }
}
