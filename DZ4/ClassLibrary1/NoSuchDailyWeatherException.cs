using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace WeatherClass
{
    public class NoSuchDailyWeatherException : Exception
    {
        DateTime date;

        public NoSuchDailyWeatherException(){}
        public NoSuchDailyWeatherException(string message) : base(message) { }
        public NoSuchDailyWeatherException(string message, Exception innerException) : base(message, innerException) { }
        protected NoSuchDailyWeatherException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public NoSuchDailyWeatherException(string message, DateTime date) : base(message) {
            this.date = date;
        }    

    }
}
