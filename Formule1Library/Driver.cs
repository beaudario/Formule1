using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Formule1Library.Data;

namespace Formule1Library
{
    public class Driver
    {
        #region Properties

        [Key] public int ID { get; set; }

        [Display(Name = "Volledige naam")]
        [Required]
        [StringLength(75)]
        public string Fullname { get; set; }

        [Display(Name = "Geboortedatum")]
        [DataType(DataType.Date)]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Geslacht")]
        [RegularExpression("[MVO]{1}", ErrorMessage = "Alleen (M)an, (V)rouw of (O)nbekend")]
        [StringLength(1)]
        public string? Gender { get; set; }

        [DataType(DataType.Url)]
        [StringLength(250, ErrorMessage = "Maximumlengte voor {0} is {1} tekens")]
        public string? ImageUrl { get; set; }

        [DataType(DataType.Url)]
        [StringLength(250, ErrorMessage = "Maximumlengte voor {0} is {1} tekens")]
        public string? WikiUrl { get; set; }

        #endregion

        #region Relation properties

        public string? CountryID { get; set; }
        public Country Country { get; set; }

        public ICollection<Result> Results { get; set; }
        
        public ICollection<Team> Teams { get; set; }

        #endregion
    }
}