
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

namespace SignLoginScreen.Resources.activitys
{
    [Activity(Label = "signupActivity")]
    public class signupActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.layout2);
            var imageButton = FindViewById<ImageButton>(Resource.Id.imageView2);
            var firstName = FindViewById<TextView>(Resource.Id.etPassword132);
            var lastName = FindViewById<TextView>(Resource.Id.txtLastName1);
            var emailText = FindViewById<TextView>(Resource.Id.txtEmail1);
            var pwdText = FindViewById<TextView>(Resource.Id.etPassword);
            var submitButton = FindViewById<Button>(Resource.Id.button);
            var displayalartText = new StringBuilder();
            displayalartText.Append(" inVaild this filed of");
            submitButton.Click += delegate
             {
                 string inputemail = lastName.Text.ToString();
                 if (inputemail == null)
                 {
                     displayalartText.Append(" Enter Email Id");
                 }
                 else
                 {
                     var emailValue = isValidEmail(inputemail);
                     if (emailValue != true)
                     {
                         displayalartText.Append(" Enter Email Id");
                     }
                 }
                 if (firstName == null)
                 {
                     displayalartText.Append(" Enter First Name");
                 }
                 else if (firstName.Text.Length < 5)
                 {
                     displayalartText.Append(" Enter First 6 Character");
                 }
                 if (emailText == null)
                 {
                     displayalartText.Append(" Enter Last Name");
                 }
                 else if (lastName.Text.Length < 1)
                 {
                     displayalartText.Append(" Enter Last Above 1 Character");
                 }
                 if (pwdText == null)
                 {
                     displayalartText.Append(" Enter Last Name");
                 }
                 else if (pwdText.Text.Length < 5)
                 {
                     displayalartText.Append(" Enter Last Character");
                 }
                 if (displayalartText.ToString() == " inVaild this filed of")
                 {
                     Intent i = new Intent(this, typeof(MainActivity));
                     //Add PutExtra method data to intent.  
                     i.PutExtra("eMail", inputemail.ToString());
                     i.PutExtra("pwd", pwdText.Text.ToString());
                     i.PutExtra("userName", firstName.Text.ToString());

                     //StartActivity  

                     Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                     AlertDialog alert = dialog.Create();
                     alert.SetTitle("Sucess");
                     alert.SetMessage("Sign Up Success");
                     alert.SetButton("OK", (c, ev) =>
                     {
                         StartActivity(i);
                     });
                     alert.Show();

                     #region WithIcon Alert
                     //Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                     //AlertDialog alert = dialog.Create();
                     //alert.SetTitle("Title");
                     //alert.SetMessage("Complex Alert");
                     //alert.SetIcon(Resource.Drawable.alert);
                     //alert.SetButton("OK", (c, ev) =>
                     //{
                     //    // Ok button click task  
                     //});
                     //alert.SetButton2("CANCEL", (c, ev) => { });
                     //alert.Show();
                     #endregion

                 }
                 else
                 {
                     Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                     AlertDialog alert = dialog.Create();
                     alert.SetTitle("Failed");
                     alert.SetMessage("Sign Up Failed");
                     alert.SetButton("OK", (c, ev) =>
                     {
                         // Ok button click task  
                     });
                     alert.Show();
                 }
             };
            
            imageButton.Click += ImageButton_Click;
        }

        private void ImageButton_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));

            
        }
        public bool isValidEmail(string email)
        {
            return Android.Util.Patterns.EmailAddress.Matcher(email).Matches();
            
        }
    }
}
