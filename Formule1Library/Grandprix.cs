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
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        public string? Description { get; set; }

        public string? CountryID { get; set; }
        public Country Country { get; set; }

        public ICollection<Circuit> Circuits { get; set; }

        public ICollection<Results> Results { get; set; }
        
        /*public int ID { get; set; }
        
        [StringLength(50, ErrorMessage = "Maximumlengte voor {0} is {1} tekens")]
        public string Name { get; set; } = string.Empty;
        
        public string? Description { get; set; } = string.Empty;
        
        [DataType(DataType.Url)]
        [StringLength(250, ErrorMessage = "Maximumlengte voor {0} is {1} tekens")]
        public string? Wiki { get; set; } = string.Empty;
        
        public Country? Country { get; set; }
        
        public IEnumerable<Result> Results { get; set; } = Enumerable.Empty<Result>();*/
    }
}
