using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Week2
{
	[Activity (Label = "First Activity", MainLauncher = true)]
	public class FirstActivity : CommonActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from "first"
			SetContentView (Resource.Layout.First);

			BindButton (Resource.Id.loadSecond, this, typeof(SecondActivity));
			BindButton (Resource.Id.loadThird, this, typeof(ThirdActivity));
		}

		protected override void OnStart()
		{
			base.OnStart ();

			DisplayToast (this, Resource.String.toastOnStart);
		}

		protected override void OnResume()
		{
			base.OnResume();

			DisplayToast (this, Resource.String.toastOnResume);
		}

		protected override void OnPause()
		{
			base.OnPause ();

			DisplayToast (this, Resource.String.toastOnPause);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy ();

			DisplayToast (this, Resource.String.toastOnDestroy);
		}
	}
}


