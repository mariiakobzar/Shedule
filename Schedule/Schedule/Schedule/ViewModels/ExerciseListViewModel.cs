﻿using Schedule.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Schedule.ViewModels
{
    public class ExerciseListViewModel : BaseViewModel
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

        public string SelectedType { get; set; }

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
            }
        }

        public Color ColorType { get; set; }

        //public Command SaveExerciseCommand { get; set; }

        public ExerciseListViewModel()
        {
            Exercises = new ObservableCollection<Exercise>();
            //SaveExerciseCommand = new Command(async () => await ExecuteSaveExerciseCommand());
            DateKey = DateTime.Now;
            FillExercises();
        }

        public ExerciseListViewModel(ExerciseType exerciseType, DateTime selectedDate, Color color)
        {
            SelectedType = exerciseType.TypeName;
            DateKey = selectedDate;
            FillExercises();
            ColorType = color;
            //SaveExerciseCommand = new Command(async () => await ExecuteSaveExerciseCommand());
        }

        private void FillExercises()
        {
            var inctances = _databaseService.GetAllInstances().Where(x => x.Type == SelectedType);
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
                    ColorHex = exerciseColor
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
    }
}