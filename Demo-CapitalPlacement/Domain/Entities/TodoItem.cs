namespace Demo_CapitalPlacement.Domain.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string RefrenceNumber { get; set; }
        public DateTime ApplyDate { get; set; }
        public int Experience { get; set; }
        public ICollection<TodoOptions> TodoOptions { get; set; } = [];
    }
}
