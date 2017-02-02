using MiniProjectPOS.Data;
using MiniProjectPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.DAL
{
    public class AccountDAL
    {
        public static AccountViewModel GetByUserNamePassword(string username, string password)
        {
            AccountViewModel avm = new AccountViewModel();
            using (POSDataContext db = new POSDataContext()) {
                avm = db.MSTUser
                    .Where(U => U.Username.Equals(username) && U.Password.Equals(password))
                    .Select(X => new AccountViewModel { 
                        Username = X.Username,
                        RoleID = X.RoleID
                    }).FirstOrDefault();
            }
            return avm;
        }

        public static AccountViewModel GetByUserName(string username) 
        {
            AccountViewModel avm = new AccountViewModel();
            using (POSDataContext db = new POSDataContext())
            {
                avm = db.MSTUser
                    .Join(db.MSTRole, u => u.RoleID, r => r.ID, (u, r) => new { User = u, Role = r })
                    .Where(U => U.User.Username.Equals(username))
                    .Select(X => new AccountViewModel
                    {
                        Username = X.User.Username,
                        Roles = new List<string>{ X.Role.RoleName },
                        RoleID = X.User.RoleID,
                        RolesX = X.Role.RoleName
                    }).FirstOrDefault();
            }
            return avm;
        }
    }
}
