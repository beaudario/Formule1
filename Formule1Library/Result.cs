using System.ComponentModel.DataAnnotations;

namespace Formule1Library.Data;

public class Result
{
    [Key]
    public int ID { get; set; }

    [Required]
    public int Season { get; set; }

    [Required]
    public int Racenumber { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }

    public int Rounds { get; set; }

    public string Time { get; set; }

    public int? DriverID { get; set; }
    public Driver Driver { get; set; }

    public int? CircuitID { get; set; }
    public Circuit Circuit { get; set; }

    public int? TeamID { get; set; }
    public Team Team { get; set; }

    public int? GrandprixID { get; set; }
    public Grandprix Grandprix { get; set; }
}