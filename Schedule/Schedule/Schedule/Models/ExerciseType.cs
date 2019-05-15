using Schedule.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Schedule.Models
{
    public class ExerciseType
    {
        public string TypeName { get; set; }

        public ExerciseTypeEnum Type { get; set; }

        public Color TypeColor { get; set; }
    }
}
