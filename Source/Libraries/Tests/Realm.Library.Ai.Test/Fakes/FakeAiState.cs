
namespace Realm.Library.Ai.Test.Fakes

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
