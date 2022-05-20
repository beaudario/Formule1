using System.ComponentModel.DataAnnotations;
using Formule1Library.Data;

namespace Formule1Library;

public class Result
{
    #region Properties

    [Key] public int ID { get; set; }

    [Display(Name = "Seizoen")] [Required] public int Season { get; set; }

    [Display(Name = "Racenummer")]
    [Required]
    public int Racenumber { get; set; }

    [Display(Name = "Datum")]
    [Required]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }

    [Display(Name = "Rondes")] public int Rounds { get; set; }

    [Display(Name = "Tijd")] public string Time { get; set; }

    #endregion

    #region Relation properties

    [Display(Name = "Coureur")] public int? DriverID { get; set; }
    public Driver? Driver { get; set; }

    [Display(Name = "Circuit")] public int? CircuitID { get; set; }
    public Circuit? Circuit { get; set; }

    [Display(Name = "Constructeursteam")] public int? TeamID { get; set; }
    public Team? Team { get; set; }

    [Display(Name = "Grandprix")] public int? GrandprixID { get; set; }
    public Grandprix? Grandprix { get; set; }

    #endregion
}