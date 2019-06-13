using Schedule.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Schedule.ViewModels
{
    public class ExerciseListViewModel : BaseViewModel
    {
        #region Fields and Properties
        public string SelectedType { get; set; }

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

        private ObservableCollection<Exercise> exercises;
        public ObservableCollection<Exercise> Exercises
        {
            get
            {
                return exercises;
            }
            set
            {
                exercises = value;
                OnPropertyChanged("Exercises");
            }
        }

        private Exercise selectedExercise;
        public Exercise SelectedExercise
        {
            get
            {
                return selectedExercise;
            }
            set
            {
                selectedExercise = value;
                OnPropertyChanged("SelectedExercise");
            }
        }

        private Color _colorType;
        public Color ColorType
        {
            get { return _colorType; }
            set
            {
                _colorType = value;
                OnPropertyChanged("ColorType");
            }
        }
        #endregion

        #region ctor
        public ExerciseListViewModel()
        {

        }

        public ExerciseListViewModel(ExerciseType exerciseType, DateTime selectedDate, Color color)
        {
            SelectedType = exerciseType.TypeName;
            DateKey = selectedDate;
            ColorType = color;
            UpdateExercises();
        }
        #endregion

        #region Methods
        private void UpdateExercises()
        {
            var allInstances = _databaseService.GetAllInstances().ToList();
            var inctances = _databaseService.GetAllInstances().Where(x => x.Type == SelectedType).ToList();
            foreach (var x in inctances)
            {
                x.ColorHex = GetHexString(ColorType);
            }

            Exercises = new ObservableCollection<Exercise>(inctances);
        }

        public async Task ExecuteSaveExerciseCommand()
        {
            if (SelectedExercise != null)
            {
                var exerciseColor = GetHexString(ColorType);

                var newExercise = new Exercise()
                {
                    Date = DateKey,
                    DateId = DateKey.DayOfYear,
                    Name = SelectedExercise.Name,
                    Type = SelectedExercise.Type,
                    Description = SelectedExercise.Description,
                    ColorHex = exerciseColor,
                    ImagePath = SelectedExercise.ImagePath
                };

                _databaseService.InsertInstance(newExercise);
            }
        }

        public string GetHexString(Color color)
        {
            var red = (int)(color.R * 255);
            var green = (int)(color.G * 255);
            var blue = (int)(color.B * 255);
            var alpha = (int)(color.A * 255);
            var hex = $"#{alpha:X2}{red:X2}{green:X2}{blue:X2}";

            return hex;
        }
        #endregion
    }
}
