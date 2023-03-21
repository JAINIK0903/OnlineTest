using OnlineTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.Add_DTO
{
    public class AddQueAnsDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Test")]
        public int TestId { get; set; }
        [Required]
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        [Required]
        [ForeignKey("Answer")]
        public int AnswerId { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public int CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }= DateTime.Now;
        public bool IsActive { get; set; }
        public Test Test { get; set; }
        public Answer Answer { get; set; }
        public Question Question { get; set; }
        public User UserId { get; set; }
    }
}
