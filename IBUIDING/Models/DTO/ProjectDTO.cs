using System.ComponentModel.DataAnnotations;

namespace IBUIDING.Models.DTO
{
    public class ProjectDTO
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mã khu đô thị")]
        [MaxLength(16, ErrorMessage = "Mã dự án không được vượt quá 16 ký tự.")]
        public string CodeProject { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên khu đô thị")]
        [MaxLength(100, ErrorMessage = "Tên dự án không được vượt quá 100 ký tự.")]
        public string NameProject { get; set; }

        [MaxLength(100, ErrorMessage = "Tên người liên hệ không được vượt quá 100 ký tự.")]
        public string PeopleContact { get; set; }

        [MaxLength(15, ErrorMessage = "Điện thoại liên hệ không được vượt quá 15 ký tự.")]
        public string? PhoneContact { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ khu đô thị")]
        [MaxLength(200, ErrorMessage = "Địa chỉ dự án không được vượt quá 200 ký tự.")]
        public string AddressProject { get; set; }

        [MaxLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự.")]
        public string? Description { get; set; }
    }
}
