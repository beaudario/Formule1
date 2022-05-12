using System.ComponentModel.DataAnnotations;

namespace Formule1Library
{
    public class Team
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string? WikiUrl { get; set; }

        public string CountryID { get; set; }
        public Country Country { get; set; }
        
        /*public int ID { get; set; }
        
        [StringLength(50, ErrorMessage = "Maximumlengte voor {0} is {1} tekens")]
        public string Name { get; set; } = string.Empty;
        
        public string? Description { get; set; } = string.Empty;
        
        [DataType(DataType.Url)]
        [StringLength(250, ErrorMessage = "Maximumlengte voor {0} is {1} tekens")]
        [Display(Name = "Wiki pagina")]
        public string? Wiki { get; set; } = string.Empty;
        
        public Country? Country { get; set; }
        
        public IEnumerable<Result> Races { get; set; } = Enumerable.Empty<Result>();*/
    }
}