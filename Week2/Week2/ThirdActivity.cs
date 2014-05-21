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
using Android.Webkit;

namespace Week2
{
	[Activity (Label = "Third Activity")]			
	public class ThirdActivity : CommonActivity
	{
		private WebView webView;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.Third);

			BindButton (Resource.Id.loadFirst, this, typeof(FirstActivity));
			BindButton (Resource.Id.loadSecond, this, typeof(SecondActivity));

			webView = FindViewById<WebView> (Resource.Id.webView);
			webView.Settings.JavaScriptEnabled = true;
			webView.SetWebViewClient (new ThirdActivityWebViewClient ());
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
			webView.LoadUrl ("http://magenic.com/Services/MobileEnterpriseDevelopment/AndroidApplicationDevelopment");
		}

		protected override void OnPause()
		{
			base.OnPause ();

			DisplayToast (this, Resource.String.toastOnPause);
		}

		public class ThirdActivityWebViewClient : WebViewClient
		{
			public override bool ShouldOverrideUrlLoading (WebView view, string url)
			{
				view.LoadUrl (url);
				return true;
			}
		}
	}
}

