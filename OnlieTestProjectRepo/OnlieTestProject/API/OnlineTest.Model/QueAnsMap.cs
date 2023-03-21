using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Models
{
    public class QueAnsMap
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("test")]
        public int TestId { get; set; }
        [Required]
        [ForeignKey("question")]
        public int QuestionId { get; set; }
        [Required]
        [ForeignKey("answer")]
        public int AnswerId { get; set;}
        public int CreatedBy { get; set; }
        [Column(TypeName ="datetime")]
        public DateTime CreatedTime { get; set;}
        public bool IsActive { get; set;}
        public Test test { get; set; }
        public Question question { get; set; }
        public Answer answer { get; set; }
    }
}
