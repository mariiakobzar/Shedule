using Schedule.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.ViewModels
{
    public class ExerciseViewModel : BaseViewModel
    {
        Exercise SelectedExercise
        {
            get
            {
                return SelectedExercise;
            }
            set
            {
                SelectedExercise = value;
                OnPropertyChanged("SelectedExercise");
            }
        }


    }
}
