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
    public class AddQuestionDTO
    {
        [Required(ErrorMessage = "Index name is required")]
        [StringLength(20)]
        public string QuestionName { get; set; }
        [Required(ErrorMessage = "Question is required")]
        [StringLength(100)]
        public string Que { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public int TestId { get; set; }
        [Required(ErrorMessage = "Question type is required")]
        public int Type { get; set; }
        [Required(ErrorMessage = "Weightage is required")]
        public int Weightage { get; set; }
        [Required(ErrorMessage = "Order is required")]
        public int SortOrder { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }= DateTime.Now;
        public int CreatedBy { get; set;}
        public bool IsActive { get; set;}
        //public Test TId { get; set; }
    }
}
