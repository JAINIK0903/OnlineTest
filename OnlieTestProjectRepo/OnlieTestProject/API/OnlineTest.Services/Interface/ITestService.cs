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
    public interface ITestService
    {
        ResponseDTO GetTestsDTO();
        ResponseDTO GetTestsPaginated(int pageNumber, int pageSize);
        ResponseDTO GetTestsByTechnologyId(int technologyId);
        ResponseDTO GetTestsById(int id);
        ResponseDTO AddTestDTO(AddTestDTO test);
        ResponseDTO AddTestLink(int adminId, int testId, string email);
        ResponseDTO UpdateTestDTO(UpdateTestDTO test);
        ResponseDTO DeleteTest(int id);
    }
}
