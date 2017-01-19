using MiniProjectPOS.Data;
using MiniProjectPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.DAL
{
    public class OutletDAL
    {
        public static List<OutletViewModel> GetAll()
        {
            List<OutletViewModel> result = new List<OutletViewModel>();
            using (POSDataContext db = new POSDataContext())
            {
                result = (from o in db.MSTOutlet
                          join p in db.MSTProvince on o.ProvinceID equals p.ID into j1
                          from j10 in j1.DefaultIfEmpty()
                          join r in db.MSTRegion on o.RegionID equals r.ID into j2
                          from j20 in j2.DefaultIfEmpty()
                          join d in db.MSTDistrict on o.DistrictID equals d.ID into j3
                          from j30 in j3.DefaultIfEmpty()
                          select new OutletViewModel
                          {
                              ID = o.ID,
                              OutletName = o.OutletName,
                              Address = o.Address,
                              Phone = o.Phone,
                              Email = o.Email,
                              ProvinceID = o.ProvinceID,
                              ProvinceName = j10.ProvinceName,
                              RegionID = o.RegionID,
                              RegionName = j20.RegionName,
                              DistrictID = o.DistrictID,
                              DistrictName = j30.DistrictName,
                              PostalCode = o.PostalCode
                          }).ToList();
            }
            return result;
        }

        public static List<OutletViewModel> GetAllBySearch(string strSearch)
        {
            List<OutletViewModel> result = new List<OutletViewModel>();
            using (POSDataContext db = new POSDataContext())
            {
                result = (from o in db.MSTOutlet
                          join p in db.MSTProvince on o.ProvinceID equals p.ID into j1
                          from j10 in j1.DefaultIfEmpty()
                          join r in db.MSTRegion on o.RegionID equals r.ID into j2
                          from j20 in j2.DefaultIfEmpty()
                          join d in db.MSTDistrict on o.DistrictID equals d.ID into j3
                          from j30 in j3.DefaultIfEmpty()
                          let fullStr = o.OutletName + o.Address + o.Phone + o.Email
                          where fullStr.Contains(strSearch)
                          select new OutletViewModel
                          {
                              ID = o.ID,
                              OutletName = o.OutletName,
                              Address = o.Address,
                              Phone = o.Phone,
                              Email = o.Email,
                              ProvinceID = o.ProvinceID,
                              ProvinceName = j10.ProvinceName,
                              RegionID = o.RegionID,
                              RegionName = j20.RegionName,
                              DistrictID = o.DistrictID,
                              DistrictName = j30.DistrictName,
                              PostalCode = o.PostalCode
                          }).ToList();
            }
            return result;
        }

        public static OutletViewModel GetById(int id)
        {
            OutletViewModel result = new OutletViewModel();
            using (POSDataContext db = new POSDataContext())
            {
                result = (from o in db.MSTOutlet
                          join p in db.MSTProvince on o.ProvinceID equals p.ID into j1
                          from j10 in j1.DefaultIfEmpty()
                          join r in db.MSTRegion on o.RegionID equals r.ID into j2
                          from j20 in j2.DefaultIfEmpty()
                          join d in db.MSTDistrict on o.DistrictID equals d.ID into j3
                          from j30 in j3.DefaultIfEmpty()
                          where o.ID == id
                          select new OutletViewModel
                          {
                              ID = o.ID,
                              OutletName = o.OutletName,
                              Address = o.Address,
                              Phone = o.Phone,
                              Email = o.Email,
                              ProvinceID = o.ProvinceID,
                              ProvinceName = j10.ProvinceName,
                              RegionID = o.RegionID,
                              RegionName = j20.RegionName,
                              DistrictID = o.DistrictID,
                              DistrictName = j30.DistrictName,
                              PostalCode = o.PostalCode
                          }).FirstOrDefault();
            }
            return result;
        }

        public static bool Add(OutletViewModel model) 
        {
            MSTOutlet outlet = new MSTOutlet();
            outlet.OutletName = model.OutletName;
            outlet.Address = model.Address;
            outlet.Phone = model.Phone;
            outlet.Email = model.Email;
            outlet.ProvinceID = model.ProvinceID;
            outlet.RegionID = model.RegionID;
            outlet.DistrictID = model.DistrictID;
            outlet.PostalCode = model.PostalCode;

            outlet.CreatedBy = 1;
            outlet.CreatedOn = DateTime.Now;

            using (POSDataContext db = new POSDataContext()) 
            {
                try
                {
                    db.MSTOutlet.Add(outlet);
                    db.SaveChanges();
                    return true;
                }
                catch {
                    return false;
                }
            }
        }

        public static bool Update(OutletViewModel model)
        {
            using (POSDataContext db = new POSDataContext())
            {
                MSTOutlet outlet = db.MSTOutlet.Where(o => o.ID == model.ID).FirstOrDefault();
                outlet.OutletName = model.OutletName;
                outlet.Address = model.Address;
                outlet.Phone = model.Phone;
                outlet.Email = model.Email;
                outlet.ProvinceID = model.ProvinceID;
                outlet.RegionID = model.RegionID;
                outlet.DistrictID = model.DistrictID;
                outlet.PostalCode = model.PostalCode;

                outlet.ModifiedBy = 1;
                outlet.ModifiedOn = DateTime.Now;

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
                MSTOutlet outlet = db.MSTOutlet.Where(o => o.ID == id).FirstOrDefault();
                try
                {
                    db.MSTOutlet.Remove(outlet);
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
