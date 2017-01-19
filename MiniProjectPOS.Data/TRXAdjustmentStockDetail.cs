using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.Data
{
    [Table("TRX_ADJUSMENT_STOCK_DETAIL")]
    public class TRXAdjustmentStockDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? HeaderID { get; set; }
        public int? VariantID { get; set; }
        public int? InStock { get; set; }
        public int? ActualStock { get; set; }

        public int? CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        [ForeignKey("HeaderID")]
        public virtual TRXAdjustmentStock AdjustmentStock { get; set; }

        [ForeignKey("VariantID")]
        public virtual MSTItemsVariant ItemsVariant { get; set; }
    }
}
