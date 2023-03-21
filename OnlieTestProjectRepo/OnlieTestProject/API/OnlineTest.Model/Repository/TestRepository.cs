using OnlineTest.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Models.Repository
{
    public class TestRepository : ITestRepository
    {
        private readonly OnlineTestContext _context;
        public TestRepository(OnlineTestContext context)
        {
            _context = context;
        }

        public bool AddTest(Test test)
        {
            _context.Tests.Add(test);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateTest(Test test)
        {
            _context.Tests.Update(test);
            return _context.SaveChanges() > 0;
        }
        public bool DeleteTest(Test test)
        {
            _context.Entry(test).Property("IsActive").IsModified = true;
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<Test> GetTestsPaginated(int pageNumber, int pageSize)
        {
            return _context.Tests.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
        

        public IEnumerable<Test> GetTests()
        {
            return _context.Tests.ToList();
        }
        public IEnumerable<Test> GetTestsByTechnologyId(int technologyId)
        {
            return _context.Tests.Where(t => t.TechnologyId == technologyId && t.IsActive == true).ToList();
        }

        public Test GetTestById(int id)
        {
            return _context.Tests.FirstOrDefault(t => t.Id == id && t.IsActive == true);
        }

        
    }
}
