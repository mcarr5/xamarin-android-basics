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

namespace Week2
{
	[Activity (Label = "Second Activity")]			
	public class SecondActivity : CommonActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.Second);

			BindButton (Resource.Id.loadFirst, this, typeof(FirstActivity));
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
	}
}

