using Realm.Library.Common.Contexts;

namespace Realm.Library.Ai.Test.Fakes

{
    public class FakeBehavior : IBehavior
    {
        public IBitContext Bits
        {
            get { throw new System.NotImplementedException(); }
        }

        public IPropertyContext Properties
        {
            get { throw new System.NotImplementedException(); }
        }

        public IAiState NeedState()
        {
            return null;
        }
    }
}
