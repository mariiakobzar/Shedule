using Schedule.Enums;
using Xamarin.Forms;

namespace Schedule.Models
{
    public class ExerciseType
    {
        public string TypeName { get; set; }

        public ExerciseTypeEnum Type { get; set; }

        public Color TypeColor { get; set; }

        public string ImagePath { get; set; }
    }
}
