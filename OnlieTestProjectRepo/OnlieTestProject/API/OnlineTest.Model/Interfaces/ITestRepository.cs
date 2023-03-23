using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Models.Interfaces
{
    public interface ITestRepository
    {
        IEnumerable<Test> GetTests();
        Test GetTestById(int id);
        IEnumerable<Test> GetTestsPaginated(int pageNumber, int pageSize);
        IEnumerable<Test> GetTestsByTechnologyId(int technologyId);
        Test TestExists(Test test);
        int AddTest(Test test);
        bool UpdateTest(Test test);
        bool DeleteTest(Test test);
    }
}
