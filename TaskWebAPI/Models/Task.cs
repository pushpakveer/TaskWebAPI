namespace TaskWebAPI.Models
{
    public class Task
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public DateTime Created_At { get; set; }

        public DateTime? Updated_At { get; set; }

        public DateOnly Due_Date { get; set; }
    }
}
