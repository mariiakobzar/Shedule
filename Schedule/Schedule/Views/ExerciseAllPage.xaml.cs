using Schedule.Models;
using Schedule.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Schedule.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseAllPage : ContentPage
    {
        #region Fields
        ExerciseAllViewModel viewmodel;
        Image rightImage;
        #endregion

        #region ctor
        public ExerciseAllPage()
        {
            InitializeComponent();
            BindingContext = viewmodel = new ExerciseAllViewModel();
        }

        public ExerciseAllPage(ExerciseAllViewModel exerciseAllViewModel)
        {
            InitializeComponent();
            BindingContext = viewmodel = exerciseAllViewModel;
        }
        #endregion


        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
        #region Methods
        private void OnDelete()
        {
            viewmodel.ExecuteDeleteExerciseCommand();
            ExercisesList.ResetSwipe();
        }
        #endregion

        #region EventHandlers
        private void ItemsListView_SwipeEnded(object sender, Syncfusion.ListView.XForms.SwipeEndedEventArgs e)
        {
            var item = e.ItemData as Exercise;
            viewmodel.SelectedExercise = item;
        }

        private async void SaveButtonClicked(object sender, EventArgs e)
        {
            await viewmodel.ExecuteSaveSelectedExerciseCommand();
            await Navigation.PopToRootAsync();
        }

        private void Image_BindingContextChanged(object sender, EventArgs e)
        {
            if (rightImage == null)
            {
                rightImage = sender as Image;
                (rightImage.Parent as View).GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(OnDelete) });
            }
        }
        #endregion
    }
}