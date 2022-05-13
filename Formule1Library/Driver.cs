using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Formule1Library.Data;

namespace Formule1Library
{
    public class Driver
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(75)]
        public string Fullname { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Birthdate { get; set; }

        [StringLength(10)]
        public string? Gender { get; set; }

        [DataType(DataType.Url)]
        [StringLength(250)]
        public string? ImageUrl { get; set; }

        public string? CountryID { get; set; }
        public Country Country { get; set; }

        public ICollection<Result> Results { get; set; }


        /*public int ID { get; set; }
        
        [StringLength(50, ErrorMessage = "Maximumlengte voor {0} is {1} tekens")]
        public string Name { get; set; } = string.Empty;
        
        [DataType(DataType.Date)]
        [Display(Name = "Geboortedatum")]
        public DateTime? Birthdate { get; set; }
        
        [DataType(DataType.Url)]
        [Display(Name = "Wiki pagina")]
        [StringLength(250, ErrorMessage = "Maximumlengte voor {0} is {1} tekens")]
        public string? Wiki { get; set; } = string.Empty;
        
        [RegularExpression("[MVO]{1}", ErrorMessage = "Alleen (M)an, (V)rouw of (O)nbekend")]
        [Column(TypeName = "char")]
        [Display(Name = "Geslacht")]
        [StringLength(1)]
        public string? Gender { get; set; }
        
        [DataType(DataType.Url)]
        [Display(Name="Foto")]
        public string? ImageUrl { get; set; } = string.Empty;
        
        public Country? Country { get; set; }
        
        public IEnumerable<Result> Races { get; set; } = Enumerable.Empty<Result>();*/
    }
}