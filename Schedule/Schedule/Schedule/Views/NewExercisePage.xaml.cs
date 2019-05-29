using Schedule.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Schedule.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewExercisePage : ContentPage, INotifyPropertyChanged
    {
        NewExerciseViewModel viewModel;

        public NewExercisePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new NewExerciseViewModel();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await viewModel.ExecuteSaveExerciseCommand();
            await Navigation.PopToRootAsync();
        }
    }
}