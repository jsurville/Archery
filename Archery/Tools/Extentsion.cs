using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Archery.Tools
{
    /// <summary>
    /// Méthode d'extention pour haser une chaine de caractères au format MD5
    /// </summary>
    public static class Extentsion // crée la classe Password en static pour permettre l'accès à ses méthodes statiques sur n'importe quel string ou Password
    {
        public static string ToMD5(this string strText) // this string permet de créer une méthode d'extention de la méthode ToMD5 sur n'importe quelle string
        {
            Byte[] buffer;
            buffer = Encoding.Default.GetBytes(strText);
            try
            {
                MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
                Byte[] somme;
                somme = provider.ComputeHash(buffer);
                string result = "";
                foreach (byte a in somme)
                {
                    if (a < 16) result += "0" + a.ToString("X");
                    else result += a.ToString("X");
                }
                return result;
            }
        
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
       
    }
}