using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherClass
{
    public class DailyForecast
    {
        DateTime date;
        Weather weather;

        public DailyForecast()
        {
            date = DateTime.Now;
            weather = null;
        }

        public DailyForecast(DateTime date, Weather weather)
        {
            this.date = date;
            this.weather = weather;
        }
        public DateTime Date
        {
            get { return date; }
            set { this.date = value; }
        }
        public Weather Weather
        {
            get { return weather; }
            set { this.weather = value; }
        }

        public string GetAsString()
        {
            return $"{date}: T={weather.GetTemperature()}°C, w={weather.GetWindSpeed()}km/h, h={weather.GetHumidity()}%";
        }

        

    }
}