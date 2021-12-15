using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherClass
{
    public class BiasedGenerator : IRandomGenerator
    {
        Random generator;

        public BiasedGenerator(Random generator)
        {
            this.generator = generator;
        }

        public double Generiraj(double max, double min)
        {
            double number = generator.NextDouble() * (max - min) + min;
            if(number> (max-min)/2)
                number = generator.NextDouble() * (max - min) + min;

            return number;
        }
    }
}
