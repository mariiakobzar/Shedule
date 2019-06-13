using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Schedule.Models;
using Schedule.Services;
using Schedule.Interfaces;

namespace Schedule.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataBaseService<Exercise> _databaseService => DependencyService.Get<IDataBaseService<Exercise>>() ?? new ExerciseService();

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
