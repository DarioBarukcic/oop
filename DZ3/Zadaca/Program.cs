﻿using System;
using WeatherClass;
using System.IO;

namespace Zadaca
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Weather current = new Weather();
            current.SetTemperature(24.12);
            current.SetWindSpeed(3.5);
            current.SetHumidity(0.56);
            Console.WriteLine("Weather info:\n"
                + "\ttemperature: " + current.GetTemperature() + "\n"
                + "\thumidity: " + current.GetHumidity() + "\n"
                + "\twind speed: " + current.GetWindSpeed() + "\n");
            Console.WriteLine("Feels like: " + current.CalculateFeelsLikeTemperature());

            Console.WriteLine("Finding weather info with largest windchill!");
            const int Count = 5;
            double[] temperatures = new double[Count] { 8.33, -1.45, 5.00, 12.37, 7.67 };
            double[] humidities = new double[Count] { 0.3790, 0.4555, 0.743, 0.3750, 0.6612 };
            double[] windSpeeds = new double[Count] { 4.81, 1.5, 5.7, 4.9, 1.2 };

            Weather[] weathers = new Weather[Count];
            for (int i = 0; i < weathers.Length; i++)
            {
                weathers[i] = new Weather(temperatures[i], humidities[i], windSpeeds[i]);
                Console.WriteLine("Windchill for weathers[" + i + "] is: " + weathers[i].CalculateWindChill());
            }
            Weather largestWindchill = ForecastUtilities.FindWeatherWithLargestWindchill(weathers);
            Console.WriteLine(
                "Weather info:" + largestWindchill.GetTemperature() + ", " +
                largestWindchill.GetHumidity() + ", " + largestWindchill.GetWindSpeed()
            );*/

            /*DateTime monday = new DateTime(2021, 11, 8);
            Weather mondayWeather = new Weather(6.17, 56.13, 4.9);
            DailyForecast mondayForecast = new DailyForecast(monday, mondayWeather);
            Console.WriteLine(monday.ToString());
            Console.WriteLine(mondayWeather.ToString());
            Console.WriteLine(mondayForecast.ToString());

            // Assume a valid input file (correct format).
            // Assume that the number of rows in the text file is always 7. 
            string fileName = @"D:\Desktop\DZ1\weather.forcast";
            if (File.Exists(fileName) == false)
            {
                using (StreamWriter sw = File.CreateText(fileName));
                Console.WriteLine("The required file does not exist. Please create it, or change the path.");
                return;
            }

            string[] dailyWeatherInputs = File.ReadAllLines(fileName);
            DailyForecast[] dailyForecasts = new DailyForecast[dailyWeatherInputs.Length];
            for (int i = 0; i < dailyForecasts.Length; i++)
            {
                //Console.WriteLine(dailyWeatherInputs[i]);
                dailyForecasts[i] = ForecastUtilities.Parse(dailyWeatherInputs[i]);
            }
            //Console.WriteLine(dailyForecasts[6].GetAsString());
            WeeklyForecast weeklyForecast = new WeeklyForecast(dailyForecasts);
            Console.WriteLine(weeklyForecast.ToString());
            Console.WriteLine("Maximal weekly temperature:");
            Console.WriteLine(weeklyForecast.GetMaxTemperature());
            Console.WriteLine(weeklyForecast[0].ToString());*/

            
            const int weatherCount = 10;
            double minTemperature = -25.00, maxTemperature = 43.00;
            double minHumidity = 0.00, maxHumidity = 100.00;
            double minWindSpeed = 0.00, maxWindSpeed = 10.00;
            Random generator = new Random();

            IRandomGenerator randomGenerator = new UniformGenerator(generator);
            WeatherGenerator weatherGenerator = new WeatherGenerator(
                minTemperature, maxTemperature,
                minHumidity, maxHumidity,
                minWindSpeed, maxWindSpeed,
                randomGenerator
            );

            Weather[] uniformWeathers = new Weather[weatherCount];
            for (int i = 0; i < uniformWeathers.Length; i++)
            {
                uniformWeathers[i] = weatherGenerator.Generate();
            }

            randomGenerator = new BiasedGenerator(generator);
            weatherGenerator.SetGenerator(randomGenerator);
            Weather[] winterWeathers = new Weather[weatherCount];
            for (int i = 0; i < winterWeathers.Length; i++)
            {
                winterWeathers[i] = weatherGenerator.Generate();
            }

            IPrinter[] uniformPrinters = new IPrinter[]
            {
                new ConsolePrinter(ConsoleColor.DarkYellow),
                new FilePrinter(@"D:\Desktop\DZ2\uniformWeathers.txt"),
            };
            ForecastUtilities.PrintWeathers(uniformPrinters, uniformWeathers);

            IPrinter[] winterPrinters = new IPrinter[]
            {
                new ConsolePrinter(ConsoleColor.Green),
                new FilePrinter(@"D:\Desktop\DZ2\winterWeathers.txt"),
            };
            ForecastUtilities.PrintWeathers(winterPrinters, winterWeathers);
        }
    }
}
