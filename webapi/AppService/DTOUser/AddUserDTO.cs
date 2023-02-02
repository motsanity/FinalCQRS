using System.ComponentModel.DataAnnotations;

namespace webapi.AppService.DTOUser
{
    public class AddUserDTO
    {
        [Required]
        public string? Username { get; set; }
    }
}
