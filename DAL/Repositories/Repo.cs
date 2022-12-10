using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class Repo
    {
        protected WiseTripsEntities db;
        protected Repo()
        {
            db = new WiseTripsEntities();
        }
    }
}