using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Threading;
using Android;
using Android.Content.PM;
using System;
using Android.Support.V4.Content;

namespace AvTipus2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView tvTime;
        Exercise ex;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.MasachOnGoing);
            tvTime = (TextView)FindViewById(Resource.Id.tvTime);



            Permission permission = ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation);
            if (permission == Permission.Granted)
            {
                ex = new Exercise();

                ThreadStart threadTime = new ThreadStart(ex.AddSec);
                Thread t1 = new Thread(threadTime);
                t1.Start();

                ThreadStart threadUpdate = new ThreadStart(UpdateTime);
                Thread u1 = new Thread(threadUpdate);
                u1.Start();
            }
            else
                tvTime.Text = "11:11";
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public void UpdateTime()
        {
            while (ex.isGoing)
            {

                RunOnUiThread(() =>
                {
                    tvTime.Text = ex.getTimer();
                });
                Thread.Sleep(1000);
            }
        }
    }
}