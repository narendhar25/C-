using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace WebApiTestMvc.App_Start
{
    public class Filter: ActionFilterAttribute,IExceptionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Dictionary<string, object> decryptedParameters = new Dictionary<string, object>();
            //if (HttpContext.Current.Request.QueryString.Get("q") != null)
            //{
            //    string encryptedQueryString = HttpContext.Current.Request.QueryString.Get("q");
            //    string decrptedString = Decrypt(encryptedQueryString.ToString());
            //    string[] paramsArrs = decrptedString.Split('?');

            //    for (int i = 0; i < paramsArrs.Length; i++)
            //    {
            //        string[] paramArr = paramsArrs[i].Split('=');
            //        decryptedParameters.Add(paramArr[0], paramArr[1]);
            //    }
            //}
            //for (int i = 0; i < decryptedParameters.Count; i++)
            //{
            //    filterContext.ActionParameters[decryptedParameters.Keys.ElementAt(i)] = decryptedParameters.Values.ElementAt(i);
            //}
            base.OnActionExecuting(filterContext);
        }
        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }

        void OnException(ExceptionContext filterContext)
        {
            throw new NotImplementedException();
        }

        void IExceptionFilter.OnException(ExceptionContext filterContext)
        {
            throw new NotImplementedException();
        }
    }
}