using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace Schedule.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://github.com/mariiakobzar/Shedule")));
        }

        public ICommand OpenWebCommand { get; }
    }
}