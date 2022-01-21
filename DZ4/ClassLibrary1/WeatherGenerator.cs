using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherClass
{
    public class WeatherGenerator
    {
        double minTemperature;
        double maxTemperature;
        double minHumidity;
        double maxHumidity;
        double minWindSpeed;
        double maxWindSpeed;
        IRandomGenerator randomGenerator;

        public void SetGenerator(IRandomGenerator randomGenerator)
        {
            this.randomGenerator = randomGenerator;
        }

        public WeatherGenerator(double minTemperature, double maxTemperature, double minHumidity, double maxHumidity, double minWindSpeed, double maxWindSpeed, IRandomGenerator randomGenerator)
        {
            this.minTemperature = minTemperature;
            this.maxTemperature = maxTemperature;
            this.minHumidity = minHumidity;
            this.maxHumidity = maxHumidity;
            this.minWindSpeed = minWindSpeed;
            this.maxWindSpeed = maxWindSpeed;
            this.randomGenerator = randomGenerator;
        }

        public Weather Generate()
        {
            Weather weather = new Weather(randomGenerator.Generiraj(maxTemperature, minTemperature), randomGenerator.Generiraj(maxHumidity, minHumidity), randomGenerator.Generiraj(maxWindSpeed, minWindSpeed));

            return weather;
        }
    }
}
