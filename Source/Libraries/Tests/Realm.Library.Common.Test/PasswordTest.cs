using NUnit.Framework;
using Realm.Library.Common.Security;

namespace Realm.Library.Common.Test
{
    [TestFixture]
    public class PasswordTest
    {
        private static string PreHash => "tqzOngQC";
        private static string PostHash => "LfbPsmik";
        private static string EncryptedPass => "SeFROWqcINCrgwcZ/zYbvKr497A=";

        [TestCase("12south", true)]
        [TestCase("tester", false)]
        public void ComputeHashV1Test(string password, bool expected)
        {
            var actual = Password.ComputeHashV1(new PasswordRequestv1
                                                    {
                                                        PlainPassword = password,
                                                        PreHash = PreHash,
                                                        PostHash = PostHash
                                                    });

            Assert.That(EncryptedPass.Equals(actual), Is.EqualTo(expected));
        }

        [TestCase("12south", true)]
        [TestCase("tester", false)]
        public void ValidatePasswordHashV1Test(string password, bool expected)
        {
            var actual = Password.ValidatePasswordHashV1(new PasswordRequestv1
                                                             {
                                                                 PlainPassword = password,
                                                                 HashedPassword = EncryptedPass,
                                                                 PreHash = PreHash,
                                                                 PostHash = PostHash
                                                             });

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
