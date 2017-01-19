using MiniProjectPOS.Data;
using MiniProjectPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.DAL
{
    public class ProvinceDAL
    {
        public static List<ProvinceViewModel> GetAll()
        {
            List<ProvinceViewModel> result = new List<ProvinceViewModel>();
            using (POSDataContext db = new POSDataContext())
            {
                result = (from p in db.MSTProvince
                          select new ProvinceViewModel { 
                              ID = p.ID,
                              ProvinceName = p.ProvinceName
                          }).ToList();
            }
            return result;
        }

        public ProvinceViewModel GetById(int id)
        {
            ProvinceViewModel provinsi = new ProvinceViewModel();
            using (POSDataContext db = new POSDataContext())
            {
                provinsi = (from p in db.MSTProvince
                            where p.ID == id
                            select new ProvinceViewModel
                            {
                                ID = p.ID,
                                ProvinceName = p.ProvinceName
                            }).FirstOrDefault();
            }
            return provinsi;
        }
    }
}
