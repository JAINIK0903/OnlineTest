using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.UpdateDTO;

namespace OnlineTest.Services.Interface
{
    public interface IUserService
    {
        ResponseDTO GetUserDTO();
        ResponseDTO AddUserDTO(AddUserDTO user);
        ResponseDTO UpdateUserDTO(UpdateUserDTO user);
        ResponseDTO DeleteUser(int id);
        ResponseDTO GetUserById(int id);
        ResponseDTO GetUserByEmail(string Email);
        ResponseDTO GetUsersPaginated(int pageNumber, int pageSize);
        GetUserDTO IsUserExists(LoginDTO user);

    }
}
