using System;
using NUnit.Framework;
using Realm.Ai.States;

namespace Realm.Ai.Test
{
    [TestFixture]
    public class AiStateFactoryHelperTests
    {
        [TestCase("invalid", null)]
        [TestCase("chase", typeof(AiChaseState))]
        public void Get(string value, Type expected)
        {
            var helper = new AiStateFactoryHelper();

            Assert.That(helper.Get(value), Is.EqualTo(expected));
        }
    }
}
