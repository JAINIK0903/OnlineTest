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
    public class AnswerController : ControllerBase
    {
        #region Fields
        private readonly IAnswerService _answerService;
        #endregion

        #region Constructor
        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult GetAnswers()
        {
            return Ok(_answerService.GetAnswersDTO());
        }

        [HttpPost]
        public IActionResult AddAnswer(AddAnswerDTO answer)
        {
            return Ok(_answerService.AddAnswersDTO(answer));
        }

        [HttpPut]
        public IActionResult UpdateAnswer(UpdateAnswerDTO answer)
        {
            return Ok(_answerService.UpdateAnswersDTO(answer));
        }
        #endregion
    }
}