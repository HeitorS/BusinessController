using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Web;

using System;
using System.ComponentModel;

namespace BusinessController.Controllers
{
    public class PublicController : Controller
    {

    }
    public class GlobalHelper
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
}