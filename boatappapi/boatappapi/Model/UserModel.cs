using System;
using System.ComponentModel.DataAnnotations;

namespace boatappapi.Model
{
    public class UserModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
