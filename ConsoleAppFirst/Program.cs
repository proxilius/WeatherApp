using Nancy.Json;
using Nancy.ViewEngines;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace ConsoleAppFirst
{

    public class Coord
    {
        public string Lon { get; set; }
        public string lat { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public double message { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class RootObject
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string @base { get; set; }
        public Main main { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
    class Program
    {
        static public RootObject getWeatherForcast(string cityName)
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q="+cityName+"&APPID=d5e03181e7e0b3e1e089527e17b07f43&units=imerial";

            var client = new WebClient();
            var content = client.DownloadString(url);
            var serializer = new JavaScriptSerializer();
            var jsonContent = serializer.Deserialize<RootObject>(content);
            return jsonContent;


        }


        static void Main(string[] args)
        {
            //Program p = new Program();
            //string s=p.getWeatherForcast().ToString();
            Console.WriteLine(getWeatherForcast("Budapest").ToString());
            RootObject m =getWeatherForcast("Budapest");
            Console.WriteLine(m.main.humidity);
        }
    }
}
