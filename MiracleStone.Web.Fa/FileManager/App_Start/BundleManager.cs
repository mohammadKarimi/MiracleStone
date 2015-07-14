using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Links
{
    /// <summary>
    ///Boundle در  StronglyType کلاسی برای استفاده 
    /// </summary>
    public static partial class Bundles
    {
        /// <summary>
        ///Scripts در  StronglyType کلاسی برای استفاده 
        /// </summary>
        public static partial class Scripts
        {
            /// <summary>
            /// باندل تمامیه اسکریپت ها
            /// </summary>
            public static readonly string CoreScripts = "~/Scripts/js";

            
        }

        /// <summary>
        ///Styles در  StronglyType کلاسی برای استفاده 
        /// </summary>
        public static partial class Styles
        {
            /// <summary>
            /// باندل تمامیه استایل ها
            /// </summary>
            public static readonly string ContentCss = "~/Content/css";
        }
    }
}
