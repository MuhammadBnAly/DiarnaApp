using System.ComponentModel.DataAnnotations;
namespace Diarna.DTOs.SystemUserRegister
{
    public class CreateSystemUser2Dto
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //public bool? SuperAdmin { get; set; }
        //public int Id { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }
    }
}
