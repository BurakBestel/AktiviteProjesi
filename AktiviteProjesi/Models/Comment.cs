namespace AktiviteProjesi.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime PublishDate { get; set; }
        public string Message { get; set; }

    }
}
