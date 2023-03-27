using OnlineTest.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Models.Repository
{
    public class AnswerSheetRepository : IAnswerSheetRepository
    {
        #region Fields
        private readonly OnlineTestContext _context;
        #endregion

        #region Constructor
        public AnswerSheetRepository (OnlineTestContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public IEnumerable<AnswerSheet> GetAnswerSheet()
        {
            return _context.AnswerSheets.ToList();
        }
        public IEnumerable<Answer> GetAnswerSheetById(int Id,int AnswerId, string Answer)
        {
            var result = (from A in _context.Answers
                          join AS1 in _context.AnswerSheets
                          on A.Id equals AS1.Id
                          where AS1.Id == Id && A.Id == AnswerId && A.Ans == Answer
                          select new Answer
                          {
                              Id = AS1.Id
                          }).FirstOrDefault();
            yield return result;
        }
        public bool UpdateAnswerSheet(AnswerSheet AnswerSheets)
        {
            _context.Entry(AnswerSheets).Property("Answersheets").IsModified = true;
            return _context.SaveChanges() > 0;
        }
        public bool DeleteAnswerSheet(int id)
        {
            _context.Entry(id).Property("Id").IsModified = true;
            return _context.SaveChanges() > 0;
        }

        public bool AddAnswerSheet(List<AnswerSheet> answerSheet)
        {
            _context.AddRange(answerSheet);
            return _context.SaveChanges() > 0;
        }

        #endregion
    }
}
