using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Week5
{
    public class Weather
    {
        public double CurrentTemp { get; set; }

        public double HighTemp { get; set; }

        public double LowTemp { get; set; }

        public string CurrentTempToDisplay
        {
            get
            {
                return string.Format("Current Temp: {0}°F", KelvinToFahrenheit(CurrentTemp));
            }
        }

        public string HighTempToDisplay
        {
            get
            {
                return string.Format("High Temp: {0}°F", KelvinToFahrenheit(HighTemp));
            }
        }

        public string LowTempToDisplay
        {
            get
            {
                return string.Format("Low Temp: {0}°F", KelvinToFahrenheit(LowTemp));   
            }
        }

        private double KelvinToFahrenheit(double kelvin)
        {            
            return ((kelvin - 273) * 1.8) + 32;
        }
    }
}