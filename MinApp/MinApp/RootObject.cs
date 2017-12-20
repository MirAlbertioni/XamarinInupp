namespace MinApp
{
    public class Rootobject
    {
        public Stoplocation[] StopLocation { get; set; }
    }

    public class Stoplocation
    {
        public string id { get; set; }
        public string extId { get; set; }
        public string name { get; set; }
        public float lon { get; set; }
        public float lat { get; set; }
        public int weight { get; set; }
        public int products { get; set; }
    }
}