using System.ComponentModel.DataAnnotations;

namespace IBUIDING.Models
{
    public class Project
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CodeProject { get; set; }

        [Required]
        [StringLength(100)]
        public string NameProject { get; set; }

        [Required]
        [StringLength(50)]
        public string PeopleContact { get; set; }

        [Required]
        [StringLength(20)]
        public string? PhoneContact { get; set; }

        [StringLength(200)]
        public string AddressProject { get; set; }

        public string? Description { get; set; }
    }
}
