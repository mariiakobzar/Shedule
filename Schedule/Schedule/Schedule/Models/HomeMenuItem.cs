using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Models
{
    public enum MenuItemType
    {
        Schedule,
        Browse,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
