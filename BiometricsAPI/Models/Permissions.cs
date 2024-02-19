namespace BiometricsAPI.Models
{
    [Flags]
    public enum Permissions
    {
        None = 0,
        Page1 = 1,
        Page2 = 2,
        Page3 = 4,
        Page4 = 8
        // Add more permissions as needed
    }
}
