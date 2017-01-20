using MiniProjectPOS.Data;
using MiniProjectPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.DAL
{
    public class CategoryDAL
    {
        public static List<CategoryViewModel> GetAll() 
        {
            List<CategoryViewModel> result = new List<CategoryViewModel>();
            using (POSDataContext db = new POSDataContext())
            {
                result = (from c in db.MSTCategory
                          select new CategoryViewModel
                          {
                              ID = c.ID,
                              Name = c.Name
                          }).ToList();
            }
            return result;
        }

        public static List<CategoryViewModel> GetAllBySearch(string strSearch) 
        {
            List<CategoryViewModel> result;
            using (POSDataContext db = new POSDataContext())
            {
                result = (from c in db.MSTCategory
                          join i in db.MSTItems on c.ID equals i.CategoryID into j1
                          from j10 in j1.DefaultIfEmpty()
                          join iv in db.MSTItemsVariant on j10.ID equals iv.ItemID into j2
                          from j20 in j2.DefaultIfEmpty()
                          join ivo in db.MSTItemsVariantOutlet on j20.ID equals ivo.VariantId into j3
                          from j30 in j3.DefaultIfEmpty()
                          where c.Name.Contains(strSearch)
                          group j30.Ending by new { c.ID, c.Name } into eg
                          select new CategoryViewModel
                          {
                              ID = eg.Key.ID,
                              Name = eg.Key.Name,
                              ItemStock = eg.Sum() == null ? 0 : eg.Sum()
                          }).ToList();
            }
            return result;
        }

        public static List<CategoryViewModel> GetAllAndItems()
        {
            List<CategoryViewModel> result;
            using (POSDataContext db = new POSDataContext())
            {
                result = (from c in db.MSTCategory
                          join i in db.MSTItems on c.ID equals i.CategoryID into j1
                          from j10 in j1.DefaultIfEmpty()
                          join iv in db.MSTItemsVariant on j10.ID equals iv.ItemID into j2
                          from j20 in j2.DefaultIfEmpty()
                          join ivo in db.MSTItemsVariantOutlet on j20.ID equals ivo.VariantId into j3
                          from j30 in j3.DefaultIfEmpty()
                          select new CategoryViewModel
                          {
                              ID = c.ID,
                              Name = c.Name + " - " + j20.VariantName,
                              ItemStock = j3.Sum(x => x.Ending) == null ? 0 : j3.Sum(x => x.Ending) 
                          }).ToList();
                //j30.Sum(x => x.) == null ? 0 : j3.Sum(x => x.InStock)
            }
            return result;
        }
        public static CategoryViewModel GetById(int? id) 
        {
            CategoryViewModel result = new CategoryViewModel();
            using (POSDataContext db = new POSDataContext()) 
            {
                result = (from c in db.MSTCategory
                          join i in db.MSTItems on c.ID equals i.CategoryID into j1
                          from j10 in j1.DefaultIfEmpty()
                          join iv in db.MSTItemsVariant on j10.ID equals iv.ItemID into j2
                          from j20 in j2.DefaultIfEmpty()
                          join ivo in db.MSTItemsVariantOutlet on j20.ID equals ivo.VariantId into j3
                          from j30 in j3.DefaultIfEmpty()
                          where c.ID == id
                          select new CategoryViewModel
                          {
                              ID = c.ID,
                              Name = c.Name,
                              ItemStock = j3.Sum(x => x.Ending) == null ? 0 : j3.Sum(x => x.Ending)
                          }).FirstOrDefault();
            }
            return result;
        }

        public static bool Add(CategoryViewModel model) 
        {
            using (POSDataContext db = new POSDataContext())
            {
                MSTCategory mstCategory = new MSTCategory();
                mstCategory.Name = model.Name;
                mstCategory.CreatedBy = 1;
                mstCategory.CreatedOn = DateTime.Now;
                mstCategory.ModifiedBy = 1;
                mstCategory.ModifiedOn = DateTime.Now;

                try
                {
                    db.MSTCategory.Add(mstCategory);
                    db.SaveChanges();
                    return true;
                }

                catch
                {
                    return false;
                }
            }
        }

        public static bool Update(CategoryViewModel model) 
        {
            using (POSDataContext db = new POSDataContext()) 
            {
                MSTCategory mstCategory = db.MSTCategory.Where(x => x.ID == model.ID).FirstOrDefault();
                mstCategory.Name = model.Name;
                mstCategory.ModifiedBy = 1;
                mstCategory.ModifiedOn = DateTime.Now;

                try
                {
                    db.SaveChanges();
                    return true;
                }

                catch 
                {
                    return false;
                }
            }
        }

        public static bool Delete(int id) 
        {
            using (POSDataContext db = new POSDataContext())
            {
                MSTCategory mstCategory = db.MSTCategory.Where(x => x.ID == id).FirstOrDefault();
                try
                {
                    db.MSTCategory.Remove(mstCategory);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
