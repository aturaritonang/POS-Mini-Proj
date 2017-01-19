using MiniProjectPOS.Data;
using MiniProjectPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.DAL
{
    public class DistrictDAL
    {
        public static List<DistrictViewModel> GetAll() 
        {
            List<DistrictViewModel> result;
            using (POSDataContext db = new POSDataContext()) 
            {
                result = (from d in db.MSTDistrict
                          join r in db.MSTRegion on d.RegionID equals r.ID
                          join p in db.MSTProvince on r.ProvinceID equals p.ID
                          select new DistrictViewModel
                          {
                              ID = d.ID,
                              DistrictName = d.DistrictName,
                              RegionID = d.RegionID,
                              RegionName = r.RegionName
                          }).ToList();
            }
            return result;
        }

        public static List<DistrictViewModel> GetById(int id)
        {
            List<DistrictViewModel> result;
            using (POSDataContext db = new POSDataContext())
            {
                result = (from d in db.MSTDistrict
                          join r in db.MSTRegion on d.RegionID equals r.ID
                          join p in db.MSTProvince on r.ProvinceID equals p.ID
                          where d.ID == id
                          select new DistrictViewModel
                          {
                              ID = d.ID,
                              DistrictName = d.DistrictName,
                              RegionID = d.RegionID,
                              RegionName = r.RegionName
                          }).ToList();
            }
            return result;
        }

        public static List<DistrictViewModel> GetByRegionId(int? id)
        {
            List<DistrictViewModel> result;
            using (POSDataContext db = new POSDataContext())
            {
                result = (from d in db.MSTDistrict
                          join r in db.MSTRegion on d.RegionID equals r.ID
                          join p in db.MSTProvince on r.ProvinceID equals p.ID
                          where r.ID == id
                          select new DistrictViewModel
                          {
                              ID = d.ID,
                              DistrictName = d.DistrictName,
                              RegionID = d.RegionID,
                              RegionName = r.RegionName
                          }).ToList();
            }
            return result;
        }

    }
}
