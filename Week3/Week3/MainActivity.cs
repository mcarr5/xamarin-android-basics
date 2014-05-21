using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Preferences;

namespace Week3
{
	[Activity (Label = "Week3", MainLauncher = true)]
	public class MainActivity : Activity
	{
		public static string INTENT_TYPE = "intent type";
		public const string INTENT_TYPE_PHONE = "phone";
		public const string INTENT_TYPE_TEXT = "text";
		public const string INTENT_TYPE_EMAIL = "email";
		public const string INTENT_TYPE_NAVIGATION = "navigation";
		public const string INTENT_TYPE_CAMERA = "camera";

		public static string INTENT_PHONE = "phone value";
		public static string INTENT_TEXT_NUMBER = "text number value";
		public static string INTENT_TEXT_MESSAGE = "text message value";
		public static string INTENT_EMAIL_SENDTO = "email sendto value";
		public static string INTENT_EMAIL_SUBJECT = "email subject value";
		public static string INTENT_EMAIL_MESSAGE = "email message value";
		public static string INTENT_NAVIGATION = "navigation value";

		private static string INTENT_PHONE_VALUE = "tel:1112223333";
		private static string INTENT_TEXT_NUMBER_VALUE = "smsto:1234567890";
		private static string INTENT_TEXT_MESSAGE_VALUE = "Hello sms, from Xamarin.Android";
		private static string INTENT_EMAIL_SENDTO_VALUE = "mattc@magenic.com";
		private static string INTENT_EMAIL_SUBJECT_VALUE = "Hello";
		private static string INTENT_EMAIL_MESSAGE_VALUE = "Hello email, from Xamarin.Android";
		// magenic coords
		private static string INTENT_NAVIGATION_VALUE = "geo:44.966506, -93.345512";

		private TextView _timesAccessedView;
		private int _timesAccessed = 0;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Should the preferences be cleared on start?
//			ClearSharedPreferences ();

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			_timesAccessedView = FindViewById<TextView> (Resource.Id.timesAccessed);

			// Get our button from the layout resource,
			// and attach an event to it
			Button phoneButton = FindViewById<Button> (Resource.Id.phoneButton);
			phoneButton.Click += delegate {
				var intent = new Intent (this, typeof(IntentActivity));
				intent.PutExtra(INTENT_TYPE, INTENT_TYPE_PHONE);
				SavePhoneData();
				StartActivity (intent);
			};

			Button textButton = FindViewById<Button> (Resource.Id.textButton);
			textButton.Click += delegate {
				var intent = new Intent (this, typeof(IntentActivity));
				intent.PutExtra(INTENT_TYPE, INTENT_TYPE_TEXT);
				SaveTextData();
				StartActivity (intent);
			};

			Button emailButton = FindViewById<Button> (Resource.Id.emailButton);
			emailButton.Click += delegate {
				var intent = new Intent (this, typeof(IntentActivity));
				intent.PutExtra(INTENT_TYPE, INTENT_TYPE_EMAIL);
				SaveEmailData();
				StartActivity (intent);
			};

			Button navigationButton = FindViewById<Button> (Resource.Id.navigationButton);
			navigationButton.Click += delegate {
				var intent = new Intent (this, typeof(IntentActivity));
				intent.PutExtra(INTENT_TYPE, INTENT_TYPE_NAVIGATION);
				SaveNavigationData();
				StartActivity (intent);
			};

			Button cameraButton = FindViewById<Button> (Resource.Id.cameraButton);
			cameraButton.Click += delegate {
				var intent = new Intent (this, typeof(IntentActivity));
				intent.PutExtra(INTENT_TYPE, INTENT_TYPE_CAMERA);
				StartActivity (intent);
			};
		}

		protected override void OnResume()
		{
			base.OnResume ();
			SetAccessCountTextView ();
		}

		protected override void OnPause()
		{
			base.OnPause ();
			SaveAccessCount ();
		}

		private void SetAccessCountTextView()
		{
			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
			_timesAccessed = prefs.GetInt ("access_count", 0) + 1;
			_timesAccessedView.SetText (string.Format("{0} {1}", Resources.GetString(Resource.String.timesAccessed), _timesAccessed), null);
		}

		private void SaveAccessCount()
		{
			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
			ISharedPreferencesEditor editor = prefs.Edit();
			editor.PutInt("access_count", _timesAccessed);			
			editor.Apply();
		}

		private void SavePhoneData()
		{
			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
			ISharedPreferencesEditor editor = prefs.Edit();
			editor.PutString(INTENT_PHONE, INTENT_PHONE_VALUE);			
			editor.Apply();
		}

		private void SaveTextData()
		{
			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
			ISharedPreferencesEditor editor = prefs.Edit();
			editor.PutString(INTENT_TEXT_NUMBER, INTENT_TEXT_NUMBER_VALUE);
			editor.PutString(INTENT_TEXT_MESSAGE, INTENT_TEXT_MESSAGE_VALUE);			
			editor.Apply();
		}

		private void SaveEmailData()
		{
			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
			ISharedPreferencesEditor editor = prefs.Edit();
			editor.PutString(INTENT_EMAIL_SENDTO, INTENT_EMAIL_SENDTO_VALUE);
			editor.PutString(INTENT_EMAIL_SUBJECT, INTENT_EMAIL_SUBJECT_VALUE);
			editor.PutString(INTENT_EMAIL_MESSAGE, INTENT_EMAIL_MESSAGE_VALUE);		
			editor.Apply();
		}

		private void SaveNavigationData()
		{
			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
			ISharedPreferencesEditor editor = prefs.Edit();
			editor.PutString(INTENT_NAVIGATION, INTENT_NAVIGATION_VALUE);			
			editor.Apply();
		}

		private void ClearSharedPreferences()
		{
			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
			ISharedPreferencesEditor editor = prefs.Edit();
			editor.Clear ();
			editor.Apply ();
		}
	}
}


