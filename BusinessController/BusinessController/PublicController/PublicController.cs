using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Web;

using System;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using System.Resources;
using BusinessController.Properties;

namespace BusinessController.Controllers
{
    public class PublicController : Controller
    {

    }
    public static class GlobalHelper
    {
        public static dynamic Converter(dynamic tipo, string value)
        {
            if (tipo.GetType().FullName == "System.Byte")
                return Convert.ToByte(value);

            else if (tipo.GetType().FullName == "System.Int16")
                return Convert.ToInt16(value);

            else if(tipo.GetType().FullName == "System.Int32")
                return Convert.ToInt32(value);

            else if (tipo.GetType().FullName == "System.Int64")
                return Convert.ToInt64(value);

            else if (tipo.GetType().FullName == "System.Single")
                return Convert.ToSingle(value);

            else if (tipo.GetType().FullName == "System.Double")
                return Convert.ToDouble(value);

            else if (tipo.GetType().FullName == "System.Decimal")
                return Convert.ToDecimal(value);

            else if (tipo.GetType().FullName == "System.Boolean")
                return Convert.ToBoolean(value);

            else if (tipo.GetType().FullName == "System.Char")
                return Convert.ToChar(value);

            else if (tipo.GetType().FullName == "System.DateTime")
                return Convert.ToDateTime(value);

            else if (tipo.GetType().FullName == "System.String")
                return Convert.ToString(value);

            else
                return value;
        }
    }

    public class CriptografiaMD5
    {
        public static string MontaCriptografia(string Senha)
        {
            return RetornarMD5(Senha);
        }

        protected static string RetornarMD5(string Senha)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return RetonarHash(md5Hash, Senha);
            }
        }

        public static bool ComparaMD5(string senhabanco, string Senha_MD5)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                var senha = RetornarMD5(senhabanco);
                if (VerificarHash(md5Hash, Senha_MD5, senha))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        protected static string RetonarHash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            Console.WriteLine(sBuilder.ToString());
            return sBuilder.ToString();
        }

        protected static bool VerificarHash(MD5 md5Hash, string input, string hash)
        {
            StringComparer compara = StringComparer.OrdinalIgnoreCase;

            if (0 == compara.Compare(input, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class FindResource
    {
        public string Find(string key)
        {
            ResourceManager rs = new ResourceManager(typeof(Resources));
            string result  = rs.GetString(key);
            if (!string.IsNullOrEmpty(result))
                return result;
            else
                return key;
        }
    }
}