using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.Data
{
    [Table("MST_CATEGORIES")]
    public class MSTCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column(TypeName="VARCHAR")]
        [StringLength(50)]
        public string Name { get; set; }

        public int? CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        public int? OutletID { get; set; }
        [ForeignKey("OutletID")]
        public virtual MSTOutlet MSTOutlet { get; set; }

        public virtual ICollection<MSTItems> Items { get; set; }
    }
}
