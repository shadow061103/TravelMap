namespace TravelMap.Repository.Model
{
    public class HotelApiModel
    {
        public string HotelName { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public PictureApiModel Picture { get; set; }
        public PositionApiModel Position { get; set; }
        public string Class { get; set; }
        public string ServiceInfo { get; set; }
        public string ParkingInfo { get; set; }
        public DateTime SrcUpdateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}