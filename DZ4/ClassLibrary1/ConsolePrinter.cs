﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherClass
{
    public class ConsolePrinter:IPrinter
    {
        ConsoleColor color;

        public ConsolePrinter(ConsoleColor color)
        {
            this.color = color;
        }

        public void ChangeColor(ConsoleColor color)
        {
            this.color = color;
        }

        public void Print(Weather[] weathers)
        {
            Console.ForegroundColor = color;
            foreach (Weather weather in weathers)
            {
                Console.WriteLine(weather.ToString());
            }
        }
    }
}
