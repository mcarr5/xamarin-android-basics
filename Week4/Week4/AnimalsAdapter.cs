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
	public class AnimalsAdapter : BaseAdapter
	{
		List<Animal> _animals;
		Activity _activity;

		public AnimalsAdapter(Activity activity, List<Animal> animals)
		{
			_activity = activity;
			_animals = animals;
		}

		public override int Count {
			get { return _animals.Count; }
		}

		public override Java.Lang.Object GetItem (int position) {
			// could wrap a Contact in a Java.Lang.Object
			// to return it here if needed
			return null;
		}

		public override long GetItemId (int position) {
			return position;
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			var view = convertView ?? _activity.LayoutInflater.Inflate (Resource.Layout.MinnesotaZooListItem, parent, false);
			var animalName = view.FindViewById<TextView> (Resource.Id.animalName);
			var animalImage = view.FindViewById<ImageView> (Resource.Id.animalImage);
			animalName.Text = _animals [position].Name;

			animalImage.SetImageResource (findAnimalImage(animalName.Text));

			return view;
		}

		private int findAnimalImage (string animalName)
		{
			int animalImage = 0;

			string animalResourceName = animalName.ToLower ().Replace (" ", "_");
			System.Reflection.FieldInfo field = typeof(Resource.Drawable).GetField (animalResourceName);
			int animalImageId = (int)field.GetRawConstantValue();
			animalImage = animalImageId;

			return animalImage;
		}
	}
}

