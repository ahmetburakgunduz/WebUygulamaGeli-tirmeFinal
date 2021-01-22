using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webfinal.Controllers
{
    public class AliciController : Controller
    {
        // GET: Alici
        public ActionResult Index()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var Aliciler = session.Query<Models.Alici>().ToList();
                return View(Aliciler);
            }
        }

        public ActionResult Edit(int id)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var arabalar = session.Query<Models.Araba>().FirstOrDefault(x => x.Id == id);
                return View(arabalar);
            }
        }
    }
}