using Microsoft.AspNetCore.Mvc;
using RepairSystem.Models;
using RepairSystem.Services;

namespace RepairSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestService _service;

        public RequestsController(IRequestService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllRequests());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var request = _service.GetRequestById(id);

            if (request == null)
                return NotFound();

            return Ok(request);
        }

        [HttpPost]
        public IActionResult Create(UserRequest request)
        {
            _service.CreateRequest(request);
            return Ok(request);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, UserRequest request)
        {
            request.Id = id;
            _service.UpdateRequest(request);

            return Ok(request);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _service.DeleteRequest(id);

            return Ok();
        }
    }
}