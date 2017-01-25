using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.ViewModel
{
    public class AccountViewModel
    {
        public int ID { get; set; }

        [Display(Name="User Name")]
        public string Username { get; set; }

        [Display(Name="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int? OutletId { get; set; }
        public bool? Status { get; set; }
        public int? RoleID { get; set; }
        public List<string> Roles { get; set; }
        public string RolesX { get; set; }
        public RoleViewModel Role { get; set; }
        public EmployeeViewModel Employee { get; set; }
    }
}
