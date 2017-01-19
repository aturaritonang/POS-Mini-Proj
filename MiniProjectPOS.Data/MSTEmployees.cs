using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.Data
{
    [Table("MST_EMPLOYEES")]
    public class MSTEmployees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Title { get; set; }
        public int? CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        public int? UserId { get; set; }

        //[ForeignKey("UserId")]
        public virtual MSTUser User { get; set; }

        public virtual ICollection<TRXPayment> Payment { get; set; }
    }
}
