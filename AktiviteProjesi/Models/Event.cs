namespace AktiviteProjesi.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime EventDate { get; set; }
        public int Capacity { get; set; }
        public int AvailableSeat { get; set; }
        public string EventImg {  get; set; }
        public int status { get; set; }
    }
}
