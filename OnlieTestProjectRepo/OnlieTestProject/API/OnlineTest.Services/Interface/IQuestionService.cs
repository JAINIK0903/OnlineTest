using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.Add_DTO;
using OnlineTest.Services.DTO.UpdateDTO;

namespace OnlineTest.Services.Interface
{

    public interface IQuestionService
    {
        ResponseDTO GetQuestionsByTestId(int testId);
        ResponseDTO GetQuestionById(int id);
        ResponseDTO AddQuestionDTO(AddQuestionDTO question);
        ResponseDTO UpdateQuestionDTO(UpdateQuestionDTO question);
        ResponseDTO DeleteQuestion(int id);
    }
    
}
