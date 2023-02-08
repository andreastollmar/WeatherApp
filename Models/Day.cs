using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    internal class Day
    {
        public string Date { get; set; }
        public double AvgTemp { get; set; }
        public double AvgHumidity { get; set; }
        public double HumidityIndex { get; set; }
        public int HighestTemp { get; set; }
        public int LowestTemp { get; set; }
        public int DayCounter { get; set; }

        public void CalculateMoldRisk()
        {
            
            if (AvgTemp > 50 || AvgTemp < 0 || AvgHumidity < 78)
            {
                HumidityIndex = 0;
            }
            else
            {
                if (AvgTemp >= 38)
                    HumidityIndex += 5;

                if (AvgTemp >= 25 && AvgTemp < 38)
                    HumidityIndex += 15;

                if (AvgTemp < 25 && AvgTemp >= 16)
                    HumidityIndex += 20;

                if (AvgTemp < 16 && AvgTemp >= 10)
                    HumidityIndex += 35;

                if (AvgTemp < 10 && AvgTemp >= 0)
                    HumidityIndex += 50;

                if (AvgHumidity > 78 && AvgHumidity <= 83)
                    HumidityIndex += 15;

                if (AvgHumidity > 83 && AvgHumidity <= 87)
                    HumidityIndex += 20;

                if (AvgHumidity > 87 && AvgHumidity <= 95)
                    HumidityIndex += 40;

                if (AvgHumidity > 95 && AvgHumidity <= 100)
                    HumidityIndex += 50;
            }
        }
    }
}
