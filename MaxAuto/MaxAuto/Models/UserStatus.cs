using System.ComponentModel.DataAnnotations;

namespace MaxAuto.Models
{
    public class UserStatus
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public static int ACTIVE_ID => 1;
        public static int DEACTIVATED_ID => 2;
    }
}