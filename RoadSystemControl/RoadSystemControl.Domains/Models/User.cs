using System.ComponentModel.DataAnnotations.Schema;
using RoadSystemControl.Domains.Enums;

namespace RoadSystemControl.Domains.Models;

public class User : BaseModel
{
    public string Login { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
}