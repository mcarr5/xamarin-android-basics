using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace HelloMultiScreen
{
	[Activity (Label = "HelloMultiScreen", MainLauncher = true)]
	public class FirstActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.showSecond);
			
			button.Click += (sender, e) => {
				var second = new Intent(this, typeof(SecondActivity));
				second.PutExtra("FirstData", "Data from FirstActivity");
				StartActivity(second);
			};
		}
	}
}


