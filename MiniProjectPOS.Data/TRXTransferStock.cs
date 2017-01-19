using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.Data
{
    [Table("TRX_TRANSFER_STOCK")]
    public class TRXTransferStock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? FromOutlet { get; set; }
        public int? ToOutlet { get; set; }

        [Column(TypeName="VARCHAR")]
        [StringLength(255)]
        public string Note { get; set; }

        public int? CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        [ForeignKey("FromOutlet")]
        public virtual MSTOutlet OutletFrom { get; set; }
        [ForeignKey("ToOutlet")]
        public virtual MSTOutlet OutletTo { get; set; }

        public virtual ICollection<TRXTransferStockDetail> TransferStockDetails { get; set; }
    }
}
