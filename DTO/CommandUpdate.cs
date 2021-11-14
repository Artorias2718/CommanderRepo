using System.ComponentModel.DataAnnotations;

namespace Commander.DTO
{
    public class CommandUpdate
    {
        // This is not needed because it's auto generated when a new Command is inserted into the db table 
        //public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}