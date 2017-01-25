﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPOS.Web.Security
{
    public static class SessionPersister
    {
        static string usernameSessionVar = "username";
        static string outletSessionVar = "0";
        public static string Username 
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;

                var sessionVar = HttpContext.Current.Session[usernameSessionVar];
                if (sessionVar != null)
                    return sessionVar as string;
                return null;
            }

            set 
            {
                HttpContext.Current.Session[usernameSessionVar] = value;
            }
        }

        public static string Outlet 
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;

                var sessionVar = HttpContext.Current.Session[outletSessionVar];
                if (sessionVar != null)
                    return sessionVar as string;
                return null;
            }

            set
            {
                HttpContext.Current.Session[outletSessionVar] = value;
            }
        }
    }
}