
using System.ComponentModel.DataAnnotations;

namespace FCIM.Shared
{
    public class Message
    {
        public int Id
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "Mesaj")]
        public string Mesaj
        {
            get;
            set;
        }
    }
}
