using System;
using System.IO;
using System.Text;

namespace Utility.PGPSignatureTools.Examples
{
    /// <summary>
    ///     Demonstrates the signing and verification of a payload using the PGP private and public keys included in the example files.
    /// </summary>
    internal class Program
    {
        #region Private Fields

        /// <summary>
        ///     The password for the private key file.
        /// </summary>
        private const string Password = "8&$gy$8rrPO^tbE1m5";

        #endregion Private Fields

        #region Private Methods

        /// <summary>
        ///     Runs the example.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        private static void Main(string[] args)
        {
            string text = "hello world!";

            Console.WriteLine("Signing payload: " + text);

            // create the PGP signature
            byte[] bytes = Encoding.ASCII.GetBytes(text);
            byte[] signature = PGPSignature.Sign(bytes, File.ReadAllText(@"Keys\privateKey.asc"), Password);

            Console.WriteLine("\nPGP Signature:\n");
            Console.WriteLine(Encoding.ASCII.GetString(signature));

            Console.WriteLine("\nValidating signature and retrieving payload:\n");

            // verify the signature and store the message payload in the message byte array
            byte[] message = PGPSignature.Verify(signature, File.ReadAllText(@"Keys\publicKey.asc"));

            Console.WriteLine("Retrieved payload: " + Encoding.ASCII.GetString(message));

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }

        #endregion Private Methods
    }
}