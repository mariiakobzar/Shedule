namespace Schedule.Models
{
    public enum MenuItemType
    {
        Schedule,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
