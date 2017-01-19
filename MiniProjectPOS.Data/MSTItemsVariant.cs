using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.Data
{
    [Table("MST_ITEMS_VARIANT")]
    public class MSTItemsVariant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? ItemID { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string VariantName { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string SKU { get; set; }

        [Column(TypeName = "Money")]
        public decimal? Price { get; set; }

        public int? CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<TRXAdjustmentStockDetail> AdjustmentStockDetails { get; set; }
        public virtual ICollection<TRXPaymentDetail> PaymentDetails { get; set; }
        [ForeignKey("ItemID")]        
        public virtual MSTItems Item { get; set; }
    }
}
