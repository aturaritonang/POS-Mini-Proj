using MiniProjectPOS.Data;
using MiniProjectPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.DAL
{
    public class SupplierDAL
    {
        public static List<SupplierViewModel> GetAll() {
            List<SupplierViewModel> result = new List<SupplierViewModel>();
            using (POSDataContext db = new POSDataContext()) 
            {
                result = (from s in db.MSTSuppliers
                          join p in db.MSTProvince on s.ProvinceID equals p.ID into j1
                          from j10 in j1.DefaultIfEmpty()
                          join r in db.MSTRegion on s.RegionID equals r.ID into j2
                          from j20 in j2.DefaultIfEmpty()
                          join d in db.MSTDistrict on s.DistrictID equals d.ID into j3
                          from j30 in j3.DefaultIfEmpty()
                          select new SupplierViewModel 
                          {
                              ID = s.ID,
                              Name = s.Name,
                              Address = s.Address,
                              ProvinceID = s.ProvinceID,
                              ProvinceName = j10.ProvinceName,
                              RegionID = s.RegionID,
                              RegionName = j20.RegionName,
                              DistrictID = s.DistrictID,
                              DistrictName = j30.DistrictName,
                              PostalCode = s.PostalCode,
                              Phone = s.Phone,
                              Email = s.Email
                          }).ToList();
            }
            return result;
        }

        public static List<SupplierViewModel> GetAllBySearch(string strSearch)
        {
            List<SupplierViewModel> result = new List<SupplierViewModel>();
            using (POSDataContext db = new POSDataContext())
            {
                result = (from s in db.MSTSuppliers
                          join p in db.MSTProvince on s.ProvinceID equals p.ID into j1
                          from j10 in j1.DefaultIfEmpty()
                          join r in db.MSTRegion on s.RegionID equals r.ID into j2
                          from j20 in j2.DefaultIfEmpty()
                          join d in db.MSTDistrict on s.DistrictID equals d.ID into j3
                          from j30 in j3.DefaultIfEmpty()
                          let fullStr = s.Name + s.Address + s.Phone + s.PostalCode + s.Email
                          where fullStr.Contains(strSearch)
                          select new SupplierViewModel
                          {
                              ID = s.ID,
                              Name = s.Name,
                              Address = s.Address,
                              ProvinceID = s.ProvinceID,
                              ProvinceName = j10.ProvinceName,
                              RegionID = s.RegionID,
                              RegionName = j20.RegionName,
                              DistrictID = s.DistrictID,
                              DistrictName = j30.DistrictName,
                              PostalCode = s.PostalCode,
                              Phone = s.Phone,
                              Email = s.Email
                          }
                              ).ToList();
            }
            return result;
        }

        public static SupplierViewModel GetById(int id)
        {
            SupplierViewModel result = new SupplierViewModel();
            using (POSDataContext db = new POSDataContext())
            {
                result = (from s in db.MSTSuppliers
                          join p in db.MSTProvince on s.ProvinceID equals p.ID into j1
                          from j10 in j1.DefaultIfEmpty()
                          join r in db.MSTRegion on s.RegionID equals r.ID into j2
                          from j20 in j2.DefaultIfEmpty()
                          join d in db.MSTDistrict on s.DistrictID equals d.ID into j3
                          from j30 in j3.DefaultIfEmpty()
                          where s.ID == id
                          select new SupplierViewModel
                          {
                              ID = s.ID,
                              Name = s.Name,
                              Address = s.Address,
                              ProvinceID = s.ProvinceID,
                              ProvinceName = j10.ProvinceName,
                              RegionID = s.RegionID,
                              RegionName = j20.RegionName,
                              DistrictID = s.DistrictID,
                              DistrictName = j30.DistrictName,
                              PostalCode = s.PostalCode,
                              Phone = s.Phone,
                              Email = s.Email
                          }).FirstOrDefault();
            }
            return result;
        }

        public static bool Add(SupplierViewModel model) 
        {
            MSTSuppliers supplier = new MSTSuppliers();
            supplier.ID = model.ID;
            supplier.Name = model.Name;
            supplier.Address = model.Address;
            supplier.ProvinceID = model.ProvinceID;
            supplier.RegionID = model.RegionID;
            supplier.DistrictID = model.DistrictID;
            supplier.PostalCode = model.PostalCode;
            supplier.Phone = model.Phone;
            supplier.Email = model.Email;

            supplier.CreatedBy = 1;
            supplier.CreatedOn = DateTime.Now;

            using (POSDataContext db = new POSDataContext())
            {
                db.MSTSuppliers.Add(supplier);
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

        public static bool Update(SupplierViewModel model)
        {
            using (POSDataContext db = new POSDataContext())
            {
                MSTSuppliers supplier = db.MSTSuppliers.Where(s => s.ID == model.ID).FirstOrDefault();
                supplier.ID = model.ID;
                supplier.Name = model.Name;
                supplier.Address = model.Address;
                supplier.ProvinceID = model.ProvinceID;
                supplier.RegionID = model.RegionID;
                supplier.DistrictID = model.DistrictID;
                supplier.PostalCode = model.PostalCode;
                supplier.Phone = model.Phone;
                supplier.Email = model.Email;

                supplier.ModifiedBy = 1;
                supplier.ModifiedOn = DateTime.Now;
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
                MSTSuppliers supplier = db.MSTSuppliers.Where(s => s.ID == id).FirstOrDefault();
                db.MSTSuppliers.Remove(supplier);
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
    }
}
