using Schedule.Constants;
using Schedule.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Schedule.ViewModels
{
    public class ExerciseAllViewModel : BaseViewModel
    {
        #region Fields and Properties
        private ObservableCollection<Exercise> _defaultExercises;
        public Command SaveExerciseCommand { get; set; }

        private DateTime _dateKey;
        public DateTime DateKey
        {
            get
            {
                return _dateKey;
            }
            set
            {
                _dateKey = value;
                OnPropertyChanged("DateTime");
            }
        }

        private ObservableCollection<Exercise> _allexercises;
        public ObservableCollection<Exercise> AllExercises
        {
            get
            {
                return _allexercises;
            }
            set
            {
                _allexercises = value;
                OnPropertyChanged("AllExercises");
            }
        }

        private ObservableCollection<Exercise> _selectedExercises;
        public ObservableCollection<Exercise> SelectedExercises
        {
            get
            {
                return _selectedExercises;
            }
            set
            {
                _allexercises = value;
                OnPropertyChanged("SelectedExercises");
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

        private string _searchText;
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                OnPropertyChanged("SearchText");
                SearchItemCommand();
            }
        }
        #endregion

        #region ctor
        public ExerciseAllViewModel()
        {
            DateKey = DateTime.Now;
            UpdateExercises();
            FillColors();
            SaveExerciseCommand = new Command(async () => await ExecuteSaveSelectedExerciseCommand());
        }

        public ExerciseAllViewModel(DateTime dateTime)
        {
            DateKey = dateTime;
            UpdateExercises();
            FillColors();
            SaveExerciseCommand = new Command(async () => await ExecuteSaveSelectedExerciseCommand());
        }
        #endregion

        #region Methods
        private void UpdateExercises()
        {
            _defaultExercises = new ObservableCollection<Exercise>(_databaseService.GetAllInstances()
                .Where(x => x.Date.ToString() == "01.01.0001 0:00:00").OrderBy(x => x.Type));
            if (_defaultExercises.Any())
            {
                AllExercises = new ObservableCollection<Exercise>(_defaultExercises);
                FillColors();
                ResetSelection();
                
            }
            else
            {
                AllExercises = new ObservableCollection<Exercise>(Constant.DefaultExercises);
                ResetSelection();
                FillColors();
            }
        }

        private void FillColors()
        {
            var types = Constant.DefaultTypes.ToList();
            foreach (var item in AllExercises)
            {
                item.Color = types.Where(x => x.TypeName == item.Type).First().TypeColor;
                item.ColorHex = Constant.GetHexString(item.Color);
                item.Date = DateKey;
                item.DateId = DateKey.DayOfYear;
            }
        }

        private void ResetSelection()
        {
            foreach (var item in AllExercises)
            {
                item.IsSelected = false;
            }
        }

        public void ExecuteDeleteExerciseCommand()
        {
            if (SelectedExercise != null)
            {
                _databaseService.DeleteInstance(SelectedExercise);
                _databaseService.UpdateTable();
                UpdateExercises();
            }
        }

        public async Task ExecuteSaveSelectedExerciseCommand()
        {
            if (AllExercises.Where(x => x.IsSelected).Any())
            {
                var exercises = AllExercises.Where(x => x.IsSelected == true).ToList();
                _databaseService.InsertMany(exercises);
            }
        }

        private async Task SearchItemCommand()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                AllExercises = _defaultExercises;
            }
            else
            {
                AllExercises = new ObservableCollection<Exercise>(_defaultExercises.Where(i => i.Name.ToLower().Contains(SearchText)));
            }
        }
        #endregion
    }
}
