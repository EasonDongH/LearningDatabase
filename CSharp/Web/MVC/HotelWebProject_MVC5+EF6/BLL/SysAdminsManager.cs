using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
    public class SysAdminsManager
    {
        private SysAdminsService objSysAdminsService = new SysAdminsService();

        public SysAdmins AdminLogin(SysAdmins admins)
        {
            return objSysAdminsService.AdminLogin(admins);
        }
    }
}
