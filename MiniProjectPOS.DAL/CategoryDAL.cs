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
                          join o in db.MSTOutlet on c.OutletID equals o.ID into j1
                          from i in j1.DefaultIfEmpty()
                          join ts in db.TRXTransferStock on i.ID equals ts.ToOutlet into j2
                          from j in j2.DefaultIfEmpty()
                          join tsd in db.TRXTransferStockDetail on j.ID equals tsd.HeaderID into j3
                          from k in j3.DefaultIfEmpty()
                          where c.Name.Contains(strSearch)
                          select new CategoryViewModel
                          {
                              ID = c.ID,
                              Name = c.Name,
                              ItemStock = j3.Sum(x => x.InStock) == null ? 0 : j3.Sum(x => x.InStock)
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
                          join o in db.MSTOutlet on c.OutletID equals o.ID into j1
                          from i in j1.DefaultIfEmpty()
                          join ts in db.TRXTransferStock on i.ID equals ts.ToOutlet into j2
                          from j in j2.DefaultIfEmpty()
                          join tsd in db.TRXTransferStockDetail on j.ID equals tsd.HeaderID into j3
                          from k in j3.DefaultIfEmpty()
                          select new CategoryViewModel
                          {
                              ID = c.ID,
                              Name = c.Name,
                              ItemStock = j3.Sum(x => x.InStock) == null ? 0 : j3.Sum(x => x.InStock)
                          }).ToList();
            }
            return result;
        }
        public static CategoryViewModel GetById(int? id) 
        {
            CategoryViewModel result = new CategoryViewModel();
            using (POSDataContext db = new POSDataContext()) 
            {
                result = (from c in db.MSTCategory
                          join o in db.MSTOutlet on c.OutletID equals o.ID into j1
                          from i in j1.DefaultIfEmpty()
                          join ts in db.TRXTransferStock on i.ID equals ts.ToOutlet into j2
                          from j in j2.DefaultIfEmpty()
                          join tsd in db.TRXTransferStockDetail on j.ID equals tsd.HeaderID into j3
                          from k in j3.DefaultIfEmpty()
                          where c.ID == id
                          select new CategoryViewModel
                          {
                              ID = c.ID,
                              Name = c.Name,
                              ItemStock = j3.Sum(x => x.InStock) == null ? 0 : j3.Sum(x => x.InStock)
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
