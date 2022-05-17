using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formule1Library.Data;

namespace Formule1Library
{
    public class Grandprix
    {
        #region Properties

        [Key] public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximumlengte voor {0} is {1} tekens")]
        public string Name { get; set; }

        public string? Description { get; set; }

        [DataType(DataType.Url)]
        [StringLength(250, ErrorMessage = "Maximumlengte voor {0} is {1} tekens")]
        public string? WikiUrl { get; set; }

        #endregion

        #region Relation properties

        public string? CountryID { get; set; }
        public Country Country { get; set; }

        public ICollection<Result> Results { get; set; }

        #endregion
    }
}