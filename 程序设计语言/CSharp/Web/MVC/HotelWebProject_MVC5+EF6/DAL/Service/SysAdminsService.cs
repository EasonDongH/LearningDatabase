using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class SysAdminsService
    {
        public SysAdmins AdminLogin(SysAdmins admins)
        {
            using (HotelDBEntities hotelDBEntities = new HotelDBEntities())
            {
                return (from s in hotelDBEntities.SysAdmins where s.LoginId == admins.LoginId && s.LoginPwd == admins.LoginPwd select s).FirstOrDefault();
            }
        }
    }
}
