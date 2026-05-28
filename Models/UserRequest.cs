namespace RepairSystem.Models
{
    public class UserRequest
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string AuthorName { get; set; }

        public DateTime CreatedAt { get; set; }

        public RequestStatus Status { get; set; }

        public string Priority { get; set; }

        public UserRequest()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            Status = RequestStatus.New;
        }
    }
}