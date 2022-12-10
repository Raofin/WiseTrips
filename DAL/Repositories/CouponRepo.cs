using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CouponRepo : IRepo<Coupon, int, bool>
    {
        //WiseTripsEntities db;
        //private Coupon obj;

        //internal CouponRepo()    
        //{
        //    db = new WiseTripsEntities();
        //}

        WiseTripsEntities db = new WiseTripsEntities();


        public  bool Add(Coupon obj)    //on going
        {
            //db.Coupons.Add(obj);
            //db.SaveChanges();     
            //return obj;
            db.Coupons.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            db.Coupons.Remove(db.Coupons.Find(id));
            return db.SaveChanges()>0;


        }

        public List<Coupon> Get()
        {
            return db.Coupons.ToList();
        }

        public Coupon Get(int id)
        {
            return db.Coupons.Find(id);
        }

        //public bool Update(Coupon obj)
        //{
        //    var ext = db.Coupons.Find(obj.Id);
        //    db.Entry(ext).CurrentValues.SetValues(obj);
        //    return db.SaveChanges() > 0;
        //}
        public bool Update(Coupon obj)
        {
            var ext = Get(obj.Id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        bool IRepo<Coupon, int, bool>.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
