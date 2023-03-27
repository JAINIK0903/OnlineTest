using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.AddDTO
{
    public class AddAnswerSheetDTO
    {
        public Guid Token { get; set; }
        public List<Question> Questions { get; set; }
        public class Question
        {
            public int QuestionId { get; set; }
            public int AnswerId { get; set; }
        }
        public DateTime CreatedOn { get; set; }
    }
}
