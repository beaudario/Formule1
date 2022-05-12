using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formule1Library
{
    public class Grandprix
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int Season { get; set; }

        [Required]
        public int RaceNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int Rounds { get; set; }

        [Required]
        [StringLength(50)]
        public string WinningTime { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int? DriverID { get; set; }
        public Driver Driver { get; set; }

        public int CircuitID { get; set; }
        public Circuit Circuit { get; set; }
        
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
