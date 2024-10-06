using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models;

public class Specialization
{
    [Key]
    public int SpecializationId { get; set; }

    [Required(ErrorMessage = "{0} is required!")]
    [DisplayName("Specialization name")]
    public int SpecializationName { get; set; }
}
