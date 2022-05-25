using System.ComponentModel.DataAnnotations;

namespace Formule1Library
{
    public class Team
    {
        #region Properties

        [Key] public int ID { get; set; }

        [Required]
        [Display(Name = "Naam")]
        [StringLength(50, ErrorMessage = "Maximumlengte voor {0} is {1} tekens")]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [DataType(DataType.Url)]
        [StringLength(250, ErrorMessage = "Maximumlengte voor {0} is {1} tekens")]
        public string? Teamphoto { get; set; }

        [DataType(DataType.Url)]
        [StringLength(250, ErrorMessage = "Maximumlengte voor {0} is {1} tekens")]
        public string? WikiUrl { get; set; }

        #endregion

        #region Relation properties

        public string? CountryID { get; set; }
        public Country? Country { get; set; }

        public IEnumerable<Result>? Results { get; set; }
        
        public IEnumerable<Driver>? Drivers { get; set; }

        #endregion
    }
}