using MiniProjectPOS.Data;
using MiniProjectPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.DAL
{
    public class RegionDAL
    {
        public static List<RegionViewModel> GetAll() 
        {
            List<RegionViewModel> result;
            using (POSDataContext db = new POSDataContext())
            {
                result = (from r in db.MSTRegion
                          join p in db.MSTProvince on r.ProvinceID equals p.ID into j1
                          from j in j1.DefaultIfEmpty()
                          select new RegionViewModel
                          {
                              ID = r.ID,
                              RegionName = r.RegionName,
                              ProvinceID = r.ProvinceID,
                              ProvinceName = j.ProvinceName
                          }).ToList();
            }
            return result;
        }

        public static RegionViewModel GetById(int id)
        {
            RegionViewModel result;
            using (POSDataContext db = new POSDataContext())
            {
                result = (from r in db.MSTRegion
                          join p in db.MSTProvince on r.ProvinceID equals p.ID into j1
                          from j in j1.DefaultIfEmpty()
                          where r.ID == id
                          select new RegionViewModel
                          {
                              ID = r.ID,
                              RegionName = r.RegionName,
                              ProvinceID = r.ProvinceID,
                              ProvinceName = j.ProvinceName
                          }).FirstOrDefault();
            }
            return result;
        }

        public static List<RegionViewModel> GetByProvinceId(int? id)
        {
            List<RegionViewModel> result = new List<RegionViewModel>();
            using (POSDataContext db = new POSDataContext())
            {
                result = (from r in db.MSTRegion
                          join p in db.MSTProvince on r.ProvinceID equals p.ID
                          where p.ID == id
                          select new RegionViewModel
                          {
                              ID = r.ID,
                              RegionName = r.RegionName,
                              ProvinceID = r.ProvinceID,
                              ProvinceName = p.ProvinceName
                          }).ToList();
            }
            return result;
        }

    }
}
