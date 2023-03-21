using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTest.Services.DTO.Add_DTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.Interface;

namespace OnlineTest.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        #region Fields
        private readonly IQuestionService _questionService;
        #endregion

        #region Constructor
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult GetQuestionsByTestId(int id)
        {
            return Ok(_questionService.GetQuestionsByTestId(id));
        }

        [HttpGet("id")]
        public IActionResult GetQuestionById(int id)
        {
            return Ok(_questionService.GetQuestionById(id));
        }

        [HttpPost]
        public IActionResult AddQuestion(AddQuestionDTO question)
        {
            return Ok(_questionService.AddQuestionDTO(question));
        }

        [HttpPut]
        public IActionResult UpdateQuestion(UpdateQuestionDTO question)
        {
            return Ok(_questionService.UpdateQuestionDTO(question));
        }

        [HttpDelete]
        public IActionResult DeleteQuestion(int id)
        {
            return Ok(_questionService.DeleteQuestion(id));
        }
        #endregion
    }
}