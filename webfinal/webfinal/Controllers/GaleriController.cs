using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webfinal.Controllers
{
    public class GaleriController : Controller
    {
     

        public ActionResult Listele2()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var arbF = session.Query<Models.Araba>().Where(x => x.Id == 1).FirstOrDefault();

                var alici = new Models.Alici();
                alici.Ad = "Ahmet";
                var araba = session.Query<Models.Araba>().Where(x => x.Id == 1).FirstOrDefault();

                alici.Araba = araba;
                session.SaveOrUpdate(alici);

                //var alici = session.Get<Models.Alici>(1);
                 
                var arbYeni = new Models.Araba() { Marka = "Nissan", Model = "Juke", Yil = "2017", MotorGucu = "100" };
                alici.Araba = arbYeni;

                //var alici = new Models.Alici();
                //alici.Ad = "Nilufer";
                //alici.Soyad = "Gürbüz";
                //alici.Araba = arbYeni;

                arbYeni.Aliciler.Add(alici);

                session.Flush();

                //var araba = session.Query<Models.Araba>().Where(x => x.Marka == "Honda").FirstOrDefault();
                //alici.Araba = araba;


                //var t = araba.Aliciler;
                //linq query

                //arb.Marka = "Honda";
                //arb.Model = "Civic";
                //var arbQ = session.Query<Models.Araba>().Where(x => x.Alici == "Ahmet").ToList();
                //rollback 
                //commit

                var arb = new Models.Araba()
                {
                        Marka = "Honda",
                        Model = "Civic",
                
                };

                 arb = session.Query<Models.Araba>().FirstOrDefault(x => x.Id == 1);

                session.SaveOrUpdate(arb);

                session.Delete(arb);

            }


            return View();
        }

       
    }
}