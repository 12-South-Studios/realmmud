using FluentAssertions;
using Realm.Library.Common.Attributes;
using Realm.Library.Common.Contexts;
using Xunit;

namespace Realm.Server.Test.Realm.Server.Handlers
{
    public class BitContextTest
    {
        enum EnumTest
        {
            [Enum("One", 1)]
            Bitone = 1,

            [Enum("Two", 2)]
            Bittwo = 2,

            [Enum("Four", 4)]
            Bitfour = 4,

            [Enum("Eight", 8)]
            Biteight = 8
        }

        [Fact]
        public void BitContext_GetBits_Test()
        {
            var target = new BitContext(null);

            const int expected = 0;
            var actual = target.GetBits;
            actual.Should().Be(expected);
        }

        [Fact]
        public void BitContext_SetBits_Test()
        {
            var target = new BitContext(null);
            target.SetBits(8);

            const int expected = 8;
            var actual = target.GetBits;
            actual.Should().Be(expected);
        }

        [Fact]
        public void BitContext_SetBitInt_Test()
        {
            var target = new BitContext(null);
            target.SetBits(8);
            target.SetBit(16);

            const int expected = 24;
            var actual = target.GetBits;
            actual.Should().Be(expected);
        }

        [Fact]
        public void BitContext_SetBitEnum_Test()
        {
            var target = new BitContext(null);
            target.SetBits(8);
            target.SetBit(EnumTest.Bitfour);

            const int expected = 12;
            var actual = target.GetBits;
            actual.Should().Be(expected);  
        }

        [Fact]
        public void BitContext_HasBitInt_Test()
        {
            var target = new BitContext(null);
            target.SetBits(11);

            const bool expected = true;
            var actual = target.HasBit(2);
            actual.Should().Be(expected);
        }

        [Fact]
        public void BitContext_HasBitEnum_Test()
        {
            var target = new BitContext(null);
            target.SetBits(11);

            const bool expected = true;
            var actual = target.HasBit(EnumTest.Bittwo);
            actual.Should().Be(expected);
        }

        [Fact]
        public void BitContext_UnsetBitInt_Test()
        {
            var target = new BitContext(null);
            target.SetBits(11);
            target.UnsetBit(2);

            const bool expected = false;
            var actual = target.HasBit(2);
            actual.Should().Be(expected);
        }

        [Fact]
        public void BitContext_UnsetBitEnum_Test()
        {
            var target = new BitContext(null);
            target.SetBits(11);
            target.UnsetBit(EnumTest.Bittwo);

            const bool expected = false;
            var actual = target.HasBit(EnumTest.Bittwo);
            actual.Should().Be(expected);
        }
    }
}
