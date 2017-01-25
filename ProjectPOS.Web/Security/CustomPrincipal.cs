using MiniProjectPOS.DAL;
using MiniProjectPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace ProjectPOS.Web.Security
{
    public class CustomPrincipal: IPrincipal
    {
        private AccountViewModel Account;
        //private AccountDAL aDAL = new AccountDAL();

        public CustomPrincipal(AccountViewModel account)
        {
            this.Account = account;
            this.Identity = new GenericIdentity(account.Username);
        }
        public IIdentity Identity { get; set; }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => this.Account.Roles.Contains(r));
        }
    }
}