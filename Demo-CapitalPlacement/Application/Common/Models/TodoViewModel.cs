namespace Demo_CapitalPlacement.Application.Common.Models
{
    public class TodoViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string RefrenceNumber { get; set; }
        public DateTime ApplyDate { get; set; }
        public int Experience { get; set; }
        public List<TodoOptionsViewModel> TodoOptionsViewModels { get; set; }
    }
}
