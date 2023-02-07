using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    internal class Day
    {
        public string DayNumber { get; set; }
        public double AvgTemp { get; set; }
        public double AvgHumidity { get; set; }
        public int HighestTemp { get; set; }
        public int LowestTemp { get; set; }
        public int DayCounter { get; set; }

    }
}
