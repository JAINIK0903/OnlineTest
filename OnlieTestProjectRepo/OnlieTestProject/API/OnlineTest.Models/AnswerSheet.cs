using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Models
{
    public class AnswerSheet
    {
        [Key]
        public int Id { get; set; }
        public Guid Token { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        [Column(TypeName ="DateTime")]
        public DateTime CreatedTime { get; set; }
    }
}
