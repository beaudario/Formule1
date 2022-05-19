using System.ComponentModel.DataAnnotations;


namespace Formule1Library;

public class Result
{
    #region Properties

    [Key] public int ID { get; set; }

    [Display(Name = "Seizoen")] [Required] public int Season { get; set; }

    [Display(Name = "#")] [Required] public int Racenumber { get; set; }

    [Display(Name = "Rondes")]
    [Required]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }

    public int Rounds { get; set; }

    [Display(Name = "Tijd")] public string Time { get; set; }

    #endregion

    #region Relation properties

    public int? DriverID { get; set; }
    public Driver Driver { get; set; }

    public int? CircuitID { get; set; }
    public Circuit Circuit { get; set; }

    public int? TeamID { get; set; }
    public Team Team { get; set; }

    public int? GrandprixID { get; set; }
    public Grandprix Grandprix { get; set; }

    #endregion
}