using System.ComponentModel.DataAnnotations;

namespace BiroulSindicalFCIM.Shared
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        public string MobileNo { get; set; }

        [Required]
        [Display(Name = "Last Camin")]
        public string LastCamin { get; set; }

        [Required]
        [Display(Name = "Last Room")]
        public string LastRoom { get; set; }

        [Required]
        [Display(Name = "Future Camin")]
        public string FutureCamin { get; set; }

        [Required]
        [Display(Name = "Future Room")]
        public string FutureRoom { get; set; }

        [Required]
        [Display(Name = "IDNP")]
        public string IDNP { get; set; }

        [Required]
        [Display(Name = "Comment")]
        public string Comment { get; set; }

    }
}