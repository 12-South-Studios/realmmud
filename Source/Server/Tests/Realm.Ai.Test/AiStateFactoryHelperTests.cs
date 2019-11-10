using System;
using FluentAssertions;
using Realm.Ai.States;
using Xunit;

namespace Realm.Ai.Test
{
    public class AiStateFactoryHelperTests
    {
        [Theory]
        [InlineData("invalid", null)]
        [InlineData("chase", typeof(AiChaseState))]
        public void Get(string value, Type expected)
        {
            var helper = new AiStateFactoryHelper();

            var result = helper.Get(value);
            result.Should().Be(expected);
        }
    }
}
