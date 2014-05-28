using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Week4
{
	[Activity (Label = "Week4", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button smileyFace = FindViewById<Button> (Resource.Id.smileyFace);
			Button minnesotaZoo = FindViewById<Button> (Resource.Id.minnesotaZoo);
			Button checkerBoardGrid = FindViewById<Button> (Resource.Id.checkerBoardGrid);

			smileyFace.Click += delegate {
				StartActivity(new Intent(this, typeof(SmileyFace)));
			};
			minnesotaZoo.Click += delegate {
				StartActivity(new Intent(this, typeof(MinnesotaZooListViewLayout)));
			};
			checkerBoardGrid.Click += delegate {
				StartActivity (new Intent (this, typeof(CheckerBoardGridView)));
			};
		}
	}
}


