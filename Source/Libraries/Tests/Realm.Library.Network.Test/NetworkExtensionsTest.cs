using System;
using System.Net;
using NUnit.Framework;
using Realm.Library.Network.Mxp;

namespace Realm.Library.Network.Test
{
    [TestFixture]
    public class NetworkExtensionsTest
    {
        [Test]
        public void MxpTag_ConvertsStringProperly()
        {
            const string test = "Test";
            Assert.That(test.MxpTag(), Is.EqualTo("\x03Test\x04"));
        }

        [Test]
        public void MxpAmp_ReturnsAmpersandValue()
        {
            Assert.That(MxpExtensions.MxpAmp(), Is.EqualTo("\x06"));
        }

        [Test]
        public void MxpMode_ReturnsMxpModeValue()
        {
            const int value = 6;
            Assert.That(value.MxpMode(), Is.EqualTo("\x1B[6z"));
        }

        [TestCase("100.101.102.103", 1734763876)]
        [TestCase("localhost", 16777343)]
        [TestCase("this_is_not_an_ip_address", 16777343)]
        public void ConvertToIpAddress(string ipAddress, int bigEndianValue)
        {
            Assert.That(ipAddress.ConvertToIpAddress(), Is.EqualTo(new IPAddress(bigEndianValue)));
        }

        [Test]
        public void ConvertToIpAddress_GetsNullIpAddress_ThrowsException()
        {
            const string ipAddress = null;

            Assert.Throws<ArgumentNullException>(() => ipAddress.ConvertToIpAddress(), 
                "Unit Test expected an ArgumentNullException to be thrown!");
        }
    }
}
