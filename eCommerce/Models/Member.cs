using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    /// <summary>
    /// Repersents an indevidual website user
    /// </summary>
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        /// <summary>
        /// The first and last name of the member.
        /// ex.
        /// </summary>
        [StringLength(60)]
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        /// <summary>
        /// The givien email of user
        /// </summary>
        [Required]
        [StringLength(100)]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Not valid email type")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// User user name
        /// </summary>
        [Required]
        [StringLength(20)]
        [RegularExpression(@"^[\d\w]+$", ErrorMessage = "User name can only contain A-Z, 0-9, underscores")]
        public string Username { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        //[Range(typeof(DateTime), 
        //    DateTime.Today.AddYears(-120).ToShortDateString(),
        //    DateTime.Today.ToShortDateString())]
        // [Required] - Its already reqired
        // DateTime is structure (it's a value type)
        public DateTime DateOfBirth { get; set; }
    }
}
