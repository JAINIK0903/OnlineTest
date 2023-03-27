using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Models.Interfaces
{
    public interface IAnswerSheetRepository
    {
        IEnumerable<AnswerSheet> GetAnswerSheet();
        IEnumerable<Answer> GetAnswerSheetById(int Id,int AnswerId, string Answer);
        bool AddAnswerSheet(List<AnswerSheet> answerSheets);
        bool UpdateAnswerSheet(AnswerSheet AnswerSheets);
        bool DeleteAnswerSheet(int id);

    }
}
