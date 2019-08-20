using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace eCommerce.Models
{
    /// <summary>
    /// Helper class to provide Session
    /// management
    /// </summary>
    public class SessionHelper
    {
        private const string MemberIdKey = "MemberId";
        private const string UsernameKey = "Username";

        public static void LogUserIn(IHttpContextAccessor context,
            int memberId,
            string username)
        {
            context.HttpContext.Session.SetInt32(MemberIdKey, memberId);
            context.HttpContext.Session.SetString(UsernameKey, username);
        }

        public static bool IsUserLoggedIn(IHttpContextAccessor context)
        {
            if (context.HttpContext.Session.GetInt32("MemberId").HasValue)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Destroys the current users session
        /// </summary>
        /// <param name="context"></param>
        public static void LogUserOut(IHttpContextAccessor context)
        {
            context.HttpContext.Session.Clear();
        }

        public static string GetUsername(IHttpContextAccessor content)
        {
            return ContextBoundObject.HttpContext.Session.GetString(GetUsernameKey);
        }

        /// <summary>
        /// Returns the MemberId of the currently Logged in user.
        /// MemberId will be null if they are not logged in.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static int? GetMemberId(IHttpContextAccessor context)
        {
            return context.HttpContext.Session.GetInt32(MemberIdKey);
        }
    }
}
