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

namespace Week4
{
	[Activity (Label = "SmileyFace")]			
	public class SmileyFace : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.SmileyFace);

			Button faceToggle = FindViewById<Button> (Resource.Id.faceToggle);
			string changeFaceTo = faceToggle.Text;
			var fiftyseven = FindViewById<View> (Resource.Id.fiftyseven);
			var fiftyeight = FindViewById<View> (Resource.Id.fiftyeight);
			var fiftynine = FindViewById<View> (Resource.Id.fiftynine);
			var sixty = FindViewById<View> (Resource.Id.sixty);

			var thirtyseven = FindViewById<View> (Resource.Id.thirtyseven);
			var thirtyeight = FindViewById<View> (Resource.Id.thirtyeight);
			var forty = FindViewById<View> (Resource.Id.forty);
			var fortyone = FindViewById<View> (Resource.Id.fortyone);

			faceToggle.Click += delegate {
				if (changeFaceTo == "Frown")
				{
					fiftyseven.SetBackgroundColor(Android.Graphics.Color.Yellow);
					fiftyeight.SetBackgroundColor(Android.Graphics.Color.Yellow);
					fiftynine.SetBackgroundColor(Android.Graphics.Color.Yellow);
					sixty.SetBackgroundColor(Android.Graphics.Color.Yellow);

					thirtyseven.SetBackgroundColor(Android.Graphics.Color.Transparent);
					thirtyeight.SetBackgroundColor(Android.Graphics.Color.Transparent);
					forty.SetBackgroundColor(Android.Graphics.Color.Transparent);
					fortyone.SetBackgroundColor(Android.Graphics.Color.Transparent);

					faceToggle.SetText("Smile", null);
					changeFaceTo = "Smile";
				}
				else if (changeFaceTo == "Smile")
				{
					fiftyseven.SetBackgroundColor(Android.Graphics.Color.Transparent);
					fiftyeight.SetBackgroundColor(Android.Graphics.Color.Transparent);
					fiftynine.SetBackgroundColor(Android.Graphics.Color.Transparent);
					sixty.SetBackgroundColor(Android.Graphics.Color.Transparent);

					thirtyseven.SetBackgroundColor(Android.Graphics.Color.Yellow);
					thirtyeight.SetBackgroundColor(Android.Graphics.Color.Yellow);
					forty.SetBackgroundColor(Android.Graphics.Color.Yellow);
					fortyone.SetBackgroundColor(Android.Graphics.Color.Yellow);

					faceToggle.SetText("Frown", null);
					changeFaceTo = "Frown";
				}
			};
		}
	}
}

