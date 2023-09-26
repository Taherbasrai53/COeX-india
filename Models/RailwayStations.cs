namespace COeX_India.Models
{
    public class RailwayStations
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Availability { get; set; }
        public string StationAdminId { get; set; }
        public string PassKey { get; set; }
        public string StationCode { get; set; }
        public DateTime? InsertedAt { get; set; }
        public int InsertedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int UpdatedById { get; set; }
    }

    public class RailwayLogInRequest
    {
        public string StationAdminId { get; set; }
        public string PassKey { get; set; }
        public string StationNo { get; set; }
    }

    public class RailwayLogInResponse
    {
        public string Token { get; set; }
        public RailwayStations user { get; set; }
        public RailwayLogInResponse(string Token, RailwayStations user)
        {
            this.Token= Token;
            this.user = user;
        }
    }
}
