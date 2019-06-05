﻿using Schedule.Constants;
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

        private ObservableCollection<Exercise> _defaultExercises;

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
                SearchItem();
            }
        }

        public Command SaveExerciseCommand { get; set; }

        public ExerciseAllViewModel()
        {
            DateKey = DateTime.Now;
            FillExercises();
            FillColors();
            SaveExerciseCommand = new Command(async () => await ExecuteSaveSelectedExerciseCommand());
        }

        public ExerciseAllViewModel(DateTime dateTime)
        {
            DateKey = dateTime;
            FillExercises();
            FillColors();
            SaveExerciseCommand = new Command(async () => await ExecuteSaveSelectedExerciseCommand());
        }

        private void FillExercises()
        {
            _defaultExercises = new ObservableCollection<Exercise>(_databaseService.GetAllInstances().OrderBy(x => x.Type));
            if (_defaultExercises.Any())
            {
                AllExercises = new ObservableCollection<Exercise>(_defaultExercises);
                ResetSelection();
            }
            else
            {
                AllExercises = new ObservableCollection<Exercise>(Constant.DefaultExercises);
                ResetSelection();
            }
        }

        private void ResetSelection()
        {
            foreach (var item in AllExercises)
            {
                item.IsSelected = false;
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

        public async Task ExecuteSaveSelectedExerciseCommand()
        {
            if (AllExercises.Where(x => x.IsSelected).Any())
            {
                var exercises = AllExercises.Where(x => x.IsSelected == true).ToList();
                _databaseService.InsertMany(exercises);
            }
        }

        private async Task SearchItem()
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
    }
}
