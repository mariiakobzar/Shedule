using Schedule.Models;

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
