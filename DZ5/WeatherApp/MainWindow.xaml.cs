using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using Newtonsoft.Json;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string cityName = "Osijek";
            WeatherData weatherData = WeatherUtilities.GetData(cityName);

            ExportData(weatherData, "Osijek");

        }

        private void SearchCity_Click(object sender, RoutedEventArgs e)
        {
            //Dohvacanje podataka o gradu
            string cityName = CityInput.Text;
            try
            {
                WeatherData weatherData = WeatherUtilities.GetData(cityName);
                ExportData(weatherData, cityName);
            }
            catch(NoSuchCityException exception)
            {
                MessageBoxResult result = MessageBox.Show($"{exception.Message}", "Error");
            }
            

        }

        private void ExportData(WeatherData weatherData, string cityName)
        {
            //Ispis Trenutnog vremena
            CurrentCityOutput.Text = $"{cityName}";
            CurrentTemperatureOutput.Text = $"{Convert.ToInt32(weatherData.current.temp)}°C";
            CurrentWindSpeedOutput.Text = $"{weatherData.current.wind_speed} km/h";
            CurrentFeels_likeOutput.Text = $"{Convert.ToInt32(weatherData.current.feels_like)}°C";
            CurrentWeatherIcon.Source = WeatherUtilities.ImportImage(weatherData.current.weather[0].icon);

            //Ispis satnog vremena 1

            HourlyTimeOutput1.Text = $"{WeatherUtilities.UnixTimeToDateTime(weatherData.hourly[1].dt).Hour}:00";
            HourlyTemperatureOutput1.Text = $"{Convert.ToInt32(weatherData.hourly[1].temp)}°C";
            HourlyWindSpeedOutput1.Text = $"{weatherData.hourly[1].wind_speed} km/h";
            HourlyFeels_likeOutput1.Text = $"{Convert.ToInt32(weatherData.hourly[1].feels_like)}°C";
            HourlyIcon1.Source = WeatherUtilities.ImportImage(weatherData.hourly[1].weather[0].icon);

            //Ispis satnog vremena 2

            HourlyTimeOutput2.Text = $"{WeatherUtilities.UnixTimeToDateTime(weatherData.hourly[4].dt).Hour}:00";
            HourlyTemperatureOutput2.Text = $"{Convert.ToInt32(weatherData.hourly[4].temp)}°C";
            HourlyWindSpeedOutput2.Text = $"{weatherData.hourly[4].wind_speed} km/h";
            HourlyFeels_likeOutput2.Text = $"{Convert.ToInt32(weatherData.hourly[4].feels_like)}°C";
            HourlyIcon2.Source = WeatherUtilities.ImportImage(weatherData.hourly[4].weather[0].icon);

            //Ispis satnog vremena 3

            HourlyTimeOutput3.Text = $"{WeatherUtilities.UnixTimeToDateTime(weatherData.hourly[7].dt).Hour}:00";
            HourlyTemperatureOutput3.Text = $"{Convert.ToInt32(weatherData.hourly[7].temp)}°C";
            HourlyWindSpeedOutput3.Text = $"{weatherData.hourly[7].wind_speed} km/h";
            HourlyFeels_likeOutput3.Text = $"{Convert.ToInt32(weatherData.hourly[7].feels_like)}°C";
            HourlyIcon3.Source = WeatherUtilities.ImportImage(weatherData.hourly[7].weather[0].icon);

            //Ispis satnog vremena 4

            HourlyTimeOutput4.Text = $"{WeatherUtilities.UnixTimeToDateTime(weatherData.hourly[10].dt).Hour}:00";
            HourlyTemperatureOutput4.Text = $"{Convert.ToInt32(weatherData.hourly[10].temp)}°C";
            HourlyWindSpeedOutput4.Text = $"{weatherData.hourly[10].wind_speed} km/h";
            HourlyFeels_likeOutput4.Text = $"{Convert.ToInt32(weatherData.hourly[10].feels_like)}°C";
            HourlyIcon4.Source = WeatherUtilities.ImportImage(weatherData.hourly[10].weather[0].icon);

            //Ispis satnog vremena 5

            HourlyTimeOutput5.Text = $"{WeatherUtilities.UnixTimeToDateTime(weatherData.hourly[13].dt).Hour}:00";
            HourlyTemperatureOutput5.Text = $"{Convert.ToInt32(weatherData.hourly[13].temp)}°C";
            HourlyWindSpeedOutput5.Text = $"{weatherData.hourly[10].wind_speed} km/h";
            HourlyFeels_likeOutput5.Text = $"{Convert.ToInt32(weatherData.hourly[13].feels_like)}°C";
            HourlyIcon5.Source = WeatherUtilities.ImportImage(weatherData.hourly[13].weather[0].icon);

            //Ispis satnog vremena 6

            HourlyTimeOutput6.Text = $"{WeatherUtilities.UnixTimeToDateTime(weatherData.hourly[16].dt).Hour}:00";
            HourlyTemperatureOutput6.Text = $"{Convert.ToInt32(weatherData.hourly[16].temp)}°C";
            HourlyWindSpeedOutput6.Text = $"{weatherData.hourly[16].wind_speed} km/h";
            HourlyFeels_likeOutput6.Text = $"{Convert.ToInt32(weatherData.hourly[16].feels_like)}°C";
            HourlyIcon6.Source = WeatherUtilities.ImportImage(weatherData.hourly[16].weather[0].icon);

            //Ispis satnog vremena 7

            HourlyTimeOutput7.Text = $"{WeatherUtilities.UnixTimeToDateTime(weatherData.hourly[19].dt).Hour}:00";
            HourlyTemperatureOutput7.Text = $"{Convert.ToInt32(weatherData.hourly[19].temp)}°C";
            HourlyWindSpeedOutput7.Text = $"{weatherData.hourly[19].wind_speed} km/h";
            HourlyFeels_likeOutput7.Text = $"{Convert.ToInt32(weatherData.hourly[19].feels_like)}°C";
            HourlyIcon7.Source = WeatherUtilities.ImportImage(weatherData.hourly[19].weather[0].icon);

            //Ispis satnog vremena 8

            HourlyTimeOutput8.Text = $"{WeatherUtilities.UnixTimeToDateTime(weatherData.hourly[22].dt).Hour}:00";
            HourlyTemperatureOutput8.Text = $"{Convert.ToInt32(weatherData.hourly[22].temp)}°C";
            HourlyWindSpeedOutput8.Text = $"{weatherData.hourly[22].wind_speed} km/h";
            HourlyFeels_likeOutput8.Text = $"{Convert.ToInt32(weatherData.hourly[22].feels_like)}°C";
            HourlyIcon8.Source = WeatherUtilities.ImportImage(weatherData.hourly[22].weather[0].icon);

            //Ispis dnevnog vremena 1

            DailyTimeOutput1.Text = $"{WeatherUtilities.UnixTimeToDateTime(weatherData.daily[0].dt).DayOfWeek} {WeatherUtilities.UnixTimeToDateTime(weatherData.daily[0].dt).Day}.";
            DailyTemperatureSpanOutput1.Text = $"{Convert.ToInt32(weatherData.daily[0].temp.max)}°C | {Convert.ToInt32(weatherData.daily[0].temp.min)}°C";
            DailyWindSpeedOutput1.Text = $"{weatherData.daily[0].wind_speed} km/h";
            DailyDescriptionOutput1.Text = $"{weatherData.daily[0].weather[0].description}";
            DailyIcon1.Source = WeatherUtilities.ImportImage(weatherData.daily[0].weather[0].icon);

            //Ispis dnevnog vremena 2

            DailyTimeOutput2.Text = $"{WeatherUtilities.UnixTimeToDateTime(weatherData.daily[1].dt).DayOfWeek} {WeatherUtilities.UnixTimeToDateTime(weatherData.daily[1].dt).Day}.";
            DailyTemperatureSpanOutput2.Text = $"{Convert.ToInt32(weatherData.daily[1].temp.max)}°C | {Convert.ToInt32(weatherData.daily[1].temp.min)}°C";
            DailyWindSpeedOutput2.Text = $"{weatherData.daily[1].wind_speed} km/h";
            DailyDescriptionOutput2.Text = $"{weatherData.daily[1].weather[0].description}";
            DailyIcon2.Source = WeatherUtilities.ImportImage(weatherData.daily[1].weather[0].icon);

            //Ispis dnevnog vremena 3

            DailyTimeOutput3.Text = $"{WeatherUtilities.UnixTimeToDateTime(weatherData.daily[2].dt).DayOfWeek} {WeatherUtilities.UnixTimeToDateTime(weatherData.daily[2].dt).Day}.";
            DailyTemperatureSpanOutput3.Text = $"{Convert.ToInt32(weatherData.daily[2].temp.max)}°C | {Convert.ToInt32(weatherData.daily[2].temp.min)}°C";
            DailyWindSpeedOutput3.Text = $"{weatherData.daily[2].wind_speed} km/h";
            DailyDescriptionOutput3.Text = $"{weatherData.daily[2].weather[0].description}";
            DailyIcon3.Source = WeatherUtilities.ImportImage(weatherData.daily[2].weather[0].icon);

            //Ispis dnevnog vremena 4

            DailyTimeOutput4.Text = $"{WeatherUtilities.UnixTimeToDateTime(weatherData.daily[3].dt).DayOfWeek} {WeatherUtilities.UnixTimeToDateTime(weatherData.daily[3].dt).Day}.";
            DailyTemperatureSpanOutput4.Text = $"{Convert.ToInt32(weatherData.daily[3].temp.max)}°C | {Convert.ToInt32(weatherData.daily[3].temp.min)}°C";
            DailyWindSpeedOutput4.Text = $"{weatherData.daily[3].wind_speed} km/h";
            DailyDescriptionOutput4.Text = $"{weatherData.daily[3].weather[0].description}";
            DailyIcon4.Source = WeatherUtilities.ImportImage(weatherData.daily[3].weather[0].icon);

            //Ispis dnevnog vremena 5

            DailyTimeOutput5.Text = $"{WeatherUtilities.UnixTimeToDateTime(weatherData.daily[4].dt).DayOfWeek} {WeatherUtilities.UnixTimeToDateTime(weatherData.daily[4].dt).Day}.";
            DailyTemperatureSpanOutput5.Text = $"{Convert.ToInt32(weatherData.daily[4].temp.max)}°C | {Convert.ToInt32(weatherData.daily[4].temp.min)}°C";
            DailyWindSpeedOutput5.Text = $"{weatherData.daily[4].wind_speed} km/h";
            DailyDescriptionOutput5.Text = $"{weatherData.daily[4].weather[0].description}";
            DailyIcon5.Source = WeatherUtilities.ImportImage(weatherData.daily[4].weather[0].icon);

            //Ispis dnevnog vremena 6

            DailyTimeOutput6.Text = $"{WeatherUtilities.UnixTimeToDateTime(weatherData.daily[5].dt).DayOfWeek} {WeatherUtilities.UnixTimeToDateTime(weatherData.daily[5].dt).Day}.";
            DailyTemperatureSpanOutput6.Text = $"{Convert.ToInt32(weatherData.daily[5].temp.max)}°C | {Convert.ToInt32(weatherData.daily[5].temp.min)}°C";
            DailyWindSpeedOutput6.Text = $"{weatherData.daily[5].wind_speed} km/h";
            DailyDescriptionOutput6.Text = $"{weatherData.daily[5].weather[0].description}";
            DailyIcon6.Source = WeatherUtilities.ImportImage(weatherData.daily[5].weather[0].icon);

            //Ispis dnevnog vremena 7

            DailyTimeOutput7.Text = $"{WeatherUtilities.UnixTimeToDateTime(weatherData.daily[6].dt).DayOfWeek} {WeatherUtilities.UnixTimeToDateTime(weatherData.daily[6].dt).Day}.";
            DailyTemperatureSpanOutput7.Text = $"{Convert.ToInt32(weatherData.daily[6].temp.max)}°C | {Convert.ToInt32(weatherData.daily[6].temp.min)}°C";
            DailyWindSpeedOutput7.Text = $"{weatherData.daily[6].wind_speed} km/h";
            DailyDescriptionOutput7.Text = $"{weatherData.daily[6].weather[0].description}";
            DailyIcon7.Source = WeatherUtilities.ImportImage(weatherData.daily[6].weather[0].icon);

            //Ispis dnevnog vremena 8

            DailyTimeOutput8.Text = $"{WeatherUtilities.UnixTimeToDateTime(weatherData.daily[7].dt).DayOfWeek} {WeatherUtilities.UnixTimeToDateTime(weatherData.daily[7].dt).Day}.";
            DailyTemperatureSpanOutput8.Text = $"{Convert.ToInt32(weatherData.daily[7].temp.max)}°C | {Convert.ToInt32(weatherData.daily[7].temp.min)}°C";
            DailyWindSpeedOutput8.Text = $"{weatherData.daily[7].wind_speed} km/h";
            DailyDescriptionOutput8.Text = $"{weatherData.daily[7].weather[0].description}";
            DailyIcon8.Source = WeatherUtilities.ImportImage(weatherData.daily[7].weather[0].icon);

        }
    }
}
