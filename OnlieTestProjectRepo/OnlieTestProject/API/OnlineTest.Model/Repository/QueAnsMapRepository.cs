using OnlineTest.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Models.Repository
{
    public class QueAnsMapRepository : IQueAnsMapRepository
    {
        private readonly OnlineTestContext _context;
        public QueAnsMapRepository(OnlineTestContext context)
            {
                _context = context;
            }
        public int AddQueAns(QueAnsMap queAnsMap)
        {
             _context.Add(queAnsMap);
            if( _context.SaveChanges()>0)
                return queAnsMap.Id;
            else
                return 0;
        }
    }
}
