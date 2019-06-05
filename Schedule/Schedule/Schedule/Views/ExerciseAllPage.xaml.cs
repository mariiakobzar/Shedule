using Schedule.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Schedule.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseAllPage : ContentPage
    {
        ExerciseAllViewModel viewModel;

        public ExerciseAllPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ExerciseAllViewModel();
        }

        public ExerciseAllPage(ExerciseAllViewModel exerciseAllViewModel)
        {
            InitializeComponent();
            BindingContext = viewModel = exerciseAllViewModel;
        }

        private async void SaveButtonClicked(object sender, EventArgs e)
        {
            await viewModel.ExecuteSaveSelectedExerciseCommand();
            await Navigation.PopToRootAsync();
        }
    }
}