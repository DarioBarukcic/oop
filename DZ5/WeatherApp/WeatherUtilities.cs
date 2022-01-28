using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WeatherApp
{
    public static class WeatherUtilities
    { 
        public static DateTime UnixTimeToDateTime(double unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970,1,1,0,0,0,0,DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();

            return dateTime;
        }

        public static WeatherData GetData(string cityName)
        {
            try
            {
                WeatherData weatherData = new WeatherData();
                using (WebClient currentWeather = new WebClient())
                {
                    string url1 = string.Format($"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid=f8bbaaf0973aa0d13b6e1cedf69e1949&units=metric");
                    var json1 = currentWeather.DownloadString(url1);
                    var resoult1 = JsonSerializer.Deserialize<CityData>(json1);

                    using (WebClient oneCallAPI = new WebClient())
                    {
                        string url2 = string.Format($"https://api.openweathermap.org/data/2.5/onecall?lat={resoult1.coord.lat}&lon={resoult1.coord.lon}&exclude=minutely&appid=f8bbaaf0973aa0d13b6e1cedf69e1949&units=metric");
                        var json2 = oneCallAPI.DownloadString(url2);
                        var resoult2 = JsonSerializer.Deserialize<WeatherData>(json2);

                        weatherData = resoult2;
                    }
                }
                return weatherData;
            }
            catch (Exception e)
            {
                throw new NoSuchCityException($"No such city as {cityName} exsist! Try again. ");
            }
        }

        public static BitmapImage ImportImage(string icon)
        {
            
            string path = $"https://openweathermap.org/img/w/{icon}.png";

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(path, UriKind.Absolute);
            bitmap.EndInit();

            return bitmap;
        }

    }
}
