using OnlineTest.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineTest.Models.Repository
{

    public class TestLinkRepository : ITestLinkRepository
    {
        #region Fields
        private readonly OnlineTestContext _context;
        #endregion
        #region Constructor
        public TestLinkRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion

        //public bool DeleteTestLink(TestLink testlink) 
        //{


        #region Methods
        public int AddTestLink(TestLink testlink)
        {
            _context.Add(testlink);
            _context.Entry(testlink).Property("IsActive").IsModified = true;
            //return _context.SaveChanges() > 0;
            //}
            if (_context.SaveChanges() > 0)
                return testlink.Id;
            else
                return 0;
        }
        public IEnumerable<TestLink> GetTestLinks(Guid token)
        {
            return _context.testlinks.Where(link=>link.Token==token).ToList();
        }
        public bool IsTestLinkExists(int testId, int userId)
        {
            var result = _context.testlinks.FirstOrDefault(t => t.TestId == testId && t.UserId == userId && t.ExpireOn > DateTime.UtcNow);
            if (result != null)
                return true;
            else
                return false;
        }
        //public bool UpdateTestLink(TestLink testlink)
        //{
        //    _context.Entry(testlink).Property("AccessOn").IsModified = true;
        //    _context.Entry(testlink).Property("Attempts").IsModified = true;
        //    _context.Entry(testlink).Property("SubmitOn").IsModified = true;
        //    _context.Entry(testlink).Property("AccessOn").IsModified = true;
        //    return _context.SaveChanges() > 0;
        //}
        #endregion
    }
}
