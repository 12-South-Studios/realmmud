using System;
using Realm.Library.Ai;
using Realm.Library.Common.Objects;

namespace Realm.Ai.Test.Fakes
{
    public class FakeAiState : IAiState 
    {
        public long ID { get; private set; }
        public string Name { get; private set; }
        public IAiAgent Parent { get; private set; }
        public bool IsPaused { get; private set; }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void OnEnter()
        {
            throw new NotImplementedException();
        }

        public void OnLeave()
        {
            throw new NotImplementedException();
        }

        public void OnPause()
        {
            throw new NotImplementedException();
        }

        public void OnResume()
        {
            throw new NotImplementedException();
        }

        public bool IsValid(Cell cell)
        {
            throw new NotImplementedException();
        }
    }
}
