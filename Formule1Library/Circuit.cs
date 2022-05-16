using System.ComponentModel.DataAnnotations;

namespace Formule1Library
{
    public class Circuit
    {
        public int ID { get; set; }
        
        [StringLength(50, ErrorMessage = "Maximumlengte van {0} is {1} tekens")]
        public string Name { get; set; } = string.Empty;
        
        public string? Description { get; set; } = string.Empty;
        
        public double? Latitude { get; set; }
        
        public double? Longitude { get; set; }
        
        [DataType(DataType.Url)]
        [StringLength(250, ErrorMessage = "Maximumlengte van {0} is {1} tekens")]
        public string? Wiki { get; set; } = string.Empty;
        
        public Country? Country { get; set; }
        
        public ICollection<Result>? Races { get; set; }
    }
}
