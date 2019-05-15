using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Schedule.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Schedule
{
    public partial class App : Application
    {

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzQ5ODdAMzEzNjJlMzQyZTMwR3BFaUJxUG1Ha3RDZ0NIZ0NVVytRczFaWlVhY09xUmVCa3RKc1FIcDVoYz0=");

            InitializeComponent();


            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
