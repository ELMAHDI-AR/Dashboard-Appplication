using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ApplicationDashboardMVC.Helpers
{
    public static class CustomHelperBase
    {
        public static IHtmlString ProductImage(this HtmlHelper helper, string category, string productImage, string width, string height)
        {
            string result = string.Empty;
            result = string.Format("<img src = {0} style =\"width: {1}; height: {2}\"/>", GetUrlImage(category, productImage), width, height);

            return new HtmlString(result);  
        }

        public static string GetUrlImage(string category, string productImage)
        { 
            string resultUrl = string.Format("/{0}/{1}/{2}", "Images", category, productImage);

            return resultUrl;
        }

        
    }
}