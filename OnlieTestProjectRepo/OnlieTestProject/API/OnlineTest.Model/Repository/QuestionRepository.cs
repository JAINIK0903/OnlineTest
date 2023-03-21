using OnlineTest.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Models.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly OnlineTestContext _context;
        public QuestionRepository(OnlineTestContext context)
        {
            _context = context;
        }

        public int AddQuestion(Question question)
        {
            _context.Questions.Add(question);
            return _context.SaveChanges();
        }

        public Question GetQuestionsById(int id)
        {
            return (Question)_context.Questions.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Test> GetQuestionsByTestId(int id)
        {
            return (IEnumerable<Test>)_context.Tests.FirstOrDefault(u => u.Id == id);
        }

        public int UpdateQuestion(Question test)
        {
            _context.Questions.Update(test);
            return _context.SaveChanges();
        }
        public bool DeleteQuestion(Question question)
        {
            _context.Entry(question).Property("IsActive").IsModified = true;
            return _context.SaveChanges() > 0;
        }
        IEnumerable<Question> IQuestionRepository.GetQuestionsByTestId(int id)
        {
            return _context.Questions.Where(q => q.Id == id && q.IsActive == true).ToList();
        }

        public Question GetQuestionById(int id)
        {
            return _context.Questions.FirstOrDefault(q => q.Id == id && q.IsActive == true);
        }
    }
}

