using OnlineTest.Models.Interfaces;

namespace OnlineTest.Models.Repository
{
    public class AnswerRepository : IAnswerRepository
    {
        #region Fields
        private readonly OnlineTestContext _context;
        #endregion

        #region Constructor
        public AnswerRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public IEnumerable<Answer> GetAnswers()
        {
            return _context.Answers.Where(a => a.IsActive == true).ToList();
        }

        public int AddAnswer(Answer answer)
        {
            _context.Add(answer);
            if (_context.SaveChanges() > 0)
                return answer.Id;
            else
                return 0;
        }

        int IAnswerRepository.UpdateAnswer(Answer answer)
        {
            _context.Entry(answer).Property("Ans").IsModified = true;
            return _context.SaveChanges();
        }

        public bool DeleteAnswer(Answer answer)
        {
            _context.Entry(answer).Property("IsActive").IsModified = true;
            return _context.SaveChanges() > 0;
        }

        public Answer GetAnswersById(int id)
        {
            return _context.Answers.FirstOrDefault(a => a.Id == id && a.IsActive == true);
        }
        public IEnumerable<Answer> GetAnswersByQuestionId(int questionId)
        {
            return (from qam in _context.QueAnsMap
                    join a in _context.Answers
                    on qam.AnswerId equals a.Id
                    where qam.QuestionId == questionId
                    select new Answer
                    {
                        Id = a.Id,
                        AName=a.AName,
                        IsActive = a.IsActive,
                        CreatedBy = a.CreatedBy,
                        CreatedTime = a.CreatedTime
                    }).ToList();
        }
        #endregion
    }
}