using AutoMapper;
using OnlineTest.Models;
using OnlineTest.Services.DTO.GetDTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.Add_DTO;
using OnlineTest.Services.DTO.Get_DTO;

namespace OnlineTest.Services.AutoMapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region User
            CreateMap<User, GetUserDTO>();
            CreateMap<AddUserDTO, User>();
            CreateMap<UpdateUserDTO, User>();
            #endregion

            #region Token
            CreateMap<RToken, GetRTokenDTO>();
            CreateMap<AddRTokenDTO, RToken>();
            CreateMap<UpdateRTokenDTO, RToken>();
            #endregion

            #region Technology
            CreateMap<Technology, GetTechnologiesDTO>();
            CreateMap<AddTechnologyDTO, Technology>();
            CreateMap<UpdateTechnologyDTO, Technology>();
            #endregion

            #region Test
            CreateMap<Test, GetTestsDTO>();
            CreateMap<AddTestDTO, Test>();
            CreateMap<UpdateTestDTO, Test>();
            #endregion

            #region Question
            CreateMap<Question, GetQuestionsDTO>();
            CreateMap<AddQuestionDTO, Question>();
            CreateMap<UpdateQuestionDTO, Question>();
            #endregion

            #region Answer
            CreateMap<Answer, GetAnswerDTO>();
            CreateMap<AddAnswerDTO, Answer>();
            CreateMap<UpdateAnswerDTO, Answer>();
            #endregion
        }
    }
}