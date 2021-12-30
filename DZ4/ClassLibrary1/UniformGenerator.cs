using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherClass
{
    public class UniformGenerator : IRandomGenerator
    {
        Random generator;

        public UniformGenerator(Random generator)
        {
            this.generator = generator;
        }

        public double Generiraj(double max, double min)
        {
            return generator.NextDouble() * (max - min) + min;
        }
    }
}
