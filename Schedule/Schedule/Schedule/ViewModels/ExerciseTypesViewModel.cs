using Schedule.Constants;
using Schedule.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Schedule.ViewModels
{
    public class ExerciseTypesViewModel : BaseViewModel
    {
        public List<ExerciseType> ListTypes
        {
            get { return new List<ExerciseType>(Constant.DefaultTypes); }
        }

        public DateTime DateKey { get; set; }

        public ExerciseTypesViewModel()
        {

        }

        public ExerciseTypesViewModel(DateTime dateTime)
        {
            DateKey = dateTime;
        }
    }
}
