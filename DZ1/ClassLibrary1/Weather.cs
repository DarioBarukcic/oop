using System;

namespace WeatherClass
{
    public class Weather
    {
        double currentTemperature;
        double humidity;
        double windSpeed;

        public Weather ()
        {
            currentTemperature = 0;
            windSpeed = 0;
            humidity = 0;
        }

        public Weather(double currentTemperature, double humidity, double windSpeed)
        {
            this.currentTemperature = currentTemperature;
            this.humidity = humidity;
            this.windSpeed = windSpeed;
        }

        public void SetTemperature(double currentTemperature)
        {
            this.currentTemperature = currentTemperature;
        }
        public void SetWindSpeed(double windSpeed)
        {
            this.windSpeed = windSpeed;
        }
        public void SetHumidity(double humidity)
        {
            this.humidity = humidity;
        }

        public double GetTemperature()
        {
            return currentTemperature;
        }
        public double GetWindSpeed()
        {
            return windSpeed;
        }
        public double GetHumidity()
        {
            return humidity;
        }

        public double CalculateFeelsLikeTemperature()
        {
            const double c1 = -8.78469475556;
            const double c2 = 1.61139411;
            const double c3 = 2.33854883889;
            const double c4 = -0.14611605;
            const double c5 = -0.012308094;
            const double c6 = -0.0164248277778;
            const double c7 = 0.002211732;
            const double c8 = 0.00072546;
            const double c9 = -0.000003582;
            double HI;

            HI = c1 + c2 * currentTemperature + c3 * humidity + c4 * currentTemperature * humidity + c5 * Math.Pow(currentTemperature, 2) + c6 * Math.Pow(humidity, 2) + c7 * Math.Pow(currentTemperature, 2) * humidity + c8 * currentTemperature * Math.Pow(humidity, 2) + c9 * Math.Pow(currentTemperature, 2) * Math.Pow(humidity, 2);
            return HI;

        }

        public double CalculateWindChill()
        {
            double windChill;
            windChill = 13.12 + 0.6215 * currentTemperature - 11.37 * Math.Pow(windSpeed, 0.16) + 0.3965 * currentTemperature * Math.Pow(windSpeed, 0.16);
            if (currentTemperature > windChill)
                return windChill;
            else
                return 0;
        }

        
    }
}
