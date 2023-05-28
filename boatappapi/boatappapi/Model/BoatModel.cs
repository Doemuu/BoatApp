using boatappapi.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace boatappapi.Model
{
    public class BoatModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public ColourEnum Colour { get; set; }

    }
}
