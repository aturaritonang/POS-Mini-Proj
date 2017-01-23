using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.Data
{
    public class POSDataContext: DbContext
    {
        public POSDataContext():
            base("Name=POSDataBaseConn")
        {
            Database.SetInitializer(new POSDBInitializer());
        }

        public virtual DbSet<MSTProvince> MSTProvince { get; set; }
        public virtual DbSet<MSTDistrict> MSTDistrict { get; set; }
        public virtual DbSet<MSTRegion> MSTRegion { get; set; }
        public virtual DbSet<MSTOutlet> MSTOutlet { get; set; }
        public virtual DbSet<MSTCategory> MSTCategory { get; set; }
        public virtual DbSet<MSTCustomers> MSTCustomer { get; set; }
        public virtual DbSet<MSTEmployees> MSTEmployees { get; set; }
        public virtual DbSet<MSTUser> MSTUser { get; set; }
        public virtual DbSet<MSTEmployeeOutlet> MSTEmployeeOutlet { get; set; }
        public virtual DbSet<MSTItems> MSTItems { get; set; }

        public virtual DbSet<MSTItemsVariant> MSTItemsVariant { get; set; }
        public virtual DbSet<MSTItemsVariantOutlet> MSTItemsVariantOutlet { get; set; }
        public virtual DbSet<MSTPurchaseOrderStatus> MSTPurchaseOrderStatus { get; set; }
        public virtual DbSet<MSTSuppliers> MSTSuppliers { get; set; }
        public virtual DbSet<MSTRole> MSTRole { get; set; }
        //public virtual DbSet<MSTUserRole> MSTUserRole { get; set; }

        public virtual DbSet<TRXAdjustmentStock> TRXAdjustmentStock { get; set; }
        public virtual DbSet<TRXAdjustmentStockDetail> TRXAdjustmentStockDetail { get; set; }
        public virtual DbSet<TRXPayment> TRXPayment { get; set; }
        public virtual DbSet<TRXPaymentDetail> TRXPaymentDetail { get; set; }
        public virtual DbSet<TRXPurchaseOrder> TRXPurchaseOrder { get; set; }
        public virtual DbSet<TRXPurchaseOrderDetail> TRXPurchaseOrderDetail { get; set; }
        public virtual DbSet<TRXPurchaseOrderHistory> TRXPurchaseOrderHistory { get; set; }
        public virtual DbSet<TRXTransferStock> TRXTransferStock { get; set; }
        public virtual DbSet<TRXTransferStockDetail> TRXTransferStockDetail { get; set; }

    }

    //public class POSInitializer : CreateDatabaseIfNotExists<POSDataContext>
    //{
    //    protected override void Seed(POSDataContext context)
    //    {
    //        base.Seed(context);

    //        //var Provinces = new List<MSTProvince>
    //        //{
    //        //    new MSTProvince{ProvinceName = "ACEH"},
    //        //    new MSTProvince{ProvinceName = "Sumatera Utara"}
    //        //};

    //        //Provinces.ForEach(p => context.MSTProvince.Add(p));

    //        //base.Seed(context);
    //    }
    //}
}
