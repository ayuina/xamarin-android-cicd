﻿using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;
using System;
using System.Timers;

namespace HelloApp.XamarinAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            AppCenter.Start("1851e084-1a5a-4c87-97e3-f712b406edca", typeof(Analytics), typeof(Crashes), typeof(Distribute));


            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            var timerText = FindViewById<TextView>(Resource.Id.timerTextView);
            this.timer = new Timer()
            {
                Enabled = true,
                Interval = 500
            };

            this.timer.Elapsed += (sender, e) => {
                RunOnUiThread(() => {
                    timerText.Text = DateTime.Now.ToString();
                });
            };

            var appctx = this.ApplicationContext;
            var appinfoText = FindViewById<TextView>(Resource.Id.appinfoTextView);
            appinfoText.Text = appctx.PackageName;

            var pack = appctx.PackageManager.GetPackageInfo(appctx.PackageName, 0);
            var verinfoText = FindViewById<TextView>(Resource.Id.verinfoTextView);
            verinfoText.Text = $"{pack.VersionName}({pack.VersionCode})";

            var inputName = this.FindViewById<EditText>(Resource.Id.inputName).Text;
            var helloButton = this.FindViewById<Button>(Resource.Id.helloButton);
            helloButton.Click += (sender, e) => {
                Toast.MakeText(this, $"Hello {inputName} !!!", ToastLength.Short);
            };
        }


        private Timer timer;


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
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

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}

