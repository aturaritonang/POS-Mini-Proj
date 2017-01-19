using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.Data
{
    [Table("MST_USER")]
    public class MSTUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Username { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Password { get; set; }
        public bool? Status { get; set; }
        public int? RoleID { get; set; }
        public int? CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        [Required]
        public virtual MSTEmployees Employee { get; set; }

        [ForeignKey("RoleID")]
        public virtual MSTRole Role { get; set; }
        //public virtual ICollection<MSTUserRole> UserRole { get; set; }
    }
}
