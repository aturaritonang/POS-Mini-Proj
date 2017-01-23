using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.Data
{
    [Table("MST_ROLE")]
    public class MSTRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column(TypeName="VARCHAR")]
        [StringLength(50)]
        public string RoleName { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Description { get; set; }

        public int? CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }
        public virtual ICollection<MSTUser> Users { get; set; }
    }
}
