using Schedule.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Schedule.ViewModels
{
    public class ScheduleViewModel : BaseViewModel
    {
        #region Properties
        private DateTime dateKey;
        public DateTime DateKey
        {
            get
            {
                if (dateKey.ToString() != "01.01.0001 0:00:00")
                {
                    return dateKey;
                }
                else
                {
                    return DateTime.Now;
                }
            }
            set
            {
                dateKey = value;
                OnPropertyChanged("DateKey");
                UpdateExercises();
            }
        }

        private ObservableCollection<Exercise> _allexercises;
        public ObservableCollection<Exercise> AllExercices
        {
            get
            {
                return _allexercises;
            }
            set
            {
                _allexercises = value;
                OnPropertyChanged("AllExercices");
            }
        }

        private ObservableCollection<Exercise> _exercises;
        public ObservableCollection<Exercise> Exercices
        {
            get
            {
                return _exercises;
            }
            set
            {
                _exercises = value;
                OnPropertyChanged("Exercices");
            }
        }

        private Exercise _selectedExercise;
        public Exercise SelectedExercise
        {
            get { return _selectedExercise; }
            set
            {
                _selectedExercise = value;
                OnPropertyChanged("SelectedExercise");
            }
        }
        #endregion

        #region ctor
        public ScheduleViewModel()
        {

        }
        #endregion

        #region Methods
        public void UpdateExercises()
        {
            var inctances = _databaseService.GetInstancesByDate(DateKey.DayOfYear).ToList();
            var allInstances = _databaseService.GetAllInstances().Where(x => x.Date.ToString() != "01.01.0001 0:00:00").ToList();
            Exercices = new ObservableCollection<Exercise>(inctances);
            AllExercices = new ObservableCollection<Exercise>(allInstances);
            SetColors();
        }

        public void SetColors()
        {
            if (AllExercices.Any())
            {
                foreach (var item in AllExercices)
                {
                    item.Color = Color.FromHex(item.ColorHex);
                }
            }
        }

        public void ExecuteSaveExerciseChanges()
        {
            Exercise oldExercise;
            oldExercise = _databaseService.GetInstance(SelectedExercise.Id) ?? null;
            if (oldExercise == null)
            {
                if (SelectedExercise.Weight == 0 && SelectedExercise.Reiteration == 0 && SelectedExercise.Touch == 0)
                {
                    return;
                }
                oldExercise = SelectedExercise;
                _databaseService.UpdateInstance(oldExercise);
                return;
            }
            if (oldExercise != null)
            {
                oldExercise = SelectedExercise;
                _databaseService.UpdateInstance(oldExercise); //update existed element
                return;
            }
        }

        public void ExecuteDeleteExercise()
        {
            if (SelectedExercise != null)
            {
                _databaseService.DeleteInstance(SelectedExercise);
                UpdateExercises();
            }
        }

        public void CancelChanges()
        {
            Exercise oldExercise;
            try
            {
                oldExercise = _databaseService.GetInstance(SelectedExercise.Id) ?? null;
                SelectedExercise = oldExercise;
                return;
            }
            catch
            {
                return;
            }
        }
        #endregion
    }
}
