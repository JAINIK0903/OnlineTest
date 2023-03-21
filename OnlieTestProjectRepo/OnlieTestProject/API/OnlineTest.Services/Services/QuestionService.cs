using AutoMapper;
using OnlineTest.Models;
using OnlineTest.Models.Interfaces;
using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.Add_DTO;
using OnlineTest.Services.DTO.Get_DTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.Interface;

namespace OnlineTest.Services.Services
{
    public class QuestionService : IQuestionService
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;
        private readonly ITestRepository _testRepository;
        #endregion

        #region Constructor
        public QuestionService(IMapper mapper, IQuestionRepository questionRepository, ITestRepository testRepository)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
            _testRepository = testRepository;
        }
        #endregion

        #region Methods
        public ResponseDTO GetQuestionsByTestId(int testId)
        {
            var response = new ResponseDTO();
            try
            {
                var testById = _testRepository.GetTestById(testId);
                if (testById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Test not found";
                    return response;
                }
                var data = _mapper.Map<List<GetQuestionsDTO>>(_questionRepository.GetQuestionsByTestId(testId).ToList());
                response.Status = 200;
                response.Message = "Ok";
                response.Data = data;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO GetQuestionById(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var test = _questionRepository.GetQuestionsById(id);
                if (test == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Question not found";
                    return response;
                }
                var data = _mapper.Map<GetQuestionsDTO>(test);
                response.Status = 200;
                response.Message = "Ok";
                response.Data = data;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }
        public ResponseDTO DeleteQuestion(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var questionById = _questionRepository.GetQuestionsById(id);
                if (questionById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Question not found";
                    return response;
                }
                questionById.IsActive = false;
                var deleteFlag = _questionRepository.DeleteQuestion(_mapper.Map<Question>(questionById));
                if (deleteFlag)
                {
                    response.Status = 204;
                    response.Message = "Deleted";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Deleted";
                    response.Error = "Could not delete question";
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

        public ResponseDTO AddQuestionDTO(AddQuestionDTO question)
        {

            var response = new ResponseDTO();
            try
            {
                var testById = _testRepository.GetTestById(question.TestId);
                if (testById == null)
                {
                    response.Status = 400;
                    response.Message = "Bad Request";
                    response.Error = "Test does not exist";
                    return response;
                }
                question.IsActive = true;
                question.CreatedOn = DateTime.UtcNow;
                var questionId = _questionRepository.AddQuestion(_mapper.Map<Question>(question));
                if (questionId == 0)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Could not add question";
                    return response;
                }
                response.Status = 201;
                response.Message = "Created";
                response.Data = questionId;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO UpdateQuestionDTO(UpdateQuestionDTO question)
        {
            var response = new ResponseDTO();
            try
            {
                var questionById = _questionRepository.GetQuestionsById(question.Id);
                if (questionById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Question not found";
                    return response;
                }
                var updateFlag = _questionRepository.UpdateQuestion(_mapper.Map<Question>(question));
                if (updateFlag != null)
                {
                    response.Status = 204;
                    response.Message = "Updated";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Could not update question";
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

        #endregion
    }
}