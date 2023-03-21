using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Models.Interfaces
{
    public interface ITechnologyRepository
    {
        IEnumerable<Technology> GetTechnologies();
        int AddTechnology(Technology technology);
        bool UpdateTechnology(Technology technology);
        bool DeleteTechnology(Technology technology);
        IEnumerable<Technology> GetTechnologiesPaginated(int pageNumber, int pageSize);
        Technology GetTechnologyById(int id);
        Technology GetTechnologyByName(string name);
    }
}
