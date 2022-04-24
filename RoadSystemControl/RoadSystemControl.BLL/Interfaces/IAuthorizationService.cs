using RoadSystemControl.Domains.Dtos.Create;
using RoadSystemControl.Domains.Dtos.Get;

namespace RoadSystemControl.BLL.Interfaces;

public interface IAuthorizationService
{
    public Task<AuthGetDto> SignIn(AuthDto dto);
}