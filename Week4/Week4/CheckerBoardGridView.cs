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
	[Activity (Label = "CheckerBoardGridView")]			
	public class CheckerBoardGridView : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.CheckerBoardGridView);

			var gridView = FindViewById<GridView> (Resource.Id.checkerboardGrid);
			gridView.Adapter = new CheckersAdapter (this);
		}
	}
}

