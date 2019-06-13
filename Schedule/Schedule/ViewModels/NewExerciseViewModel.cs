using Schedule.Constants;
using Schedule.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Schedule.ViewModels
{
    public class NewExerciseViewModel : BaseViewModel
    {
        #region Fields and Properties
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        private string _selectedType;
        public string SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                OnPropertyChanged("SelectedType");
            }
        }

        public List<string> Types
        {
            get
            {
                return new List<string>()
                {
                    "Груди", "Біцепс", "Спина", "Ноги", "Плечі", "Трицепс", "Прес", "Кардіо", "Інше"
                };
            }
        }

        public Command SaveCommand { get; set; }
        #endregion

        #region ctor
        public NewExerciseViewModel()
        {
            Name = string.Empty;
            Description = string.Empty;
        }
        #endregion

        #region Methods
        public async Task ExecuteSaveExerciseCommand()
        {
            var firstitems = _databaseService.GetAllInstances().ToList();

            if (Name != string.Empty && Description != string.Empty && SelectedType != string.Empty)
            {
                var newExercise = new Exercise()
                {
                    Name = Name,
                    Description = Description,
                    Type = SelectedType,
                    ImagePath = Constant.DefaultExercises.Where(x => x.Type == SelectedType).First().ImagePath
                };

                _databaseService.InsertInstance(newExercise);
                _databaseService.UpdateTable();
            }
        }
        #endregion
    }
}
