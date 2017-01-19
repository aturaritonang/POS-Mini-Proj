using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.Data
{
    [Table("TRX_PURCHASE_ORDER")]
    public class TRXPurchaseOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? OutletID { get; set; }
        public int? SupplierID { get; set; }

        [Column(TypeName="VARCHAR")]
        [StringLength(20)]
        public string OrderNo { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Notes { get; set; }
        public int? StatusID { get; set; }
        public int? CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }
        [ForeignKey("OutletID")]
        public virtual MSTOutlet Outlet { get; set; }
        [ForeignKey("SupplierID")]
        public virtual MSTSuppliers Supplier { get; set; }

        public virtual ICollection<TRXPurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual ICollection<TRXPurchaseOrderHistory> PurchaseOrderHistorys { get; set; }
        [ForeignKey("StatusID")]
        public virtual MSTPurchaseOrderStatus PurchaseOrderStatus { get; set; }
    }
}
