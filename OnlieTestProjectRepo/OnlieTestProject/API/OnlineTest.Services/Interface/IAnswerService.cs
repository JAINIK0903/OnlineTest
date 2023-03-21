using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.Add_DTO;
using OnlineTest.Services.DTO.UpdateDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.Interface
{
    public interface IAnswerService
    {
        ResponseDTO GetAnswersDTO();
        ResponseDTO AddAnswersDTO(AddAnswerDTO answer);
        ResponseDTO UpdateAnswersDTO(UpdateAnswerDTO answer);
        ResponseDTO DeleteAnswer(int id);
        ResponseDTO GetAnswersById(int id);
    }
}
