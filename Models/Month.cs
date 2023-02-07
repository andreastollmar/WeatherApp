using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    internal class Month
    {
        public int MonthNumber { get; set; }
        public List<Day> Days { get; set; } = new List<Day>();

    }
}
