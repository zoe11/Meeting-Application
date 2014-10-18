using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace FT_Utils
{
    public class MD5Helper
    {
        public static string GetCrypedMessage(string sourceMessage)
        {
            byte[] result = Encoding.Default.GetBytes(sourceMessage);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string outputStr = BitConverter.ToString(output);
            return outputStr;
        }
    }
}