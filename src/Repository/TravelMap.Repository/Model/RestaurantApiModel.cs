namespace TravelMap.Repository.Model
{
    public class RestaurantApiModel
    {
        public string RestaurantName { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string OpenTime { get; set; }
        public PictureApiModel Picture { get; set; }
        public PositionApiModel Position { get; set; }
        public string MapUrl { get; set; }
    }
}