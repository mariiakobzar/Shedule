using Android.App;
using Android.Support.V7.App;

namespace Schedule.Droid
{
    [Activity(Label = "Schedule", Icon = "@drawable/Schedule", Theme = "@style/splashscreen", MainLauncher = true, NoHistory = true)]
    public class SplashScreenActivity : AppCompatActivity
    {
        //protected override void OnCreate(Bundle savedInstanceState)
        //{
        //    base.OnCreate(savedInstanceState);

        //    // Create your application here
        //}

        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(typeof(MainActivity));
        }
    }
}