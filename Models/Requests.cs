namespace COeX_India.Models
{
    public class Requests
    {
        public int Id { get; set; }
        public int MineId { get; set; }
        public int RailwayStationId { get; set; }
        public string? Message { get; set; }
        public string ExpectedToCallIn { get; set; }
        public DateTime? InsertedAt { get; set; }
        public int InsertedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int UpdatedById { get; set; }
    }
}
