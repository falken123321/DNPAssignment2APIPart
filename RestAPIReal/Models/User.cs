using System.ComponentModel.DataAnnotations;

namespace LoginExample.Models
{
    public class User
    {
        [Key] 
        public int id { get; set; }
        
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Domain { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int BirthYear { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public int SecurityLevel { get; set; }
        [Required]
        public string Password { get; set; }
    }
}