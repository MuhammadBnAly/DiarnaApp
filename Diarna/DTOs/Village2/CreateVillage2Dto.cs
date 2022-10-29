using System.ComponentModel.DataAnnotations;
namespace Diarna.DTOs.Village2
{
    public class CreateVillage2Dto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
