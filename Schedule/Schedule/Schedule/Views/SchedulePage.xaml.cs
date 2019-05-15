using Schedule.Models;
using Schedule.ViewModels;
using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Schedule.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SchedulePage : ContentPage, INotifyPropertyChanged
    {
        ScheduleViewModel viewmodel;

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

        public SchedulePage()
        {
            InitializeComponent();
            BindingContext = viewmodel = new ScheduleViewModel();
            viewmodel.InitializeExercices();
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
            //schedule.SelectedDate = DateTime.Now;
            BindingContext = viewmodel = scheduleViewModel;
            schedule.PropertyChanged += Schedule_PropertyChanged;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            schedule.SelectedDate = viewmodel.DateKey;
            viewmodel.UpdateExercisesList();

            UpdateAllAppointments();
        }

        public async void UpdateAllAppointments()
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

        public void UpdateAppointments()
        {
            if (viewmodel.Exercices.Any() /*&& viewmodel.Exercices.Count() >= Appointments.Count()*/)
            {
                Appointments.Clear();

                foreach (var exercise in viewmodel.Exercices)
                {
                    var appointment = new ScheduleAppointment()
                    {
                        StartTime = new DateTime(schedule.SelectedDate.Value.Year, schedule.SelectedDate.Value.Month, schedule.SelectedDate.Value.Day),
                        EndTime = new DateTime(schedule.SelectedDate.Value.Year, schedule.SelectedDate.Value.Month, schedule.SelectedDate.Value.Day),
                        Color = exercise.Color
                    };

                    Appointments.Add(appointment);
                }
            }
        }


        private void ExerciseSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private async void AddNewExerciseClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExerciseTypesPage(new ExerciseTypesViewModel(viewmodel.DateKey)));
        }

        private void Schedule_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedDate")
            {
                var date = (DateTime)schedule.SelectedDate;
                viewmodel.DateKey = date;
                viewmodel.UpdateExercisesList();
                UpdateAllAppointments();
            }
        }

        private void Appointments_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            schedule.DataSource = Appointments;
        }

        private async void MoreButtonClicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Дії:", "Відмінити", null, "Видалити", "dfgdf");
            Debug.WriteLine("Action: " + action);
            if (action == "Видалити")
            {
                viewmodel.ExecuteDeleteExerciseCommand();
                UpdateAllAppointments();
            }
        }
    }
}