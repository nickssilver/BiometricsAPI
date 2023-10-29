namespace BiometricsAPI.Models
{
    public class StudentModel
    {
        public string AdmnNo { get; set; } // StudentId
        public string names { get; set; } // StudentName
        public string Class { get; set; } // ClassId
        public string StudStatus { get; set; } // Status
        public decimal Arrears { get; set; } // Arrears
    }
}
