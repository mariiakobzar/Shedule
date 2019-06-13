using Schedule.Models;
using Schedule.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Schedule.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseTypesPage : ContentPage
    {
        ExerciseTypesViewModel viewmodel;

        #region ctor
        public ExerciseTypesPage(ExerciseTypesViewModel exerciseTypeViewModel)
        {
            InitializeComponent();
            BindingContext = viewmodel = exerciseTypeViewModel;
        }

        public ExerciseTypesPage()
        {
            InitializeComponent();
            BindingContext = viewmodel = new ExerciseTypesViewModel();
        }
        #endregion

        #region EventHandlers
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as ExerciseType;
            if (item == null)
                return;

            await Navigation.PushAsync(new ExerciseListPage(new ExerciseListViewModel(item, viewmodel.DateKey, item.TypeColor)));

            // Manually deselect item.
            ListValues.SelectedItem = null;
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewExercisePage());
        }

        private async void AllButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExerciseAllPage(new ExerciseAllViewModel(viewmodel.DateKey)));
        }
        #endregion
    }
}