using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using finance_trial4.Models;

namespace finance_trial4.Controllers
{
    public class LogincustomerController : ApiController
    {
        private financedbEntities1 db = new financedbEntities1();

        public IHttpActionResult GetAdmin()
        {
            return Ok(db.adminMasters);
        }

        [Route("api/user")]
        public IHttpActionResult PostUserLogin(Logincredentials cred)
        {
            Customer temp = db.Customers.Where(x => x.user_name == cred.user_name && x.user_password == cred.user_password).FirstOrDefault();
            if (temp == null)
            {
                return Ok(0) ;
            }
            return Ok(1);
        }

        [Route("api/admin")]
        public IHttpActionResult PostAdminLogin(Logincredentials cred)
        {
            adminMaster temp = db.adminMasters.Where(x => x.admin_username == cred.user_name && x.admin_password == cred.user_password).FirstOrDefault();
            if (temp == null)
            {
                return Ok(0);
            }
            return Ok(1);
        }



    }
}
