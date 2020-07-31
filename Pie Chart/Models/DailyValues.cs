using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Pie_Chart.Models
{
    [DataContract]
    public class DailyValues
    {
        [DataMember(Name = "label")]
        public int Day { get; set; }
        [DataMember(Name = "y")]
        public int Units { get; set; }
        public string MaxUnit { get; set; }

        public static DailyValues FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            DailyValues dailyValues = new DailyValues();
            dailyValues.Day = Convert.ToInt32(values[0]);
            dailyValues.Units = Convert.ToInt32(values[1]);
            return dailyValues;
        }
    }
}