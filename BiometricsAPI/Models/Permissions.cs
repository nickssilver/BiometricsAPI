namespace BiometricsAPI.Models
{
    [Flags]
    public enum Permissions
    {
        None = 0,
        Page1 = 1 << 0, // 1
        Page2 = 1 << 1, // 2
        Page3 = 1 << 2, // 4
        Page4 = 1 << 3, // 8
                        // Add more permissions as needed
    }
}
