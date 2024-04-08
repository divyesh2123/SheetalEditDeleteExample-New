using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SheetalEditDeleteExample.Controllers
{
    public class EmployeeController : Controller
    {

        public ActionResult CreateCity()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateOrUpdateCity(CityMaster cityMaster)
        {
            using (EDMSEntities d = new EDMSEntities())
            {
                if (cityMaster.ID > 0)
                {
                    var p = d.CityMasters.FirstOrDefault(y=>y.ID == cityMaster.ID);
                    p.Name =cityMaster.Name;
                    p.Description = cityMaster.Description; 

                }
                else
                {
                    d.CityMasters.Add(cityMaster);  
                }

                d.SaveChanges();

            }
            return RedirectToAction("index");
        }


        // GET: Employee
        public ActionResult Index()
        {
            using (EDMSEntities d = new EDMSEntities())
            {

                return View(d.CityMasters.ToList());
            }
            return View();
        }

        public ActionResult DeleteRecord(int id)
        {

            using (EDMSEntities d = new EDMSEntities())
            {

                var p = d.CityMasters.FirstOrDefault(y => y.ID == id);
                d.CityMasters.Remove(p);
                d.SaveChanges();
            }

            return RedirectToAction("Index");

        }

        public ActionResult EditRecord(int id)
        {
            using (EDMSEntities d = new EDMSEntities())
            {
                var findrecord = d.CityMasters.FirstOrDefault(y => y.ID == id);
                return View("CreateCity", findrecord);

            }
        }
    }
}