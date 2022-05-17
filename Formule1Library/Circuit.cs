using System.ComponentModel.DataAnnotations;

namespace Formule1Library
{
    public class Circuit
    {
<<<<<<< HEAD
        public int ID { get; set; }

        public string? Image { get; set; } = string.Empty;
        
        [StringLength(50, ErrorMessage = "Maximumlengte van {0} is {1} tekens")]
        public string Name { get; set; } = string.Empty;
        
        public string? Description { get; set; } = string.Empty;
        
        public double? Latitude { get; set; }
        
        public double? Longitude { get; set; }
        
=======
        #region Properties

        [Key] public int ID { get; set; }

        [Required]
        [Display(Name = "Naam")]
        [StringLength(50, ErrorMessage = "Maximum lengte van {0} is {1} tekens")]
        public string Name { get; set; }

        [Display(Name = "Lengtegraad")] public double? Latitude { get; set; }

        [Display(Name = "Breedtegraad")] public double? Longitude { get; set; }

>>>>>>> master
        [DataType(DataType.Url)]
        [StringLength(250, ErrorMessage = "Maximum lengte van {0} is {1} tekens")]
        public string? WikiUrl { get; set; }

        #endregion

        #region Relation properties

        public string? CountryID { get; set; }
        public Country Country { get; set; }

        public ICollection<Result> Results { get; set; }

        #endregion
    }
}