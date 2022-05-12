using System.ComponentModel.DataAnnotations;

namespace Formule1Library
{
    public class Circuit
    {
        [Key] 
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        public double? Latitude { get; set; }
        
        public double? Longitude { get; set; }
        
        public string? WikiUrl { get; set; }

        public string CountryId { get; set; }
        public Country Country { get; set; }
        
        /*public int ID { get; set; }
        
        [StringLength(50, ErrorMessage = "Maximumlengte van {0} is {1} tekens")]
        public string Name { get; set; } = string.Empty;
        
        public string? Description { get; set; } = string.Empty;
        
        public double? Latitude { get; set; }
        
        public double? Longitude { get; set; }
        
        [DataType(DataType.Url)]
        [StringLength(250, ErrorMessage = "Maximumlengte van {0} is {1} tekens")]
        public string? Wiki { get; set; } = string.Empty;
        
        public Country? Country { get; set; }
        
        public IEnumerable<Result> Races { get; set; } = Enumerable.Empty<Result>();*/
    }
}
