using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp
{
    class CityData
    {
        public double dt { get; set; }
        public coord coord { get; set; }
    }
    
    public class coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }
}
