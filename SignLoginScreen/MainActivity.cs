using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using SignLoginScreen.Resources.activitys;

namespace SignLoginScreen
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_login
                );
            var clickLogin = FindViewById<Button>(Resource.Id.button);
            var userMail = FindViewById<EditText>(Resource.Id.etPassword1);
            var userPWD = FindViewById<EditText>(Resource.Id.etPassword);

            clickLogin.Click += delegate {
                var emailText = Intent.GetStringExtra("eMail");
                var pwdText = Intent.GetStringExtra("pwd");
                if (emailText.ToString() == userMail.Text.ToString())
                {
                    if(pwdText.ToString() == userPWD.Text.ToString())
                    {
                        Android.App.AlertDialog.Builder dialog1 = new Android.App.AlertDialog.Builder(this);
                        Android.App.AlertDialog alert1 = dialog1.Create();
                        alert1.SetTitle("Login Sucess");
                        var userNameIntent = Intent.GetStringExtra("userName");
                        alert1.SetMessage($"Hi {userNameIntent} Good Day");
                        alert1.SetButton("OK", (c, ev) =>
                        {

                            StartActivity(typeof(HomeActivity));
                        });
                        alert1.Show();
                    }
                    else
                    {
                        
                        Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                        Android.App.AlertDialog alert = dialog.Create();
                        alert.SetTitle("Failed");
                        alert.SetMessage($"Password Incorrect");
                        alert.SetButton("OK", (c, ev) =>
                        {
                            //   StartActivity(i);
                        });
                        alert.Show();
                        }
                   
                }
                else
                {
                    Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                    Android.App.AlertDialog alert = dialog.Create();
                    alert.SetTitle("Login Failed");
                    alert.SetMessage("Enter Valid Credentials");
                    alert.SetButton("OK", (c, ev) =>
                    {
                     //   StartActivity(i);
                    });
                    alert.Show();
                }
            };
            var fabClick = FindViewById<FloatingActionButton>(Resource.Id.floatingActionButton);
            fabClick.Click += FabClick_Click;
        }

        private void FabClick_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(signupActivity));
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return false;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

