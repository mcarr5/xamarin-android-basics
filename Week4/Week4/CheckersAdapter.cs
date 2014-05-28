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
	public class CheckersAdapter : BaseAdapter
	{
		Context context;

		public CheckersAdapter (Context c)
		{
			context = c;
		}

		public override int Count {
			get { return checkerIds.Length; }
		}

		public override Java.Lang.Object GetItem (int position)
		{
			return null;
		}

		public override long GetItemId (int position)
		{
			return 0;
		}

		// create a new ImageView for each item referenced by the Adapter
		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			ImageView imageView;

			if (convertView == null) {  // if it's not recycled, initialize some attributes
				imageView = new ImageView (context);
				imageView.LayoutParameters = new GridView.LayoutParams (85, 85);
				imageView.SetScaleType (ImageView.ScaleType.CenterCrop);
				imageView.SetPadding (8, 8, 8, 8);
			} else {
				imageView = (ImageView)convertView;
			}

			imageView.SetBackgroundColor (boardIds[position]);
			imageView.SetImageResource (checkerIds[position]);

			return imageView;
		}

		Android.Graphics.Color[] boardIds = {
			Android.Graphics.Color.Red, Android.Graphics.Color.Black,
			Android.Graphics.Color.Red, Android.Graphics.Color.Black,
			Android.Graphics.Color.Red, Android.Graphics.Color.Black,
			Android.Graphics.Color.Red, Android.Graphics.Color.Black,

			Android.Graphics.Color.Black, Android.Graphics.Color.Red,
			Android.Graphics.Color.Black, Android.Graphics.Color.Red,
			Android.Graphics.Color.Black, Android.Graphics.Color.Red,
			Android.Graphics.Color.Black, Android.Graphics.Color.Red,

			Android.Graphics.Color.Red, Android.Graphics.Color.Black,
			Android.Graphics.Color.Red, Android.Graphics.Color.Black,
			Android.Graphics.Color.Red, Android.Graphics.Color.Black,
			Android.Graphics.Color.Red, Android.Graphics.Color.Black,

			Android.Graphics.Color.Black, Android.Graphics.Color.Red,
			Android.Graphics.Color.Black, Android.Graphics.Color.Red,
			Android.Graphics.Color.Black, Android.Graphics.Color.Red,
			Android.Graphics.Color.Black, Android.Graphics.Color.Red,

			Android.Graphics.Color.Red, Android.Graphics.Color.Black,
			Android.Graphics.Color.Red, Android.Graphics.Color.Black,
			Android.Graphics.Color.Red, Android.Graphics.Color.Black,
			Android.Graphics.Color.Red, Android.Graphics.Color.Black,

			Android.Graphics.Color.Black, Android.Graphics.Color.Red,
			Android.Graphics.Color.Black, Android.Graphics.Color.Red,
			Android.Graphics.Color.Black, Android.Graphics.Color.Red,
			Android.Graphics.Color.Black, Android.Graphics.Color.Red,

			Android.Graphics.Color.Red, Android.Graphics.Color.Black,
			Android.Graphics.Color.Red, Android.Graphics.Color.Black,
			Android.Graphics.Color.Red, Android.Graphics.Color.Black,
			Android.Graphics.Color.Red, Android.Graphics.Color.Black,

			Android.Graphics.Color.Black, Android.Graphics.Color.Red,
			Android.Graphics.Color.Black, Android.Graphics.Color.Red,
			Android.Graphics.Color.Black, Android.Graphics.Color.Red,
			Android.Graphics.Color.Black, Android.Graphics.Color.Red
		};

		// references to our images
		int[] checkerIds = {
			Resource.Drawable.red_checker, 0,
			Resource.Drawable.red_checker, 0,
			Resource.Drawable.red_checker, 0,
			Resource.Drawable.red_checker, 0,

			0, Resource.Drawable.red_checker,
			0, Resource.Drawable.red_checker,
			0, Resource.Drawable.red_checker,
			0, Resource.Drawable.red_checker,

			Resource.Drawable.red_checker, 0,
			Resource.Drawable.red_checker, 0,
			Resource.Drawable.red_checker, 0,
			Resource.Drawable.red_checker, 0,

			0, 0,
			0, 0,
			0, 0,
			0, 0,

			0, 0,
			0, 0,
			0, 0,
			0, 0,

			0, Resource.Drawable.black_checker,
			0, Resource.Drawable.black_checker,
			0, Resource.Drawable.black_checker,
			0, Resource.Drawable.black_checker,

			Resource.Drawable.black_checker, 0,
			Resource.Drawable.black_checker, 0,
			Resource.Drawable.black_checker, 0,
			Resource.Drawable.black_checker, 0,

			0, Resource.Drawable.black_checker,
			0, Resource.Drawable.black_checker,
			0, Resource.Drawable.black_checker,
			0, Resource.Drawable.black_checker,
		};
	}
}

