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
        public int ID { get; set; }
        
        [StringLength(50, ErrorMessage = "Maximumlengte voor {0} is {1} tekens")]
        public string Name { get; set; } = string.Empty;
        
        public string? Description { get; set; } = string.Empty;
        
        [DataType(DataType.Url)]
        [StringLength(250, ErrorMessage = "Maximumlengte voor {0} is {1} tekens")]
        public string? Wiki { get; set; } = string.Empty;
        
        public Country? Country { get; set; }
        
        public IEnumerable<Result> Results { get; set; } = Enumerable.Empty<Result>();
    }
}
