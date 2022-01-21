using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace WeatherClass
{
    public static class ForecastUtilities
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
        public static DailyForecast Parse(string text)
        {
            DailyForecast dailyForecast = new DailyForecast();
            string[] words = text.Split(",");

            words[1] = words[1].Replace('.', ',');
            words[2] = words[2].Replace('.', ',');
            words[3] = words[3].Replace('.', ',');

            dailyForecast.Date = Convert.ToDateTime(words[0]);
            dailyForecast.Weather = new Weather(Convert.ToDouble(words[1]), Convert.ToDouble(words[3]), Convert.ToDouble(words[2]));

            return dailyForecast;
        }

        public static void PrintWeathers(IPrinter[] uniformPrinters, Weather[] uniformWeathers)
        {
            
            uniformPrinters[0].Print(uniformWeathers);
            uniformPrinters[1].Print(uniformWeathers);
        }
    }
}
