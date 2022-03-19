using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProHub.Domain.Helpers
{
    public static class CultureHelper
    {
        public static string Direction =>
            Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft ? "rtl" : "ltr";
        public static string DirectionCss =>
            Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft ? ".rtl" : "";
        public static string DirectionClass =>
            Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft ? "left" : "right";

        public static string DirectionFull =>
            Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft ? "ar-SA" : "en-US";

        public static string DirectionChangeFull =>
            Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft ? "en-US" : "ar-SA";

        public static string DirectionString =>
            Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft ? "English" : "العربية";

        public static string GetCurrentCulture() => Thread.CurrentThread.CurrentUICulture.Name;

        public static bool IsRightToLeft => Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft;
        public static string DefaultCulture => "ar-SA";

        public static List<CultureInfo> SupportedCultures = new List<CultureInfo>
        {
            new CultureInfo("en-US"), new CultureInfo("ar-SA")
        };

        public static string HtmlLanguage =>
    Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft ? "ar" : "en";

        public static string CssFile =>
                Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft ? "site-ar.css" : "site-en.css";


    }


}
