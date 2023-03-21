using OnlineTest.Models;
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
    public interface ITechnologyService
    {
        ResponseDTO GetTechnologiesPaginated(int pageNumber, int pageSize);
        ResponseDTO GetTechnologyById(int id);
        ResponseDTO GetTechnologiesDTO();
        ResponseDTO AddTechnologyDTO(AddTechnologyDTO technology);
        ResponseDTO UpdateTechnologyDTO(UpdateTechnologyDTO technology);
        ResponseDTO DeleteTechnology(int id);
    }
}
