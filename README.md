# PGPSignatureTools

[![Build status](https://ci.appveyor.com/api/projects/status/bkwapclp6uvn2889?svg=true)](https://ci.appveyor.com/project/jpdillingham/utility-pgpsignaturetools)
[![Build Status](https://travis-ci.org/jpdillingham/Utility.PGPSignatureTools.svg?branch=master)](https://travis-ci.org/jpdillingham/Utility.PGPSignatureTools)
[![codecov](https://codecov.io/gh/jpdillingham/Utility.PGPSignatureTools/branch/master/graph/badge.svg)](https://codecov.io/gh/jpdillingham/Utility.PGPSignatureTools)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://github.com/jpdillingham/Utility.PGPSignatureTools/blob/master/LICENSE)

## Why?

I needed a quick and easy way to digitally sign and validate files and couldn't find a good way to do it that didn't require a Software Signing X509 Certificate (not free).

## How to Get a PGP Key

PGP keys can be obtained a bunch of different ways; I chose to use [keybase.io](http://keybase.io) because of the trusted reputation and the ability 
to verify the ownership of the account against other social media accounts (Facebook, Twitter, GitHub) and my private domain.

Regardless of how you obtain your key, you'll need an ASCII-Armored (keybase default) Public and Private key file (extension .asc) to sign and verify payloads.  If you only 
want to verify payloads signed by someone else, you'll just need to obtain the originator's public key.

I've included examples of both [Public](https://raw.githubusercontent.com/jpdillingham/Utility.PGPSignatureTools/master/Examples/Keys/privateKey.asc) 
and [Private](https://raw.githubusercontent.com/jpdillingham/Utility.PGPSignatureTools/master/Examples/Keys/privateKey.asc) keys in this 
repository for use as an example.  Note that these keys originated from my keybase account but have since been revoked 
and re-generated with a new password.

## How to Sign Data

The ```Sign()``` method accepts a ```byte[]``` parameter representing the data to be signed, as well as two ```string``` parameters containing the contents of your
PGP Private key file and the password for the key file, respectively.  The ```File.ReadAllBytes()``` method is a good way to get file contents, and 
```Encoding.ASCII.GetBytes(string)``` is a quick and easy way to get a byte array from a string.

The following example demonstrates how to sign a string, assuming your private key is stored in "privateKey.asc" and that the password for your private key file is "password":

```c#
public void SignText()
{
    string text = "hello world!";

    // convert the string to a byte array
    byte[] bytes = Encoding.ASCII.GetBytes(text);

    // create the PGP signature
    byte[] signature = PGPSignature.Sign(bytes, File.ReadAllText("privateKey.asc"), "password");

    // do whatever you want with the signature!
}
```

Here's another example demonstrating how to sign a file, assuming that file is named "myfile.ext":

```c#
public void SignFile()
{
    // convert the string to a byte array
    byte[] bytes = File.ReadAllBytes("myfile.ext");

    // create the PGP signature
    byte[] signature = PGPSignature.Sign(bytes, File.ReadAllText("privateKey.asc"), "password");

    // do whatever you want with the signature!
}
```

The resulting PGP signature can be stored in memory or written to a file depending on your needs.

## How to Verify a Signature

The ```Verify()``` method accepts either a ```byte[]``` or ```string``` parameter containing the contents of the PGP signature file to verify, as well as a ```string``` parameter containing
the contents of your PGP Public key file.

The following example demonstrates how to verify the signature of a PGP signature stored in a file, assuming your signature is stored in "signature.asc" and your public key is in "publicKey.asc":

```c#
public void VerifyFile()
{
    // read the signature file into a byte array
    byte[] signature = File.ReadAllBytes("signature.asc");

    // verify the signature and store the message payload in the message byte array
    byte[] message = PGPSignature.Verify(signature, File.ReadAllText("publicKey.asc"));

    // do whatever you want with the message!
    // it contains the original contents of the file/message that was signed.
}
```

Here's another example demonstrating how to verify the signature of a string:

```c#
public void VerifyString()
{
    // read the signature file into a byte array
    // pretend this is a long string containing a valid signature
    byte[] signature = Encoding.ASCII.GetBytes("...");

    // verify the signature and store the message payload in the message byte array
    byte[] message = PGPSignature.Verify(signature, File.ReadAllText("publicKey.asc"));

    // do whatever you want with the message!
    // it contains the original contents of the file/message that was signed.
}
```