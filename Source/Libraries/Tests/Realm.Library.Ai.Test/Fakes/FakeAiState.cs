// ReSharper disable CheckNamespace
namespace Realm.Library.Ai.Test
// ReSharper restore CheckNamespace
{
    public class FakeAiState : AiState
    {
        public FakeAiState(string name, IAiAgent parent)
            : base(name, parent)
        {
        }

        public override void Execute()
        {
            Parent.Messages.Add("Test");
        }
    }
}
