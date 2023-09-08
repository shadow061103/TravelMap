namespace TravelMap.Core.Config
{
    public class SchedulerConfig
    {
        public string JobName { get; set; }

        public string Crontab { get; set; }

        public bool IsEnable { get; set; }
    }
}