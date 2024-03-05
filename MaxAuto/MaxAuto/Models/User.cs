using System.ComponentModel.DataAnnotations;

namespace MaxAuto.Models
{

        public class User
        {
            public int Id { get; set; }

            [Required]
            [MaxLength(50)]
            public string Name { get; set; }

            [Required]
            [DataType(DataType.EmailAddress)]
            [MaxLength(255)]
            public string Email { get; set; }


            [Required]
            public int UserTypeId { get; set; }
            public UserType? UserType { get; set; }
            public int Money {  get; set; }
            //public string? Password { get; set; }

        }
    }