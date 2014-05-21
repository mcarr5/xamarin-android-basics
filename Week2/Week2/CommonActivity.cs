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
	public class CommonActivity : Activity
	{
		public void DisplayToast(Context context, int resId)
		{
			Toast toast = Toast.MakeText (context, resId, ToastLength.Short);
			toast.Show ();
		}

		public void BindButton(int resId, Activity activity, Type type)
		{
			Button btn = activity.FindViewById<Button> (resId);

			btn.Click += (sender, e) => {
				var intent = new Intent(activity, type);
				if (type == typeof(FirstActivity))
				{
					intent.SetFlags(ActivityFlags.ClearTop);
				}
				else
				{
					intent.SetFlags(ActivityFlags.NoHistory);
				}
				StartActivity (intent);
			};
		}
	}
}

