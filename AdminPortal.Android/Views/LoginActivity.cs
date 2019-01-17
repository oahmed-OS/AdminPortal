using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdminPortal.Android.Views.Dialogs;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace AdminPortal.Android
{
    [Activity(Label = "LoginActivity", Theme = "@style/AppTheme.NoActionBar", NoHistory = true)]
    public class LoginActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login);

        }

    }
}