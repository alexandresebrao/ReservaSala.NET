using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Parse;
using System;

namespace ReservaSala.NET
{
	
	public class MainActivity : Activity
	{

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			//Parse Initialization
			StartParse();


			// Get our button from the layout resource,
			// and attach an event to it
			Button btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
			Button btnRegister = FindViewById<Button>(Resource.Id.btnRegister);

			btnLogin.Click += delegate { 
				StartActivity(typeof(Login)); 
			};
		}

		void StartParse()
		{

		}
	}
}

