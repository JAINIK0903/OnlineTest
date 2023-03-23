using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Models.Interfaces
{
    public interface IQuestionRepository
    {
        
        IEnumerable<Question> GetQuestionsByTestId(int id);
        int AddQuestion(Question question);
        int UpdateQuestion(Question question);
        bool DeleteQuestion(Question question);
        Question GetQuestionsById(int id);
        Question QuestionExists(Question question);
    }
}
