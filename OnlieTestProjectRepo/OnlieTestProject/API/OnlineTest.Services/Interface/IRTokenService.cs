using OnlineTest.Models;
using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.GetDTO;
using OnlineTest.Services.DTO.UpdateDTO;

namespace OnlineTest.Services.Interface
{
    public interface IRTokenService
    {
        bool AddRefreshToken(AddRTokenDTO token);
        bool ExpireRefreshToken(UpdateRTokenDTO token);
        GetRTokenDTO GetRefreshToken(RefreshDTO user);
    }
}
