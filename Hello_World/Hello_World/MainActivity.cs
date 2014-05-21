using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Hello_World
{
	[Activity (Label = "Hello_World", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

//			var layout = new LinearLayout (this);
//			layout.Orientation = Orientation.Vertical;
//
//			var aLabel = new TextView (this);
//			aLabel.SetText(Resource.String.helloLabelText);
//
//			var aButton = new Button (this);
//			aButton.SetText(Resource.String.helloButtonText);
//			aButton.Click += (sender, e) => {
//				aLabel.Text = "Hello from the button";
//			};
//
//			layout.AddView (aLabel);
//			layout.AddView (aButton);
//			SetContentView (layout);

			SetContentView (Resource.Layout.Main);

			Button aButton = FindViewById<Button> (Resource.Id.aButton);
			var aLabel = FindViewById<TextView> (Resource.Id.helloLabel);

			aButton.Click += (sender, e) => {
				aLabel.Text = "Hello from the button";
			};
		}
	}
}


