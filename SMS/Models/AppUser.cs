using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class AppUser:IdentityUser
    {
        [StringLength(100)]
        [MaxLength(100)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(100)]
        [MaxLength(100)]
        [Required]
        public string LastName { get; set; }
        //[Required]
        //public string Address { get; set; }
    }
}
