using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WeatherClass
{
    public class DailyForecastRepository : IEnumerable, IEnumerator
    {
        List<DailyForecast> listOfWeathers;
        int position = -1;

        public DailyForecastRepository(){
            listOfWeathers = new List<DailyForecast>();
        }

        public DailyForecastRepository(DailyForecastRepository oldRepository){
            listOfWeathers = new List<DailyForecast>();
            foreach(DailyForecast weather in oldRepository.listOfWeathers){
                listOfWeathers.Add(weather);
            }
        }
        
        public void Add(DailyForecast dailyForecast){
            bool flag=true;
            int i;
            for(i = 0; i < listOfWeathers.Count; i++){
                if(listOfWeathers[i].Date.Year == dailyForecast.Date.Year && listOfWeathers[i].Date.Month == dailyForecast.Date.Month && listOfWeathers[i].Date.Day == dailyForecast.Date.Day){
                    listOfWeathers[i] = dailyForecast;
                    flag = false;       
                }
            }
            if(flag){
                listOfWeathers.Add(dailyForecast);
            }
            Sort();
        }

        public void Add(List<DailyForecast> dailyForecasts){
            foreach(DailyForecast weather in dailyForecasts){
                Add(weather);
            }
            //Sort();
        }

        public void Remove(DateTime date){
            bool flag=true;
            for(int i=0; i<listOfWeathers.Count; i++){
                if(listOfWeathers[i].Date.Year == date.Year && listOfWeathers[i].Date.Month == date.Month && listOfWeathers[i].Date.Day == date.Day){
                    listOfWeathers.RemoveAt(i);
                    flag = false;       
                }
            }
            if(flag){
                throw new NoSuchDailyWeatherException($"No such date {date}", date);
            }
            Sort();  
        }

        public void Sort(){
            int index;
            DailyForecast tmp;
            for (int i = 0; i < (listOfWeathers.Count - 1); i++)
                {
                index = i;
                for (int j = i + 1; j < listOfWeathers.Count; j++)
                {
                    if (listOfWeathers[index].Date > listOfWeathers[j].Date)
                    index = j;
                }
                if (index != i)
                {
                tmp = listOfWeathers[i];
                listOfWeathers[i] = listOfWeathers[index];
                listOfWeathers[index] = tmp;
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            position++;
            return (position<listOfWeathers.Count);
        }

        public void Reset()
        {
            position = -1;
        }
        
        public object Current
        {
            get {return listOfWeathers[position]; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < listOfWeathers.Count; i++)
            {
                sb.Append(listOfWeathers[i].ToString());
                sb.Append("\n");
            }

            return sb.ToString();
        }
    }
}
