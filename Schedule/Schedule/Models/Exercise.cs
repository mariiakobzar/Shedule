using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Schedule.Models
{
    [Table("Exercises")]
    public class Exercise : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        //[ForeignKey(typeof(DateTime))]
        public int DateId { get; set; }

        //[ManyToOne]
        public DateTime Date { get; set; }

        [ForeignKey(typeof(Color))]
        public string ColorHex { get; set; }

        [ManyToOne]
        public Color Color { get; set; }

        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //[Column("imagePath")]
        public string ImagePath { get; set; }

        public bool IsSelected { get; set; } = false;
        public bool IsDone { get; set; } = false;

        private int _touch = 1;
        public int Touch
        {
            get { return _touch; }
            set
            {
                _touch = value;
                OnPropertyChanged("Touch");
                OnPropertyChanged("NumbersFormatted");
            }
        }

        private int _reiteration = 1;
        public int Reiteration
        {
            get { return _reiteration; }
            set
            {
                _reiteration = value;
                OnPropertyChanged("Reiteration");
                OnPropertyChanged("NumbersFormatted");
            }
        }

        private int _weight = 0;
        public int Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                OnPropertyChanged("Weight");
                OnPropertyChanged("NumbersFormatted");
            }
        }

        public string NumbersFormatted => $"({Reiteration} / {Weight}) * {Touch}";

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
