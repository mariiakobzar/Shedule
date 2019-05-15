using Schedule.Enums;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Schedule.Models
{
    [Table("Exercises")]
    public class Exercise
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
    }
}
