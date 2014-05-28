using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Preferences;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Week5
{
    public class WeatherFragment : Fragment
    {
        private string weatherAPIUrl = "http://api.openweathermap.org/data/2.5/weather?q=";
        private TextView city;
        private TextView currentTemp;
        private TextView highTemp;
        private TextView lowTemp;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.Weather, container, false);

            city = view.FindViewById<TextView>(Resource.Id.cityName);
            currentTemp = view.FindViewById<TextView>(Resource.Id.currentTemp);
            highTemp = view.FindViewById<TextView>(Resource.Id.highTemp);
            lowTemp = view.FindViewById<TextView>(Resource.Id.lowTemp);     
            
            return view;
        }

        public override void OnViewStateRestored(Bundle savedInstanceState)
        {
            base.OnViewStateRestored(savedInstanceState);
            SetupWeatherDisplay();
        }

        public override void OnResume()
        {
            base.OnResume();
            SetupWeatherDisplay();
        }

        private async void SetupWeatherDisplay()
        {
            city.Text = getCityName();
            SetWeatherTextViews(await getWeatherData(city.Text));
        }

        private void SetWeatherTextViews(Weather weather)
        {
            currentTemp.Text = weather.CurrentTempToDisplay;
            highTemp.Text = weather.HighTempToDisplay;
            lowTemp.Text = weather.LowTempToDisplay;
        }

        private string getCityName()
        {
            ISharedPreferences sharedPrefs = PreferenceManager.GetDefaultSharedPreferences(this.Activity);
            string cityName = sharedPrefs.GetString(this.GetString(Resource.String.selected_city), "Minneapolis, MN");
            return cityName;
        }

        private async Task<Weather> getWeatherData(string city)
        {
            Weather weather = new Weather();
            HttpClient httpClient = new HttpClient();
            Task<string> result = httpClient.GetStringAsync(weatherAPIUrl + city);
            JObject json = JObject.Parse(await result);
            weather.CurrentTemp = json.SelectToken("main").Value<double>("temp");
            weather.HighTemp = json.SelectToken("main").Value<double>("temp_max");
            weather.LowTemp = json.SelectToken("main").Value<double>("temp_min");
            return weather;
        }
    }
}