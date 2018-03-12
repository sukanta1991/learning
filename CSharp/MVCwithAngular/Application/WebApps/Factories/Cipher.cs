using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebApps.Factories
{
  public class Cipher
  {
    public static string Encrypt(string plainText)
    {
      string passPhrase, saltValue, hashAlgorithm, initVector;
      int passwordIterations, keySize;
      passPhrase = "5uK@nta";
      saltValue = "s@1tValue";
      hashAlgorithm = "SHA1";
      passwordIterations = 2;
      initVector = "@1B2c3D4e5F6g7H8";
      keySize = 256;


      byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
      byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
      byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

      PasswordDeriveBytes password = new PasswordDeriveBytes
      (
          passPhrase,
          saltValueBytes,
          hashAlgorithm,
          passwordIterations
      );

      byte[] keyBytes = password.GetBytes(keySize / 8);
      RijndaelManaged symmetricKey = new RijndaelManaged();

      symmetricKey.Mode = CipherMode.CBC;

      ICryptoTransform encryptor = symmetricKey.CreateEncryptor
      (
          keyBytes,
          initVectorBytes
      );
      MemoryStream memoryStream = new MemoryStream();
      CryptoStream cryptoStream = new CryptoStream
      (
          memoryStream,
          encryptor,
          CryptoStreamMode.Write
      );

      cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
      cryptoStream.FlushFinalBlock();
      byte[] cipherTextBytes = memoryStream.ToArray();
      memoryStream.Close();
      cryptoStream.Close();
      string cipherText = Convert.ToBase64String(cipherTextBytes);
      return cipherText;

    }
  }
}
