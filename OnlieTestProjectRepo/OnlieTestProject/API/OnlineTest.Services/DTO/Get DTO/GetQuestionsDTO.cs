using OnlineTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.Get_DTO
{
    public class GetQuestionsDTO
    {

        public string QuestionName { get; set; }
        public string Que { get; set; }
        public int TestId { get; set; }
        public string Type { get; set; }
        public int weightage { get; set; }
        public int SortOrder { get; set; }
        public int CreatedBy { get; set; }

    }
}
