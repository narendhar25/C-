using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Entities
{
    public class Member
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        [Url]
        public string Website { get; set; }
        [Display(Name = "Send spam to me")]
        public bool SendSpam { get; set; }
        public int? NumberOfCats { get; set; }
        public IFormFile Selfie { get; set; }
    }
}
