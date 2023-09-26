namespace COeX_India.Models
{
    public class Mines
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double CurrYield { get; set; }
        public double YieldPerDay { get; set; }
        public double TriggerYield { get; set; }
        public DateTime? InsertedAt { get; set; }
        public int InsertedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int UpdatedById { get; set; }
        public EStatus Status { get; set; }

        public enum EStatus
        {
            Inactive=0,
            Active=1,
            RequestSent=2,
            RequestAccepted=3,
        }
    }
}
