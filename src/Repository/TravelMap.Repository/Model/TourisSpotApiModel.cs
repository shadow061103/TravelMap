namespace TravelMap.Repository.Model
{
    public class TourisSpotApiModel
    {
        public string ScenicSpotName { get; set; }
        public string DescriptionDetail { get; set; }
        public string Phone { get; set; }
        public string OpenTime { get; set; }
        public PictureApiModel Picture { get; set; }
        public PositionApiModel Position { get; set; }
        public string Class1 { get; set; }
        public string Level { get; set; }
        public string City { get; set; }
        public DateTime SrcUpdateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }

    public class PictureApiModel
    {
        public string PictureUrl1 { get; set; }
        public string PictureDescription1 { get; set; }
    }

    public class PositionApiModel
    {
        public float PositionLon { get; set; }
        public float PositionLat { get; set; }
    }
}