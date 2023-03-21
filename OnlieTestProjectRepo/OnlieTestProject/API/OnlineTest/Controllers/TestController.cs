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
    public class TestController : ControllerBase
    {
        #region Fields
        private readonly ITestService _testService;
        #endregion

        #region Constructor
        public TestController(ITestService testService)
        {
            _testService = testService;
        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult GetTestsByTechnologyId(int id)
        {
            return Ok(_testService.GetTestsByTechnologyId(id));
        }

        [HttpGet("paginated")]
        public IActionResult GetTestsPaginated(int page, int limit)
        {
            return Ok(_testService.GetTestsPaginated(page, limit));
        }

        [HttpGet("id")]
        public IActionResult GetTestById(int id)
        {
            return Ok(_testService.GetTestsById(id));
        }

        [HttpPost]
        public IActionResult AddTest(AddTestDTO test)
        {
            return Ok(_testService.AddTestDTO(test));
        }

        [HttpPut]
        public IActionResult UpdateTest(UpdateTestDTO test)
        {
            return Ok(_testService.UpdateTestDTO(test));
        }

        [HttpDelete]
        public IActionResult DeleteTest(int id)
        {
            return Ok(_testService.DeleteTest(id));
        }
        #endregion
    }
}