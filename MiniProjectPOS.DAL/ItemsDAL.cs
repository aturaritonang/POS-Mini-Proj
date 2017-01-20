using MiniProjectPOS.Data;
using MiniProjectPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.DAL
{
    public class ItemsDAL
    {
        public static List<ItemsViewModel> GetAll() 
        {
            List<ItemsViewModel> result = new List<ItemsViewModel>();
            using (POSDataContext db = new POSDataContext()) 
            {
                result = (from i in db.MSTItems
                          join iv in db.MSTItemsVariant on i.ID equals iv.ItemID into j0
                          from j00 in j0.DefaultIfEmpty()
                          join ivo in db.MSTItemsVariantOutlet on j00.ID equals ivo.VariantId into j1
                          from j10 in j1.DefaultIfEmpty()
                          join c in db.MSTCategory on i.CategoryID equals c.ID into j2
                          from j20 in j2.DefaultIfEmpty()
                          select new ItemsViewModel { 
                            ID = i.ID,
                            VariantName = i.Name + " - " + j00.VariantName,
                            CategoryID = i.CategoryID,
                            CategoryName = j20.Name,
                            Price = j00.Price == null ? 0 : j00.Price,
                            InStock = j10.Ending == null ? 0 : j10.Ending,
                            AlertStock = j10.AlertAt == null ? 0 : j10.AlertAt
                          }).ToList();
            }
            return result;
        }
    }
}
