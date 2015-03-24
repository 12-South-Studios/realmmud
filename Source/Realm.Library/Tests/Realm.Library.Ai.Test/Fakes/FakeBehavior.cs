using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Library.Ai.Test
// ReSharper restore CheckNamespace
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
