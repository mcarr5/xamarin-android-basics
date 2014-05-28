using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Week5
{
    [Activity(Label = "FragmentActivity", MainLauncher = true, Icon = "@drawable/icon")]
    public class FragmentActivity : Activity
    {
        private Button loadCityWeather;
        private Button loadDateTime;
        private string fragmentType;
        private CityFragment cityFragment;
        private WeatherFragment weatherFragment;
        private const string GET_CITY = "Get City";
        private const string DISPLAY_WEATHER = "Display Weather";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Fragment);

            // Get our button from the layout resource,
            // and attach an event to it
            loadCityWeather = FindViewById<Button>(Resource.Id.LoadCityWeather);
            loadCityWeather.Click += loadFragment_Click;

            loadDateTime = FindViewById<Button>(Resource.Id.LoadDateTime);
            loadDateTime.Click += loadDateTime_Click;

            fragmentType = GET_CITY;
            loadGetCity();
        }

        private void loadDateTime_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(this, typeof(DateTimeActivity)));
        }

        private void loadFragment_Click(object sender, EventArgs e)
        {
            if (fragmentType == GET_CITY)
            {
                loadGetCity();
            }
            else
            {
                loadDisplayWeather();
            }
        }

        private void loadGetCity()
        {
            loadCityWeather.Text = DISPLAY_WEATHER;
            fragmentType = DISPLAY_WEATHER;

            // Create a new fragment and a transaction.
            FragmentTransaction fragmentTx = this.FragmentManager.BeginTransaction();
            cityFragment = new CityFragment();
            fragmentTx.Replace(Resource.Id.fragment_container, cityFragment);

            // Commit the transaction.
            fragmentTx.Commit();
        }

        private void loadDisplayWeather()
        {
            loadCityWeather.Text = GET_CITY;
            fragmentType = GET_CITY;

            // Create a new fragment and a transaction.
            FragmentTransaction fragmentTx = this.FragmentManager.BeginTransaction();
            weatherFragment = new WeatherFragment();
            fragmentTx.Replace(Resource.Id.fragment_container, weatherFragment);

            // Commit the transaction.
            fragmentTx.Commit();
        }
    }
}

