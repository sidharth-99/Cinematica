using System;
using System.IO;
using System.Security.Cryptography;

namespace Decryption
{
    public class Class1
    {
        public string decr()
        {
            //    SymmetricAlgorithm c = SymmetricAlgorithm.Create();
            //    ICryptoTransform decrypt = c.CreateDecryptor();
            //    byte[] fileBytes = File.ReadAllBytes(@"D:\studies\Movie_Management\enc.txt");

            //    byte[] plaintext = decrypt.TransformFinalBlock(fileBytes, 0, fileBytes.Length);

            //    string result = System.Text.Encoding.UTF8.GetString(plaintext);

            //    return result;
            //
            using (var rsaProvider = new RSACryptoServiceProvider())
            {
                var useOaepPadding = true;
                var encbyte = rsaProvider.Encrypt(b, useOaepPadding);

                var decbyte = rsaProvider.Decrypt(encbyte, useOaepPadding);

                string dec = Encoding.UTF8.GetString(decbyte);
                return dec;
                Console.ReadLine();
            }
        }
    }
}
