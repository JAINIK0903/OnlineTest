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
    public class TechnologyController : ControllerBase
    {
        #region Fields
        private readonly ITechnologyService _technologyService;
        #endregion

        #region Constructor
        public TechnologyController(ITechnologyService technologyService)
        {
            _technologyService = technologyService;
        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult GetTechnologies()
        {
            return Ok(_technologyService.GetTechnologiesDTO());
        }

        [HttpGet("paginated")]
        public IActionResult GetTechnologiesPaginated(int page, int limit)
        {
            return Ok(_technologyService.GetTechnologiesPaginated(page, limit));
        }

        [HttpGet("id")]
        public IActionResult GetTechnologyById(int id)
        {
            return Ok(_technologyService.GetTechnologyById(id));
        }

        [HttpPost]
        public IActionResult AddTechnology(AddTechnologyDTO technology)
        {
            return Ok(_technologyService.AddTechnologyDTO(technology));
        }

        [HttpPut]
        public IActionResult UpdateTechnology(UpdateTechnologyDTO technology)
        {
            return Ok(_technologyService.UpdateTechnologyDTO(technology));
        }

        [HttpDelete]
        public IActionResult DeleteTechnology(int id)
        {
            return Ok(_technologyService.DeleteTechnology(id));
        }
        #endregion
    }
}