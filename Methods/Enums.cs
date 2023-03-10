using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Methods
{
    internal class Enums
    {
        public enum MainMenu
        {
            Indoor,
            Outdoor,
            Exit
        }
        public enum IndoorMenu
        {
            Search_For_Date,
            Sort_By_Temperature,
            Sort_By_Humidity,
            Sort_By_Risk_For_Mold,
            Return
        }
        public enum OutDoorMenu
        {
            Search_For_Date,
            Sort_By_Temperature,
            Sort_By_Humidity,
            Sort_By_Risk_For_Mold,
            Meteorological_Winter,
            Meteorological_Fall,
            Return
        }
        public enum Months
        {
            June = 6,
            July,
            August,
            September,
            October,
            November,
            December
        }

    }
}
