using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webfinal.Controllers
{
    public class ArabaController : Controller
    {
        // GET: Araba
        public ActionResult Index()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var Arabalar = session.Query<Models.Araba>().Fetch(x => x.Aliciler).ToList();
                return View(Arabalar);
            }
        }

        public ActionResult Listele()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var Arabalar = session.Query<Models.Araba>().ToList();
                return View(Arabalar);
            }
        }

        public ActionResult Yeni()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var Araba = session.Query<Models.Araba>().FirstOrDefault(x => x.Id == id);
                return View(Araba);
            }
        }


        [HttpPost]
        public ActionResult Edit(Models.Araba Araba)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var arb = session.Query<Models.Araba>().FirstOrDefault(x => x.Id == Araba.Id);
                arb.Marka = Araba.Marka;
                arb.Model = Araba.Model;
                session.SaveOrUpdate(arb);
                session.Flush();
                return RedirectToAction("/Index");
            }
        }
    }
}