using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ToDo.Web.HtmlHelpers
{
    public static class Gravatar
    {
        /// <summary>
        /// Returns a Globally Recognised Avatar as an &lt;img /&gt; - http://gravatar.com
        /// </summary>
        /// /// <param name="gravatarParams">object containing email and size</param>
        public static IHtmlString GravatarImage(this HtmlHelper helper, object gravatarParams)
        {
            var parameters = new RouteValueDictionary(gravatarParams);
            if (parameters.ContainsKey("email"))
            {
                int size = 80;
                if (parameters.ContainsKey("size"))
                {
                    size = (int)parameters["size"];
                }
                return GravatarImage(helper, (string)parameters["email"], size);
            }
            return null;
        }

        public static IHtmlString GravatarImage(this HtmlHelper helper, string email, int size)
        {
            if (email == null)
            {
                return null;
            }
            if (size == 0)
            {
                return null;
            }
            var imgTag = new TagBuilder("img");

            imgTag.Attributes.Add("src",
                string.Format("{0}://{1}.gravatar.com/avatar/{2}?s={3}&d=mm&r=pg",
                    helper.ViewContext.HttpContext.Request.IsSecureConnection ? "https" : "http",
                    helper.ViewContext.HttpContext.Request.IsSecureConnection ? "secure" : "www",
                    MD5Hash(email.Trim().ToLower()),
                    size.ToString()
                    )
                );

            imgTag.Attributes.Add("class", "gravatar");
            imgTag.Attributes.Add("alt", "Gravatar image");
            imgTag.Attributes.Add("title", "Change your avatar at gravatar.com");

            return new HtmlString(imgTag.ToString());
        }

        private static string MD5Hash(string email)
        {
            MD5 hasher = MD5.Create();
            byte[] data = hasher.ComputeHash(Encoding.Default.GetBytes(email));

            var builder = new StringBuilder();
            foreach (byte b in data)
            {
                builder.Append(b.ToString("x2").ToLower());
            }
            return builder.ToString();
        }
    }
}