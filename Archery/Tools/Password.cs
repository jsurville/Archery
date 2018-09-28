using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Archery.Tools
{
    public class Password
    {
        public string ToMD5(string strText)
        {
            Byte[] buffer;
            buffer = Encoding.Default.GetBytes(strText);
            try
            {
                MD5CryptoServiceProvider check = new MD5CryptoServiceProvider();
                Byte[] somme;
                somme = check.ComputeHash(buffer);
                string ret = "";
                foreach (byte a in somme)
                {
                    if (a < 16) ret += "0" + a.ToString("X");
                    else ret += a.ToString("X");
                }
                return ret;
            }
        
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
       
    }
}