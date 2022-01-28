using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp
{
    class NoSuchCityException:Exception
    {
        public NoSuchCityException() { }
        public NoSuchCityException(string message) :base(message) { }
        public NoSuchCityException(string message,Exception innerException) : base(message,innerException) { }      
    }
}
