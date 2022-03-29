using System.ComponentModel.DataAnnotations;

namespace DemoValidation
{
  public class Contact //: ValidatorBase
  {
    [Required(ErrorMessage = " Name is required.")]
    [StringLength(50, ErrorMessage = "No more than 50 characters")]
    [Display(Name = "Name")]
    public string Name { get; set; } = "";


    [Required(ErrorMessage = " Name is required.")]
    [StringLength(5, ErrorMessage = "No more than 5 characters")]
    [Display(Name = "Name")]
    public string FirstName { get; set; } = "";

    [Range(1,100)]
    public int Age{ get; set; }
  }
}
