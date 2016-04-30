using Realm.Library.Ai;
using Realm.Library.Common.Objects;

namespace Realm.Server.Test.Helpers
{
    public class FakeAiState : IAiState
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public IAiAgent Parent { get; set; }
        public bool IsPaused { get; set; }
        public void Execute()
        {
        }

        public void OnEnter()
        {
        }

        public void OnLeave()
        {
        }

        public void OnPause()
        {
        }

        public void OnResume()
        {
        }

        public bool IsValid(Cell cell)
        {
            return false;
        }
    }
}
