using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace FT_ENV
{
    public class DecryptHelper
    {
        private static string privateKey = "<RSAKeyValue><Modulus>6CdsXgYOyya/yQHTO96dB3gEurM2UQDDVGrZoe6RcAVTxAqDDf5L"
            + "wPycZwtNOx3Cfy44/D5Mj86koPew5soFIz9sxPAHRF5hcqJoG+q+UfUYTHYCsMH2cnqGVtnQiE/PMRMmY0RwEfMIo+TDpq3QyO03MaEsDGf13sP"
            + "w9YRXiac=</Modulus><Exponent>AQAB</Exponent><P>/aoce2r6tonjzt1IQI6FM4ysR40j/gKvt4dL411pUop1Zg61KvCm990M4uN6K8R/DUvAQdrRd"
            + "VgzvvAxXD7ESw==</P><Q>6kqclrEunX/fmOleVTxG4oEpXY4IJumXkLpylNR3vhlXf6ZF9obEpGlq0N7sX2HBxa7T2a0WznOAb0si8FuelQ==</Q>"
            + "<DP>3XEvxB40GD5v/Rr4BENmzQW1MBFqpki6FUGrYiUd2My+iAW26nGDkUYMBdYHxUWYlIbYo6Tezc3d/oW40YqJ2Q==</DP><DQ>LK0XmQCmY/ArY"
            + "gw2Kci5t51rluRrl4f5l+aFzO2K+9v3PGcndjAStUtIzBWGO1X3zktdKGgCLlIGDrLkMbM21Q==</DQ><InverseQ>GqC4Wwsk2fdvJ9dmgYlej8mTDBWg0Wm6aqb5kjn"
            + "cWK6WUa6CfD+XxfewIIq26+4Etm2A8IAtRdwPl4aPjSfWdA==</InverseQ><D>a1qfsDMY8DSxB2DCr7LX5rZHaZaqDXdO3GC01z8dHjI4dDVwOS5ZFZ"
            + "s7MCN3yViPsoRLccnVWcLzOkSQF4lgKfTq3IH40H5N4gg41as9GbD0g9FC3n5IT4VlVxn9ZdW+WQryoHdbiIAiNpFKxL/DIEERur4sE1Jt9VdZsH24CJE=</D></RSAKeyValue>";



        static public string Decrypt(string base64code)
        {
            try
            {
                if (string.IsNullOrEmpty(base64code))
                {//2013-11-21 add by XXX
                    return "";
                }
                //Create a UnicodeEncoder to convert between byte array and string.
                UnicodeEncoding ByteConverter = new UnicodeEncoding();

                //Create a new instance of RSACryptoServiceProvider to generate
                //public and private key data.
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSA.FromXmlString(privateKey);

                byte[] encryptedData;

                byte[] decryptedData;

                encryptedData = Convert.FromBase64String(base64code);
                //Pass the data to DECRYPT, the private key information 
                //(using RSACryptoServiceProvider.ExportParameters(true),
                //and a boolean flag specifying no OAEP padding.
                decryptedData = Decrypt(encryptedData, RSA.ExportParameters(true), false);
                //Display the decrypted plaintext to the console. 
                return ByteConverter.GetString(decryptedData);
            }
            catch (Exception exc)
            {
                //Exceptions.LogException(exc);
                Console.WriteLine(exc.Message);
                return "";
            }
        }

        static private byte[] Decrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                //Create a new instance of RSACryptoServiceProvider.
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                //Import the RSA Key information. This needs
                //to include the private key information.
                RSA.ImportParameters(RSAKeyInfo);

                //Decrypt the passed byte array and specify OAEP padding.  
                //OAEP padding is only available on Microsoft Windows XP or
                //later.  
                return RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                //Exceptions.LogException(e);
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
