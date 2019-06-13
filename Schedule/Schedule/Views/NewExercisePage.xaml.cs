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

        #region EventHandlers
        private async void SaveButton_Clicked(object sender, System.EventArgs e)
        {
            await viewModel.ExecuteSaveExerciseCommand();
            await Navigation.PopToRootAsync();
        }

        private async void CancelButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
        #endregion
    }
}