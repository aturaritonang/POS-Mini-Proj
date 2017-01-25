using MiniProjectPOS.Data;
using MiniProjectPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public static ItemsViewModel GetById(int id) {
            ItemsViewModel result = new ItemsViewModel();
            using (POSDataContext db = new POSDataContext()) 
            {
                result = db.MSTItems.Where(X => X.ID == id)
                    .Select(X => new ItemsViewModel
                    {
                        ID = X.ID,
                        Name = X.Name,
                        CategoryID = X.CategoryID
                    }).FirstOrDefault();

                result.ItemVarians = db.MSTItemsVariant
                    .Where(X => X.ItemID == result.ID)
                    .Join(db.MSTItemsVariantOutlet, iv => iv.ID, ivo => ivo.VariantId, (iv, ivo) => new { iv, ivo })
                    .Select(X => new ItemsVariantViewModel
                    {
                        ID = X.iv.ID,
                        VariantName = X.iv.VariantName,
                        SKU = X.iv.SKU,
                        Price = X.iv.Price,
                        Invents = new ItemsInventoryViewModel 
                        {
                            ID = X.ivo.ID,
                            VariantName = X.iv.VariantName,
                            InStock = X.ivo.Ending,
                            AlertAt = X.ivo.AlertAt
                        }
                    }).ToList();


            }
            return result;
        }

        //public static ItemsViewModel GetById(int id)
        //{
        //    ItemsViewModel result = new ItemsViewModel();
        //    using (POSDataContext db = new POSDataContext())
        //    {
        //        result = (from i in db.MSTItems
        //                  where i.ID == id
        //                  select new ItemsViewModel
        //                  {
        //                      ID = i.ID,
        //                      Name = i.Name,
        //                      CategoryID = i.CategoryID
        //                  }).FirstOrDefault();
        //    }
        //    return result;
        //}

        public static bool Add(ItemsViewModel model) {
            using (POSDataContext db = new POSDataContext()) 
            {
                MSTItems mstItems = new MSTItems();
                mstItems.Name = model.Name;
                mstItems.CategoryID = model.CategoryID;

                db.MSTItems.Add(mstItems);

                List<ItemsVariantViewModel> listVariant = model.ItemVarians;

                int dummyId = 0;

                for (int I = 0; I < listVariant.Count; I++)
                {
                    ItemsVariantViewModel variant = new ItemsVariantViewModel();
                    variant = listVariant[I];

                    MSTItemsVariant mstItemsVariant = new MSTItemsVariant();
                    mstItemsVariant.ID = --dummyId;
                    mstItemsVariant.ItemID = mstItems.ID;
                    mstItemsVariant.VariantName = variant.VariantName;
                    mstItemsVariant.SKU = variant.SKU;
                    mstItemsVariant.Price = variant.Price;
                    db.Entry(mstItems).State = EntityState.Added;
                    db.MSTItemsVariant.Add(mstItemsVariant);

                    MSTItemsVariantOutlet mstItemsVariantOutlet = new MSTItemsVariantOutlet();
                    mstItemsVariantOutlet.VariantId = mstItemsVariant.ID;
                    mstItemsVariantOutlet.Ending = variant.Invents.InStock;
                    mstItemsVariantOutlet.AlertAt = variant.Invents.AlertAt;
                    db.Entry(mstItemsVariant).State = EntityState.Added;
                    db.MSTItemsVariantOutlet.Add(mstItemsVariantOutlet);
                }

                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch {
                    return false;
                }
            }
        }

        public static bool Edit(ItemsViewModel model)
        {
            using (POSDataContext db = new POSDataContext())
            {
                MSTItems mstItems = db.MSTItems.Where(X => X.ID == model.ID).FirstOrDefault();
                if (mstItems != null)
                {
                    mstItems.Name = model.Name;
                    mstItems.CategoryID = model.CategoryID;

                    db.Entry(mstItems).State = EntityState.Modified;

                    List<ItemsVariantViewModel> listVariant = model.ItemVarians;
                    List<ItemsInventoryViewModel> listInvent = new List<ItemsInventoryViewModel>();

                    int dummyId = 0;

                    for (int I = 0; I < listVariant.Count; I++)
                    {
                        ItemsVariantViewModel variant = new ItemsVariantViewModel();
                        variant = listVariant[I];

                        MSTItemsVariant mstItemsVariant = db.MSTItemsVariant.Where(X => X.ID == variant.ID).FirstOrDefault();

                        if (mstItemsVariant != null)
                        {
                            mstItemsVariant.ItemID = mstItems.ID;
                            mstItemsVariant.VariantName = variant.VariantName;
                            mstItemsVariant.SKU = variant.SKU;
                            mstItemsVariant.Price = variant.Price;
                            //db.Entry(mstItemsVariant).State = EntityState.Modified;
                        }
                        else
                        {
                            mstItemsVariant = new MSTItemsVariant();
                            mstItemsVariant.ItemID = mstItems.ID;
                            mstItemsVariant.VariantName = variant.VariantName;
                            mstItemsVariant.SKU = variant.SKU;
                            mstItemsVariant.Price = variant.Price;

                            //db.Entry(mstItems).State = EntityState.Added;
                            db.MSTItemsVariant.Add(mstItemsVariant);
                        }

                        MSTItemsVariantOutlet mstItemsVariantOutlet = db.MSTItemsVariantOutlet.Where(X => X.ID == variant.Invents.ID).FirstOrDefault();
                        
                        if (mstItemsVariantOutlet != null)
                        {
                            mstItemsVariantOutlet.Ending = variant.Invents.InStock;
                            mstItemsVariantOutlet.AlertAt = variant.Invents.AlertAt;
                            db.Entry(mstItemsVariant).State = EntityState.Modified;
                        }
                        else
                        {
                            mstItemsVariantOutlet = new MSTItemsVariantOutlet();
                            mstItemsVariant.ID = --dummyId;
                            mstItemsVariantOutlet.VariantId = mstItemsVariant.ID;
                            mstItemsVariantOutlet.Ending = variant.Invents.InStock;
                            mstItemsVariantOutlet.AlertAt = variant.Invents.AlertAt;
                            db.Entry(mstItemsVariant).State = EntityState.Added;
                            db.MSTItemsVariantOutlet.Add(mstItemsVariantOutlet);
                        }
                        listInvent.Add(listVariant[I].Invents);
                    }

                    List<MSTItemsVariant> mstItemsVariants = db.MSTItemsVariant.Where(X => X.ItemID == model.ID).ToList();

                    foreach (MSTItemsVariant ItemsVariant in mstItemsVariants)
                    {
                        if (listVariant.Find(X => X.ID == ItemsVariant.ID) == null)
                        {
                            List<MSTItemsVariantOutlet> ItemsVariantOutlets = db.MSTItemsVariantOutlet.Where(X => X.VariantId == ItemsVariant.ID).ToList();
                            foreach (MSTItemsVariantOutlet ItemsVariantOutlet in ItemsVariantOutlets)
                            {
                                db.MSTItemsVariantOutlet.Remove(ItemsVariantOutlet);
                            }
                            db.MSTItemsVariant.Remove(ItemsVariant);
                        }
                    }

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
                return false;
            }
        }
    }
}
