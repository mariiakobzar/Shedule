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

        public ExerciseListPage(ExerciseListViewModel exerciseViewModel)
        {
            InitializeComponent();
            BindingContext = viewModel = exerciseViewModel;
           // ExercisesList.BackgroundColor = viewModel.ColorType;
        }

        public ExerciseListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ExerciseListViewModel();
        }

        private async void SaveButtonClicked(object sender, EventArgs e)
        {
            await viewModel.ExecuteSaveExerciseCommand();

            //await Navigation.PopAsync();
            //await Navigation.PopModalAsync();
            await Navigation.PopToRootAsync();
        }

        private void ExerciseSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem;
        }


    }
}