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
	[Activity (Label = "MinnesotaZooListViewLayout")]			
	public class MinnesotaZooListViewLayout : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.MinnesotaZooListViewLayout);
			var animals = HydrateAnimals ();
			var animalsAdapter = new AnimalsAdapter (this, animals);
			var animalsListView = FindViewById<ListView> (Resource.Id.minnesotaZooListView);
			animalsListView.Adapter = animalsAdapter;
			animalsListView.ItemClick += delegate(object sender, AdapterView.ItemClickEventArgs e) {
				var listView = sender as ListView;
				var animal = animals[e.Position];
				Android.Widget.Toast.MakeText(this, animal.FunFact, Android.Widget.ToastLength.Short).Show();
			};
		}

		private List<Animal> HydrateAnimals()
		{
			var animals = new List<Animal> ();

			animals.Add (new Animal () {
				Name = "Antelope",
				FunFact = "Antelope can reach speeds up to 40mph!",
				Image = Resource.Drawable.antelope
			});
			animals.Add (new Animal () {
				Name = "Bear",
				FunFact = "Bears can also run up to 40mph!",
				Image = Resource.Drawable.bear
			});
			animals.Add (new Animal () {
				Name = "Dolphin",
				FunFact = "Dolphins use a form of sonar to catch their food.",
				Image = Resource.Drawable.dolphin
			});
			animals.Add (new Animal () {
				Name = "Gibbon",
				FunFact = "A gibbon is capable of leaping up to 26 feet!",
				Image = Resource.Drawable.gibbon
			});
			animals.Add (new Animal () {
				Name = "Kamodo Dragon",
				FunFact = "A Komodo Dragon has a deadly bite! One bit can kill its prey within 24 hours from blood poisoning.",
				Image = Resource.Drawable.kamodo_dragon
			});
			animals.Add (new Animal () {
				Name = "Reef Shark",
				FunFact = "Reef sharks give birth to live young after carrying their babies for one year!",
				Image = Resource.Drawable.reef_shark
			});
			animals.Add (new Animal () {
				Name = "Tamarin",
				FunFact = "Male tamarins are the primary care-givers of their young.",
				Image = Resource.Drawable.tamarin
			});
			animals.Add (new Animal () {
				Name = "Tiger Shark",
				FunFact = "Tiger sharks are capable of living in depths of 3000 feet!",
				Image = Resource.Drawable.tiger_shark
			});
			animals.Add (new Animal () {
				Name = "Wolverine",
				FunFact = "Wolverines are known to take down large prey like Caribou and Moose!",
				Image = Resource.Drawable.wolverine
			});

			return animals;
		}
	}
}

