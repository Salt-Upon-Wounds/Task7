using System.ComponentModel.DataAnnotations;

namespace Task7.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
