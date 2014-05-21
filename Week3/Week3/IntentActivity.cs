using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Net;
using Android.Widget;
using Android.Provider;
using Android.Graphics;
using Java.IO;
using Android.Content.PM;
using Android.Preferences;
using System.Collections.ObjectModel;

namespace Week3
{
	[Activity (Label = "IntentActivity")]			
	public class IntentActivity : Activity
	{
		private string intentType;
		private Java.IO.File _file;
		private Java.IO.File _dir;
		private ImageView _imageView;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Intent);

			if (IsThereAnAppToTakePictures())
			{
				CreateDirectoryForPictures();

				_imageView = FindViewById<ImageView>(Resource.Id.imageView1);
			}

			// Create your application here
			intentType = Intent.GetStringExtra (MainActivity.INTENT_TYPE) ?? "";
		}

		public override void OnWindowFocusChanged(bool hasFocus)
		{
			base.OnWindowFocusChanged (hasFocus);
			if (hasFocus && intentType == "show picture") {
				SetImagePicture ();
			}
		}

		protected override void OnResume()
		{
			base.OnResume ();
			if (intentType == "")
				this.Finish();
			else if (intentType != "show picture")
				ProcessIntent ();
		}

		protected override void OnPause()
		{
			base.OnPause ();
			intentType = "";
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);

			if (data != null || resultCode != Result.Canceled) {
				intentType = "show picture";
			}
			// make it available in the gallery
			Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
			var contentUri = Android.Net.Uri.FromFile(_file);
			mediaScanIntent.SetData(contentUri);
			SendBroadcast(mediaScanIntent);
		}

		private void SetImagePicture()
		{
			// display in ImageView. We will resize the bitmap to fit the display
			// Loading the full sized image will consume to much memory 
			// and cause the application to crash.
			int height = _imageView.Height;
			int width = Resources.DisplayMetrics.WidthPixels;
			using (Bitmap bitmap = _file.Path.LoadAndResizeBitmap(width, height))
			{
				_imageView.SetImageBitmap(bitmap);
			}

			intentType = "";
		}

		private void ProcessIntent()
		{
			switch (intentType) {
			case MainActivity.INTENT_TYPE_PHONE:
				var phoneNumber = GetPhoneData ();
				var phoneUri = Android.Net.Uri.Parse (phoneNumber);
				var intent = new Intent (Intent.ActionView, phoneUri);
				StartActivity (intent);
				break;
			case MainActivity.INTENT_TYPE_TEXT:
				var textData = GetTextData ();
				var smsNumber = textData.ElementAt (0);
				var smsMessage = textData.ElementAt (1);
				var smsUri = Android.Net.Uri.Parse (smsNumber);
				var smsIntent = new Intent (Intent.ActionSendto, smsUri);
				smsIntent.PutExtra ("sms_body", smsMessage);  
				StartActivity (smsIntent);
				break;
			case MainActivity.INTENT_TYPE_EMAIL:
				var emailData = GetEmailData ();
				var emailSendTo = emailData.ElementAt (0);
				var emailSubject = emailData.ElementAt (1);
				var emailMessage = emailData.ElementAt (2);
				var emailIntent = new Intent (Android.Content.Intent.ActionSend);
				emailIntent.PutExtra (Android.Content.Intent.ExtraEmail, new string[]{ emailSendTo });
				emailIntent.PutExtra (Android.Content.Intent.ExtraSubject, emailSubject);
				emailIntent.PutExtra (Android.Content.Intent.ExtraText, emailMessage);
				emailIntent.SetType ("message/rfc822");
				StartActivity (emailIntent);
				break;
			case MainActivity.INTENT_TYPE_NAVIGATION:
				var navLocation =  GetNavigationData ();
				var navUri = Android.Net.Uri.Parse (navLocation);
				var navIntent = new Intent (Intent.ActionView, navUri);
				StartActivity(navIntent);
				break;
			case MainActivity.INTENT_TYPE_CAMERA:
				if (IsThereAnAppToTakePictures())
				{
					CreateDirectoryForPictures();
					TakeAPicture ();
				}
				break;
			}
		}

		private void TakeAPicture()
		{
			Intent intent = new Intent(MediaStore.ActionImageCapture);

			_file = new File(_dir, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));

			intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(_file));

			StartActivityForResult(intent, 0);
		}

		private bool IsThereAnAppToTakePictures()
		{
			Intent intent = new Intent(MediaStore.ActionImageCapture);
			IList<ResolveInfo> availableActivities = PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
			return availableActivities != null && availableActivities.Count > 0;
		}

		private void CreateDirectoryForPictures()
		{
			_dir = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), "Week3");
			if (!_dir.Exists())
			{
				_dir.Mkdirs();
			}
		}

		private string GetPhoneData()
		{
			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
			return prefs.GetString(MainActivity.INTENT_PHONE, "");
		}

		private Collection<string> GetTextData()
		{
			Collection<string> textData = new Collection<string> ();

			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);

			textData.Add(prefs.GetString(MainActivity.INTENT_TEXT_NUMBER, ""));
			textData.Add(prefs.GetString(MainActivity.INTENT_TEXT_MESSAGE, ""));

			return textData;
		}

		private Collection<string> GetEmailData()
		{
			Collection<string> emailData = new Collection<string>();

			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
			emailData.Add(prefs.GetString(MainActivity.INTENT_EMAIL_SENDTO, ""));
			emailData.Add(prefs.GetString(MainActivity.INTENT_EMAIL_SUBJECT, ""));
			emailData.Add(prefs.GetString(MainActivity.INTENT_EMAIL_MESSAGE, ""));

			return emailData;
		}

		private string GetNavigationData()
		{
			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
			return prefs.GetString(MainActivity.INTENT_NAVIGATION, "");
		}
	}
}

