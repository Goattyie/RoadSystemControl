using System.ComponentModel.DataAnnotations;

namespace RoadSystemControl.Domains.Dtos.Create;

public class AuthDto
{
    [Required]
    [MinLength(3)]
    [MaxLength(20)]
    public string Login { get; set; }
    [Required]
    [MinLength(3)]
    [MaxLength(20)]
    public string Password { get; set; } 
}