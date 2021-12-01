namespace tp_final_api_gate_way.Configuration
{
    public class Service
    {
        public string url { get; set; }
        public string name { get; set; }
        public string key { get; set; }
    }

    public class Services
    {
        public List<Service> services { get; set; }
    }

}
