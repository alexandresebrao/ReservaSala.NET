
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
using Parse;

namespace ReservaSala.NET
{
	[Activity(Label = "FirstActivity")]
	public class FirstActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.HomePage);

			TextView lblWelcome = FindViewById<TextView>(Resource.Id.lblWelcome);

			ParseUser currentUser = ParseUser.CurrentUser;
			string welcome = "Bem vindo " + currentUser.Get<String>("username");
			lblWelcome.Text = welcome;



		}
	}
}
