using MiniProjectPOS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.DAL
{
    public class POSInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<POSDataContext>
    {
        protected override void Seed(POSDataContext context)
        {
            //base.Seed(context);

            var Provinces = new List<MSTProvince>
            {
                new MSTProvince{ProvinceName = "ACEH"},
                new MSTProvince{ProvinceName = "Sumatera Utara"}
            };

            Provinces.ForEach(p => context.MSTProvince.Add(p));
            context.SaveChanges();
        }
    }
}
