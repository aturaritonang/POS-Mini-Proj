using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.Data
{
    [Table("MST_ITEMS_VARIANT_OUTLET")]
    public class MSTItemsVariantOutlet
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? VariantId { get; set; }
        public int? OutletID { get; set; }
        public int? Beginning { get; set; }
        public int? PurchaseOrder { get; set; }
        public int? Sales { get; set; }
        public int? Transfer { get; set; }
        public int? Adjusment { get; set; }
        public int? Ending { get; set; }
        public int? AlertAt { get; set; }

        public int? CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        [ForeignKey("VariantId")]
        public virtual MSTItemsVariant ItemsVariant { get; set; }

        [ForeignKey("OutletID")]
        public virtual MSTOutlet Outlet { get; set; }
    }
}
