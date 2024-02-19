namespace BiometricsAPI.Models
{
    public class Biousers
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Pin { get; set; }
        public string Contact { get; set; }
        public Permissions Permissions { get; set; }
    }
}
