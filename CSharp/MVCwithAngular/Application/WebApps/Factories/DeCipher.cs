using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebApps.Factories
{
  public class DeCipher
  {
    public static string Decrypt(string cipherText)
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
      byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
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
      ICryptoTransform decryptor = symmetricKey.CreateDecryptor
      (
          keyBytes,
          initVectorBytes
      );

      MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
      CryptoStream cryptoStream = new CryptoStream
      (
          memoryStream,
          decryptor,
          CryptoStreamMode.Read
      );
      byte[] plainTextBytes = new byte[cipherTextBytes.Length];
      int decryptedByteCount = cryptoStream.Read
      (
          plainTextBytes,
          0,
          plainTextBytes.Length
      );
      memoryStream.Close();
      cryptoStream.Close();
      string plainText = Encoding.UTF8.GetString
      (
          plainTextBytes,
          0,
          decryptedByteCount
      );

      return plainText;
    }
  }
}
