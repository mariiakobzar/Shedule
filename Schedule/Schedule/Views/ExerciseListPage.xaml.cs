using Schedule.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Schedule.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseListPage : ContentPage
    {
        ExerciseListViewModel viewModel;

        #region ctor
        public ExerciseListPage(ExerciseListViewModel exerciseViewModel)
        {
            InitializeComponent();
            BindingContext = viewModel = exerciseViewModel;
        }

        public ExerciseListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ExerciseListViewModel();
        }
        #endregion

        #region EventHndlers
        private async void SaveButtonClicked(object sender, EventArgs e)
        {
            await viewModel.ExecuteSaveExerciseCommand();
            await Navigation.PopToRootAsync();
        }
        #endregion
    }
}