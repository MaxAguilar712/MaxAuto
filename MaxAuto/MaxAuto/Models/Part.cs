using System.ComponentModel.DataAnnotations;

namespace MaxAuto.Models
{
    public class Part
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public int Price { get; set; }


    }
}
