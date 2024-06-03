using System.ComponentModel.DataAnnotations;

namespace AuthSysWithHashFunc.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 3)]
        public string Login { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 3)]
        public string Password { get; set; }
    }
}
