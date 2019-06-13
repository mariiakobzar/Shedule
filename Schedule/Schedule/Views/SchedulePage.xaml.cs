using Schedule.Models;
using Schedule.ViewModels;
using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Schedule.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SchedulePage : ContentPage, INotifyPropertyChanged
    {
        #region Properties and Fields
        ScheduleViewModel viewmodel;
        Image rightImage;

        private ObservableCollection<ScheduleAppointment> _appointments;
        public ObservableCollection<ScheduleAppointment> Appointments
        {
            get
            {
                return _appointments;
            }
            set
            {
                _appointments = value;
                OnPropertyChanged("Appointments");
            }
        }
        #endregion

        #region ctors
        public SchedulePage()
        {
            InitializeComponent();
            BindingContext = viewmodel = new ScheduleViewModel();
            viewmodel.UpdateExercises();
            Appointments = new ObservableCollection<ScheduleAppointment>();
            Appointments.CollectionChanged += Appointments_CollectionChanged;
            schedule.SelectedDate = DateTime.Now;

            schedule.PropertyChanged += Schedule_PropertyChanged;
            schedule.MonthViewSettings.AppointmentDisplayCount = 2;
        }

        public SchedulePage(ScheduleViewModel scheduleViewModel)
        {
            InitializeComponent();
            Appointments = new ObservableCollection<ScheduleAppointment>();
            Appointments.CollectionChanged += Appointments_CollectionChanged;
            BindingContext = viewmodel = scheduleViewModel;
            schedule.PropertyChanged += Schedule_PropertyChanged;
        }
        #endregion

        #region Lifecycle
        protected override void OnAppearing()
        {
            base.OnAppearing();
            schedule.SelectedDate = viewmodel.DateKey;
            viewmodel.UpdateExercises();
            UpdateAppointments();
        }
        #endregion

        #region Methods
        public void UpdateAppointments()
        {
            if (viewmodel.AllExercices.Any())
            {
                Appointments.Clear();
                foreach (var exercise in viewmodel.AllExercices)
                {
                    var appointment = new ScheduleAppointment()
                    {
                        StartTime = new DateTime(exercise.Date.Year, exercise.Date.Month, exercise.Date.Day),
                        EndTime = new DateTime(exercise.Date.Year, exercise.Date.Month, exercise.Date.Day),
                        Color = exercise.Color
                    };
                    Appointments.Add(appointment);
                }
            }
            else if (!viewmodel.AllExercices.Any())
            {
                Appointments.Clear();
            }
        }

        private void OnDelete()
        {
            viewmodel.ExecuteDeleteExercise();
            ItemsListView.ResetSwipe();
            UpdateAppointments();
        }
        #endregion

        #region EventHandlers
        private async void AddNewExerciseClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExerciseTypesPage(new ExerciseTypesViewModel(viewmodel.DateKey)));
        }

        private void Appointments_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            schedule.DataSource = Appointments;
        }

        private void Schedule_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedDate")
            {
                var date = (DateTime)schedule.SelectedDate;
                viewmodel.DateKey = date;
                UpdateAppointments();
            }
        }

        private void ItemsListView_SwipeEnded(object sender, Syncfusion.ListView.XForms.SwipeEndedEventArgs e)
        {
            var item = e.ItemData as Exercise;
            viewmodel.SelectedExercise = item;
        }

        private void ItemsListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            //OnAppearing();
            var item = e.ItemData as Exercise;
            viewmodel.SelectedExercise = item;
            popupView.IsVisible = true;
            editView.RaiseChild(popupView);
        }

        private void Image_BindingContextChanged(object sender, EventArgs e)
        {
            if (rightImage == null)
            {
                rightImage = sender as Image;
                (rightImage.Parent as View).GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(OnDelete) });
            }
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            viewmodel.ExecuteSaveExerciseChanges();
            editView.LowerChild(popupView);
            popupView.IsVisible = false;
            OnAppearing();
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            viewmodel.CancelChanges();
            editView.LowerChild(popupView);
            popupView.IsVisible = false;
            OnAppearing();
        }
        #endregion


    }
}