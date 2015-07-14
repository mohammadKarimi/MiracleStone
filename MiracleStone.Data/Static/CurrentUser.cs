using System.Web;
using System.Web.Security;
using System;

namespace Skc.Exchange.Data.Static
{
    /// <summary>
    /// کلاس دریافت اطلاعات کاربر جاری
    /// </summary>
    public static class CurrentUser
    {
        /// <summary>
        /// دریافت آی دی کاربر جاری
        /// </summary>
        public static int TblUserID
        {
            get
            {
                try
                {
                    var ident = (FormsIdentity)HttpContext.Current.User.Identity;
                    if (ident != null)
                    {
                        FormsAuthenticationTicket ticket = ident.Ticket;
                        return (int.Parse(ticket.UserData.Split('µ')[0]));
                    }
                    return -1;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// دریافت نام و نام خانوادگی کاربر جاری
        /// </summary>
        public static string FullName
        {
            get
            {
                try
                {

                    var ident = (FormsIdentity)HttpContext.Current.User.Identity;
                    if (ident != null)
                    {
                        FormsAuthenticationTicket ticket = ident.Ticket;
                        return ticket.UserData.Split('µ')[1];
                    }
                    return string.Empty;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}
