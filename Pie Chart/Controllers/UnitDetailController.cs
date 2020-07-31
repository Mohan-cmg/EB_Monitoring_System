using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Pie_Chart.Models;
using Twilio;

namespace Pie_Chart.Controllers
{
    public class UnitDetailController : Controller
    {
        // GET: PieData
   
        public ActionResult UnitDetail()
        {
            string path = Server.MapPath(@"..\\Data\\EB_Units.csv");
            List<DailyValues> values = System.IO.File.ReadAllLines(path)
                                              .Skip(1)
                                              .Select(v => DailyValues.FromCsv(v))
                                              .ToList();
            ViewBag.Values = JsonConvert.SerializeObject(values) ;
            return View();
        }  
           
    }


}  