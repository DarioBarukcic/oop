using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherClass
{
    public static class WeatherHelper
    {
        public static Weather FindWeatherWithLargestWindchill(Weather[] weathers)
        {
            double largest = weathers[0].CalculateWindChill();
            int index=0;
            for (int i = 0; i < weathers.Length; i++)
            {
                if (weathers[i].CalculateWindChill() > largest)
                {
                    largest = weathers[i].CalculateWindChill();
                    index = i;
                }
            }
            return weathers[index];
        }
    }
}
