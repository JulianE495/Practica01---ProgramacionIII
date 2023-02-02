using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WAPPS6.Models;

namespace WAPPS6.Controllers
{
    public class AccederController : Controller
    {
        // GET: Acceder
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (DBMVCSCEntities1 db = new DBMVCSCEntities1())
                {
                    var lst = from d in db.USERS
                              where d.Email == user && d.Password == password && d.idStatus == 1
                              select d;

                    if (lst.Count() > 0)
                    {
                        Session["User"] = lst.First();
                        return Content("1");
                    }
                    else
                    {
                        return Content("Revise usuario y contrasena...");
                    }
                }

                return Content("1");
            }
            catch(Exception ex)
            {
                return Content("Ocurrio un error :(" + ex.Message);
            }
        }

        public ActionResult HomePage()
        {
            return View();
        }
    }
}