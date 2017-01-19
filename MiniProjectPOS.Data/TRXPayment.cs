using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.Data
{
    [Table("TRX_PAYMENT")]
    public class TRXPayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? CustomerID { get; set; }
        public int? EmployeeID { get; set; }

        [Column(TypeName="Money")]
        public decimal GrandTotal { get; set; }

        public int? CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        [ForeignKey("CustomerID")]
        public virtual MSTCustomers Customer { get; set; }

        [ForeignKey("EmployeeID")]
        public virtual MSTEmployees Employee { get; set; }
        public virtual ICollection<TRXPaymentDetail> PaymentDetails { get; set; }

    }
}
