using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formule1Library
{
    public class Country
    {
        #region Properties

        [Key]
        [RegularExpression("[A-Z]{2}", ErrorMessage = "Landcode moet bestaan uit 2 hoofdletters")]
        [StringLength(2)]
        public string ID { get; set; }

        [RegularExpression("[A-Z]{3}", ErrorMessage = "Landcode moet bestaan uit 3 hoofdletters")]
        [StringLength(3)]
        public string? Code3 { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Maximumlengte voor {0} is {1} tekens")]
        public string Name { get; set; }

        [DataType(DataType.Url)]
        [StringLength(250, ErrorMessage = "Maximumlengte voor {0} is {1} tekens")]
        public string? FlagUrl { get; set; }

        #endregion

        #region Relation properties

        public ICollection<Circuit> Circuits { get; set; }

        public ICollection<Team> Teams { get; set; }

        public ICollection<Driver> Drivers { get; set; }

        public ICollection<Grandprix> Grandprixes { get; set; }

        #endregion

    }
}