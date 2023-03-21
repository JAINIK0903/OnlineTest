using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.UpdateDTO
{
    public class UpdateQuestionDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string QuestionName { get; set; }
        [Required]
        [StringLength(100)]
        public string Que { get; set; }
        [ForeignKey("TId")]
        public int TestId { get; set; }
        public int Type { get; set; }
        public int Weightage { get; set; }
        public int SortOrder { get; set; }
        [Column(TypeName = "datetime")] 
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public Test TId { get; set; }
    }
}
