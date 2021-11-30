using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherClass
{
    public class WeeklyForecast
    {
        DailyForecast[] week =
        {
            new DailyForecast(),
            new DailyForecast(),
            new DailyForecast(),
            new DailyForecast(),
            new DailyForecast(),
            new DailyForecast(),
            new DailyForecast(),
        };

        public WeeklyForecast(DailyForecast[] dailyForecasts)
        {
            for(int i = 0; i < dailyForecasts.Length; i++)
            {
                this.week[i] = dailyForecasts[i];
            }
        }

        public DailyForecast this[int weekIndex]
        {
            get { return week[weekIndex]; }
            set { week[weekIndex] = value; }
        }

        public string GetAsString()
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < week.Length; i++)
            {
                sb.Append(week[i].GetAsString());
                sb.Append("\n");
            }

            return sb.ToString();
        }

        public double GetMaxTemperature()
        {
            Weather max = week[0].Weather;
            for(int i = 0; i < week.Length; i++)
            {
                if (week[i].Weather > max)
                {
                    max = week[i].Weather;
                }
            }

            /*for(int i = 0; i < week.Length; i++)
            {
                if (week[i].Weather.GetTemperature() > max)
                {
                    max = week[i].Weather.GetTemperature();
                }
            }*/
            return max.GetTemperature();
        }
        
    }
}
