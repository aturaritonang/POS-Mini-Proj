using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.Data
{
    public class POSDBInitializer: DropCreateDatabaseAlways<POSDataContext>
    {
        public override void InitializeDatabase(POSDataContext context)
        {
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
            , string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

            base.InitializeDatabase(context);
        }
        protected override void Seed(POSDataContext context)
        {
            IList<MSTCategory> Categories = new List<MSTCategory>();
            Categories.Add(new MSTCategory() { Name = "Toyota" });
            Categories.Add(new MSTCategory() { Name = "Daihatsu" });
            Categories.Add(new MSTCategory() { Name = "Isuzu" });

            foreach (MSTCategory category in Categories)
                context.MSTCategory.Add(category);

            IList<MSTSuppliers> Suppliers = new List<MSTSuppliers>();
            Suppliers.Add(new MSTSuppliers() { Name = "CV. Jaya Abadi", Address = "Jl. Makaliwe No.100", PostalCode = "21222", Phone = "021", Email = "alamat@email.com" });
            Suppliers.Add(new MSTSuppliers() { Name = "PO. Super Baja", Address = "Jl. Warung Jati No.33", PostalCode = "21222", Phone = "021", Email = "alamat@email.com" });
            Suppliers.Add(new MSTSuppliers() { Name = "PT. Mobil Jaya Indo", Address = "Jl. Gunung Galunggung No .11", PostalCode = "21222", Phone = "021", Email = "alamat@email.com" });
            Suppliers.Add(new MSTSuppliers() { Name = "PT. Eka Motor Perkasa", Address = "Jl. Makaliwe No .100", PostalCode = "21222", Phone = "021", Email = "alamat@email.com" });

            foreach (MSTSuppliers supplier in Suppliers)
                context.MSTSuppliers.Add(supplier);


            IList<MSTOutlet> Outlets = new List<MSTOutlet>();
            Outlets.Add(new MSTOutlet() { OutletName = "Outlet 1", Address = "Address 1", Phone = "021", Email = "email1@email.com", PostalCode = "12345" });
            Outlets.Add(new MSTOutlet() { OutletName = "Outlet 2", Address = "Address 2", Phone = "022", Email = "email2@email.com", PostalCode = "22345" });
            Outlets.Add(new MSTOutlet() { OutletName = "Outlet 3", Address = "Address 3", Phone = "023", Email = "email3@email.com", PostalCode = "32345" });

            foreach (MSTOutlet outlet in Outlets)
                context.MSTOutlet.Add(outlet);

            base.Seed(context);
        }
    }
}
