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
        ResponseDTO GetTechnologyByName(string technologyName);
        ResponseDTO GetTechnologiesPaginated(int pageNumber, int pageSize);
        ResponseDTO GetTechnologyById(int id);
        ResponseDTO GetTechnologies();
        ResponseDTO AddTechnology(int Id,AddTechnologyDTO technology);
        ResponseDTO UpdateTechnology(int Id,UpdateTechnologyDTO technology);
        ResponseDTO DeleteTechnology(int id);
    }
}
