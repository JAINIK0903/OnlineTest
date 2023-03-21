using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineTest.Models;
using OnlineTest.Models.Interfaces;
using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.Interface;


namespace OnlineTest.Services.Services
{
    public class UserService : IUserService
    {
        #region Fields
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IHasherService _hasherService;
        #endregion

        #region Constructor        
        public UserService(IUserRepository userRepository, IMapper mapper, IHasherService hasherService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _hasherService = hasherService;
        }
        
        #endregion

        #region Methods        
        public ResponseDTO GetUserDTO()
        {
            var response = new ResponseDTO();
            try
            {
                var data= _mapper.Map<List<GetUserDTO>>(_userRepository.GetUsers()).ToList();
                response.Status = 200;
                response.Message = "ok";
                response.Data = data;
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = ex.Message;
            }
            return response;
        }
        public ResponseDTO GetUsersPaginated(int pageNumber, int pageSize)
        {
            var response = new ResponseDTO();
            try
            {
                
                var data = _mapper.Map<List<User>>(_userRepository.GetUsersPaginated(pageNumber,pageSize)).ToList();
                
                response.Status = 200;
                response.Message = "Ok";
                response.Data = data;
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = ex.Message;
            }
            return response;

        }
        public ResponseDTO GetUserById(int id)
        {
            var response = new ResponseDTO();
            {
                var user = _userRepository.GetUserById(id);
                if (user == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "User not found";
                    return response;
                }
                
                var data=_mapper.Map<GetUserDTO>(user);
                if (user!=null)
                {
                    response.Status = 200;
                    response.Message = "user is successfully fetched";
                    response.Data = data;
                }
               
            }
            return response;
        }
        public ResponseDTO GetUserByEmail(string email)
        {
            var response = new ResponseDTO();
            try
            {
                var user = _userRepository.GetUserByEmail(email);
                if (user == null)
                { 
                    response.Status=404;
                    response.Message = "Not Found";
                    response.Error = "User not found";
                }
                
                var data= _mapper.Map<GetUserDTO>(user);
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = "user not found using email";
                response.Error = ex.Message;
            }
            return response;
        }

        public ResponseDTO AddUserDTO(AddUserDTO user)
        {
            var response = new ResponseDTO();
            try
            {
                var userByEmail = GetUserByEmail(user.Email);
                if (userByEmail == null)
                {
                    response.Status = 400;
                    response.Message = "Bad Request";
                    response.Error = "Email already exist";
                    response.Data = userByEmail;
                    return response;
                }
                user.Password=_hasherService.Hash(user.Password);
                var result = _userRepository.AddUser(_mapper.Map<User>(user));   
                
                if(result!=null) 
                {
                    response.Status = 200;
                    response.Message = "user is successfully added";
                    response.Data = result;
                }
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO UpdateUserDTO(UpdateUserDTO user)
        {
            var response = new ResponseDTO();
            try
            {
                var result = _userRepository.UpdateUser(new Models.User
                {
                    Id = user.Id,
                    Name = user.Name,
                    MobileNo = user.MobileNo,
                    Email = user.Email,
                    Password = user.Password,
                    //IsActive = user.IsActive

                });
                var data= _mapper.Map<UserDTO>(result);
                if (result)
                {
                    response.Status = 204;
                    response.Message = "user updated";
                    response.Data = result;
                }

                return response;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "user not added";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO DeleteUser(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var userById = _userRepository.GetUserById(id);
                if (userById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "User not found";
                    return response;
                }
                userById.IsActive = false;
                var deleteFlag = _userRepository.DeleteUser(userById);
                if (deleteFlag)
                {
                    response.Status = 204;
                    response.Message = "Deleted";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Deleted";
                    response.Error = "Could not delete user";
                }
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }
        public GetUserDTO IsUserExists(LoginDTO user)
        {
            var result = _userRepository.GetUserByEmail(user.Email);
            if (result == null || result.Password != _hasherService.Hash(user.Password))
                return null;
            return _mapper.Map<GetUserDTO>(result);
        }
        #endregion
    }
}