using System.IO;
using System.Text;
using Xunit;

namespace Utility.PGPSignatureTools.Tests
{
    /// <summary>
    ///     Unit tests for the <see cref="PGPSignature"/> class.
    /// </summary>
    public class PGPSignature
    {
        /// <summary>
        ///     The password for the private key file.
        /// </summary>
        private const string Password = "8&$gy$8rrPO^tbE1m5";

        [Fact]
        public void Sign()
        {
            string text = "hello world!";

            byte[] bytes = Encoding.ASCII.GetBytes(text);
            byte[] signature = PGPSignatureTools.PGPSignature.Sign(bytes, File.ReadAllText(@"Keys\privateKey.asc"), Password);

            Assert.NotNull(Encoding.ASCII.GetString(signature));
        }
    }
}