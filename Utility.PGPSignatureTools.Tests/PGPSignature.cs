/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄    ▄██████▄     ▄███████▄    ▄████████
      █     ███    ███   ███    ███   ███    ███   ███    ███
      █     ███    ███   ███    █▀    ███    ███   ███    █▀   █     ▄████▄  ██▄▄▄▄    ▄█████      ██    ██   █     █████    ▄█████
      █     ███    ███  ▄███          ███    ███   ███        ██    ██    ▀  ██▀▀▀█▄   ██   ██ ▀███████▄ ██   ██   ██  ██   ██   █
      █   ▀█████████▀  ▀▀███ ████▄  ▀█████████▀  ▀███████████ ██▌  ▄██       ██   ██   ██   ██     ██  ▀ ██   ██  ▄██▄▄█▀  ▄██▄▄
      █     ███          ███    ███   ███                 ███ ██  ▀▀██ ███▄  ██   ██ ▀████████     ██    ██   ██ ▀███████ ▀▀██▀▀
      █     ███          ███    ███   ███           ▄█    ███ ██    ██    ██ ██   ██   ██   ██     ██    ██   ██   ██  ██   ██   █
      █    ▄████▀        ████████▀   ▄████▀       ▄████████▀  █     ██████▀   █   █    ██   █▀    ▄██▀   ██████    ██  ██   ███████
      █
      █       ███
      █   ▀█████████▄
      █      ▀███▀▀██    ▄█████   ▄█████     ██      ▄█████
      █       ███   ▀   ██   █    ██  ▀  ▀███████▄   ██  ▀
      █       ███      ▄██▄▄      ██         ██  ▀   ██
      █       ███     ▀▀██▀▀    ▀███████     ██    ▀███████
      █       ███       ██   █     ▄  ██     ██       ▄  ██
      █      ▄████▀     ███████  ▄████▀     ▄██▀    ▄████▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Unit tests for the PGPSignature class.
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The MIT License (MIT)
      █
      █  Copyright (c) 2016 JP Dillingham (jp@dillingham.ws)
      █
      █  Permission is hereby granted, free of charge, to any person obtaining a copy
      █  of this software and associated documentation files (the "Software"), to deal
      █  in the Software without restriction, including without limitation the rights
      █  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
      █  copies of the Software, and to permit persons to whom the Software is
      █  furnished to do so, subject to the following conditions:
      █
      █  The above copyright notice and this permission notice shall be included in all
      █  copies or substantial portions of the Software.
      █
      █  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
      █  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
      █  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
      █  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
      █  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
      █  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
      █  SOFTWARE.
      █
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██
                                                                                                   ██
                                                                                               ▀█▄ ██ ▄█▀
                                                                                                 ▀████▀
                                                                                                   ▀▀                            */

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

        /// <summary>
        ///     Tests the <see cref="PGPSignatureTools.PGPSignature.Sign(byte[], string, string)"/> method.
        /// </summary>
        [Fact]
        public void Sign()
        {
            string text = "hello world!";

            byte[] bytes = Encoding.ASCII.GetBytes(text);
            byte[] signature = PGPSignatureTools.PGPSignature.Sign(bytes, File.ReadAllText(Path.Combine("Keys", "privateKey.asc")), Password);

            Assert.NotNull(Encoding.ASCII.GetString(signature));
        }
    }
}