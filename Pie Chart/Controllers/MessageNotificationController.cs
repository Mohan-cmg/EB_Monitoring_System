using Newtonsoft.Json;
using Pie_Chart.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Twilio;

namespace Pie_Chart.Controllers
{
    public class MessageNotificationController : Controller
    {
        [HttpPost]
        public ActionResult MessageNotification(DailyValues value)
        {
            string path = Server.MapPath(@"..\\Data\\EB_Units.csv");
            List<DailyValues> values = System.IO.File.ReadAllLines(path)
                                             .Skip(1)
                                             .Select(v => DailyValues.FromCsv(v))
                                             .ToList();
            ViewBag.Values = JsonConvert.SerializeObject(values);
            var count = 0;
            foreach(var unit in values)
            {
                count = count + unit.Units;
            }
            if ( Convert.ToInt32(value.MaxUnit) > count)
            {
                AlertClicked();
                return View("~/Views/MessageNotification/MessageNotification.cshtml");
            }
            
            return View("~/Views/MessageNotification/AlertNotification.cshtml");
        }


        private void AlertClicked()
        {
            var client = new TwilioRestClient(
                "ACa84d931bfaf9e91a5b5c57e35ed9c387",
                "fae6a8cb353ce05c0ca005bff8373c68"
                );

            client.SendMessage(
                "+12564458631",
                "+919566220733",
                "You have just sent a message from c#"
                );

            
        }
    }
}
