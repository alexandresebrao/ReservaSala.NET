using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Parse;
using System;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace ReservaSala.NET
{
	[Activity(Label = "ReservaSala.NET", NoHistory = true, MainLauncher = true, Icon = "@mipmap/icon")]
	public class Login : Activity
	{

		protected override async void OnCreate(Bundle savedInstanceState)
		{

			base.OnCreate(savedInstanceState);

			// Create your application here

			SetContentView(Resource.Layout.Login);

			// Get the TextView To login
			Button btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
			Button btnRegistrar = FindViewById<Button>(Resource.Id.btnRegistrar);
			TextView txtUsername = FindViewById<TextView>(Resource.Id.txtLogin);
			TextView txtPassword = FindViewById<TextView>(Resource.Id.txtPassword);

			btnLogin.Click += delegate
			{
				login(txtUsername.Text, txtPassword.Text);
			};

			btnRegistrar.Click += delegate
			 {
				 SignUpButton_Click(txtUsername.Text, txtPassword.Text);
			 };

			//Start Parse
			Parse.ParseClient.Initialize(new ParseClient.Configuration
			{
				ApplicationId = "Pz4UEHg2wC0JJEXCJmpsj2zb17b6ONsw0K8KXGtX",
				WindowsKey = "430RrqAmDlDAVTgf1FEGKLszCPI1nCACWnYQ9I0t",
				Server = "https://parseapi.back4app.com/"
			});

			ParseUser currentUser = ParseUser.CurrentUser;
			if (currentUser != null) {
				StartActivity(typeof(FirstActivity));
			}
		}



		public async Task login(string username, string password)
		{
			AlertDialog.Builder adp = new AlertDialog.Builder(this);
			adp.SetTitle("Aguarde");
			adp.SetMessage("Fazendo Login");
			AlertDialog adf = adp.Create();
			adf.Show();


			if (await Login.LoginUserAsync(username, password))
			{
				StartActivity(typeof(FirstActivity));
			}
			else { 
				adf.Dismiss();
				Toast.MakeText(this, "Nome de usuário ou senha inválidos", ToastLength.Short).Show();
			}


		}


		public async static Task<bool> LoginUserAsync(string username, string password)
		{
 
     		try
			{
				await ParseUser.LogInAsync(username, password);
				return true;
			}
			catch (Exception ex)
			{
				// Do nothing
			}

			return false;
 
		}

		public async Task SignUpButton_Click(string username, string password)
		{

			AlertDialog.Builder adp = new AlertDialog.Builder(this);
			adp.SetTitle("Aguarde");
			adp.SetMessage("Fazendo Login");
			AlertDialog adf = adp.Create();
			adf.Show();


			var user = new ParseUser()
			{
				Username = username,
				Password = password,
			};

			try
			{
				await user.SignUpAsync();
				login(username, password);
			}
			catch (Exception ex)
			{
				adf.Dismiss();
				Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
			}

		}

	}


}
