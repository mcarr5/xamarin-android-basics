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
    [Activity(Label = "DateTimeActivity")]
    public class DateTimeActivity : Activity
    {
        private DateTime today;
        private int hour;
        private int minute;
        private string timeOfDay;
        private TextView selectedDate;
        private TextView selectedTime;
        const int TIME_DIALOG_ID = 0;
        const int DATE_DIALOG_ID = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.TimeDatePicker);

            GetCurrentTime();

            Button datePicker = FindViewById<Button>(Resource.Id.datePicker);
            Button timePicker = FindViewById<Button>(Resource.Id.timePicker);
            selectedDate = FindViewById<TextView>(Resource.Id.selectedDate);
            selectedTime = FindViewById<TextView>(Resource.Id.selectedTime);

            datePicker.Click += datePicker_Click;
            timePicker.Click += timePicker_Click;                      

            UpdateDateTimeDisplay();
        }

        protected override void OnResume()
        {
            base.OnResume();

            GetCurrentTime();

            UpdateDateTimeDisplay();
        }

        void datePicker_Click(object sender, EventArgs e)
        {
            ShowDialog(DATE_DIALOG_ID);
        }

        void timePicker_Click(object sender, EventArgs e)
        {
            ShowDialog(TIME_DIALOG_ID);
        }

        private void UpdateDateTimeDisplay()
        {
            selectedDate.Text = string.Format("Today's Date is: {0}", today.ToString("d"));
            selectedTime.Text = string.Format("Today's Time is: {0}:{1} {2}", hour, minute.ToString().PadLeft(2, '0'), timeOfDay);
        }

        private void GetCurrentTime()
        {
            // Get the current time
            today = DateTime.Now;
            hour = today.Hour;
            minute = today.Minute;
            GetTimeOfDay();
        }

        private void GetTimeOfDay()
        {
            timeOfDay = "AM";
            if (hour > 12)
            {
                hour -= 12;
                timeOfDay = "PM";
            }
            else if (hour == 0)
            {
                hour += 12;
                timeOfDay = "AM";
            }
            else if (hour == 12)
            {
                timeOfDay = "PM";
            }
        }

        protected override Dialog OnCreateDialog(int id)
        {
            Dialog dialog = null;

            switch (id)
            {
                case TIME_DIALOG_ID:
                    dialog = new TimePickerDialog(this, TimePickerCallback, hour, minute, false);
                    break;
                case DATE_DIALOG_ID:
                    dialog = new DatePickerDialog(this, DatePickerCallback, today.Year, today.Month - 1, today.Day);
                    break;
            }

            return dialog;
        }

        void DatePickerCallback(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            today = e.Date;
            UpdateDateTimeDisplay();
        }

        private void TimePickerCallback(object sender, TimePickerDialog.TimeSetEventArgs e)
        {
            hour = e.HourOfDay;
            minute = e.Minute;
            GetTimeOfDay();

            string time = string.Format("Today's Time is: {0}:{1} {2}", hour, minute.ToString().PadLeft(2, '0'), timeOfDay);
            selectedTime.Text = time;
        }
    }
}