using System.ComponentModel.DataAnnotations;
namespace Diarna.DTOs.SystemUserRegister
{
    public class ReadSystemUser2Dto
    {
        public int Id { get; set; }
        [Display(Name ="User Name")]
        public string UserName { get; set; }

        //public string Password { get; set; }
        //public bool? SuperAdmin { get; set; }
        public string Mobile { get; set; }
    }
}
