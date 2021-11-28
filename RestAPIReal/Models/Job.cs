using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Job
    {
        [Required] public string JobTitle { get; set; }

        [Required] public int Salary { get; set; }

        [Key] public int jobNr { get; set; }
    }
}