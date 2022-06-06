using System.ComponentModel.DataAnnotations;

namespace BiroulSindicalFCIM.Shared
{
    public class EduCard
    {
        public int Id
        {
            get;
            set;
        }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName
        {
            get;
            set;
        }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName
        {
            get;
            set;
        }
        [Required]
        [Display(Name = "Email")]
        public string Email
        {
            get;
            set;
        }
        [Required]
        [Display(Name = "MobileNo")]
        public string MobileNo
        {
            get;
            set;
        }
        [Required]
        [Display(Name = "Grupa academica")]
        public string Grupa
        {
            get;
            set;
        }
    }
}
