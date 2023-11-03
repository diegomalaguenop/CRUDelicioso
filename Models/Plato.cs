#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CRUDelicioso.Models;

public class Plato {
    [Key]
    [Required(ErrorMessage = "Por favor proporciona este dato")]
    public int Id {get; set;}

    [Required(ErrorMessage = "Por favor proporciona este dato")]
    public string Name {get; set;}

    [Required(ErrorMessage = "Por favor proporciona este dato")]
    public string Chef {get; set;}

    [Required(ErrorMessage = "Por favor proporciona este dato")]
    public int Tastiness {get; set;}

    [Required(ErrorMessage = "Por favor proporciona este dato")]
    public int Calories {get; set;}

    [Required(ErrorMessage = "Por favor proporciona este dato")]
    public string Description {get; set;}

    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;

}