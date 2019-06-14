using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Schedule.Droid
{
    [Activity(Label = "Schedule", Icon = "@drawable/Schedule", Theme = "@style/splashscreen", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzQ5ODdAMzEzNjJlMzQyZTMwR3BFaUJxUG1Ha3RDZ0NIZ0NVVytRczFaWlVhY09xUmVCa3RKc1FIcDVoYz0=");
            base.SetTheme(Resource.Style.MainTheme);
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}