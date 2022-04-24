using RoadSystemControl.Domains.Enums;

namespace RoadSystemControl.Domains.Dtos.Get;

public class UserDto : IGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }
    public UserRole Role { get; set; }
}