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
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, string.Format("ALTER DATABASE [{0}] SET MULTI_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

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
            Outlets.Add(new MSTOutlet() { ID = 1, OutletName = "Outlet 1", Address = "Address 1", Phone = "021", Email = "email1@email.com", PostalCode = "12345" }); // 1
            Outlets.Add(new MSTOutlet() { ID = 2, OutletName = "Outlet 2", Address = "Address 2", Phone = "022", Email = "email2@email.com", PostalCode = "22345" }); // 2
            Outlets.Add(new MSTOutlet() { ID = 3, OutletName = "Outlet 3", Address = "Address 3", Phone = "023", Email = "email3@email.com", PostalCode = "32345" }); // 3

            foreach (MSTOutlet outlet in Outlets)
                context.MSTOutlet.Add(outlet);


            IList<MSTItems> Items = new List<MSTItems>();
            Items.Add(new MSTItems() { Name = "Avanza", CategoryID = 1 });//1
            Items.Add(new MSTItems() { Name = "Vios", CategoryID = 1 });//2
            Items.Add(new MSTItems() { Name = "Taruna", CategoryID = 2 });//3
            Items.Add(new MSTItems() { Name = "Xenia", CategoryID = 2 });//4
            Items.Add(new MSTItems() { Name = "Panther", CategoryID = 3 });//5
            Items.Add(new MSTItems() { Name = "Dino", CategoryID = 3 });//6

            foreach (MSTItems item in Items)
                context.MSTItems.Add(item);

            IList<MSTItemsVariant> ItemVarians = new List<MSTItemsVariant>();
            ItemVarians.Add(new MSTItemsVariant() { ItemID = 1, VariantName = "Valoz", SKU = "SKU001", Price = 125000000}); // 1
            ItemVarians.Add(new MSTItemsVariant() { ItemID = 1, VariantName = "LG", SKU = "SKU002", Price = 118000000 });// 2
            ItemVarians.Add(new MSTItemsVariant() { ItemID = 2, VariantName = "Var A", SKU = "SKU003", Price = 133000000 });// 3
            ItemVarians.Add(new MSTItemsVariant() { ItemID = 2, VariantName = "Var B", SKU = "SKU005", Price = 173000000 });// 4
            ItemVarians.Add(new MSTItemsVariant() { ItemID = 3, VariantName = "Var C", SKU = "SKU006", Price = 133000000 });// 5
            ItemVarians.Add(new MSTItemsVariant() { ItemID = 3, VariantName = "Var D", SKU = "SKU007", Price = 165000000 });// 6
            ItemVarians.Add(new MSTItemsVariant() { ItemID = 5, VariantName = "Pnt X", SKU = "SKU008", Price = 127000000 });// 7
            ItemVarians.Add(new MSTItemsVariant() { ItemID = 5, VariantName = "Pnt XZ", SKU = "SKU008", Price = 111000000 });// 8

            foreach (MSTItemsVariant item in ItemVarians)
                context.MSTItemsVariant.Add(item);

            IList<MSTItemsVariantOutlet> ItemVarianOutlets = new List<MSTItemsVariantOutlet>();
            ItemVarianOutlets.Add(new MSTItemsVariantOutlet() { VariantId = 1, OutletID = 1, Beginning = 125, PurchaseOrder = 12, Sales = 5, Transfer = 0, Adjusment = 1, Ending = 5, AlertAt = 1 }); //1
            ItemVarianOutlets.Add(new MSTItemsVariantOutlet() { VariantId = 2, OutletID = 2, Beginning = 125, PurchaseOrder = 12, Sales = 5, Transfer = 0, Adjusment = 1, Ending = 3, AlertAt = 1 }); //2
            ItemVarianOutlets.Add(new MSTItemsVariantOutlet() { VariantId = 3, OutletID = 3, Beginning = 125, PurchaseOrder = 12, Sales = 5, Transfer = 0, Adjusment = 1, Ending = 6, AlertAt = 1 }); //3
            ItemVarianOutlets.Add(new MSTItemsVariantOutlet() { VariantId = 4, OutletID = 2, Beginning = 125, PurchaseOrder = 12, Sales = 5, Transfer = 0, Adjusment = 1, Ending = 10, AlertAt = 1 }); //4
            ItemVarianOutlets.Add(new MSTItemsVariantOutlet() { VariantId = 5, OutletID = 2, Beginning = 125, PurchaseOrder = 12, Sales = 5, Transfer = 0, Adjusment = 1, Ending = 3, AlertAt = 1 }); //5
            ItemVarianOutlets.Add(new MSTItemsVariantOutlet() { VariantId = 6, OutletID = 3, Beginning = 125, PurchaseOrder = 12, Sales = 5, Transfer = 0, Adjusment = 1, Ending = 1, AlertAt = 1 }); //6
            ItemVarianOutlets.Add(new MSTItemsVariantOutlet() { VariantId = 7, OutletID = 3, Beginning = 125, PurchaseOrder = 12, Sales = 5, Transfer = 0, Adjusment = 1, Ending = 1, AlertAt = 1 }); //6
            ItemVarianOutlets.Add(new MSTItemsVariantOutlet() { VariantId = 8, OutletID = 3, Beginning = 125, PurchaseOrder = 12, Sales = 5, Transfer = 0, Adjusment = 1, Ending = 1, AlertAt = 1 }); //6

            foreach (MSTItemsVariantOutlet ivo in ItemVarianOutlets)
                context.MSTItemsVariantOutlet.Add(ivo);

            IList<MSTRole> Roles = new List<MSTRole>();
            Roles.Add(new MSTRole() { ID = 1, RoleName = "Administrator", Description = "Category, Supplier, Outlet, Items, Employee" });
            Roles.Add(new MSTRole() { ID = 2, RoleName = "Back Office", Description = "Employee, Category, Supplier, Items, Summary, PO, Transfer Stock, Adjustment, Payment" });
            Roles.Add(new MSTRole() { ID = 3, RoleName = "Cashier", Description = "Items, Payment" });

            foreach (MSTRole role in Roles)
                context.MSTRole.Add(role);

            IList<MSTUser> Users = new List<MSTUser>();

            Users.Add(new MSTUser() { ID = 1, Username = "admin", Password = "admin", Status = true, RoleID = 1 });
            Users.Add(new MSTUser() { ID = 2, Username = "user1", Password = "user1", Status = true, RoleID = 2 });
            Users.Add(new MSTUser() { ID = 3, Username = "user2", Password = "user2", Status = true, RoleID = 3 });

            foreach (MSTUser user in Users)
                context.MSTUser.Add(user);

            base.Seed(context);
        }
    }
}
