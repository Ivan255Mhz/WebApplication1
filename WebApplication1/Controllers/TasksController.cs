using Microsoft.AspNetCore.Mvc;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _service;

        public TasksController(TaskService service)
        {
            _service = service;
        }

        // GET: api/tasks
        [HttpGet]
        public IActionResult GetAll()
        {
            var tasks = _service.GetAll();
            return Ok(tasks);
        }

        // POST: api/tasks
        [HttpPost]
        public IActionResult Create([FromBody] CreateTaskRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
                return BadRequest("Название не может быть пустым");

            var task = _service.Create(request.Title);

            return Ok(task);
        }

        // PUT: api/tasks/5
        [HttpPut("{id}")]
        public IActionResult Toggle(int id)
        {
            var task = _service.Toggle(id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        // DELETE: api/tasks/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _service.Delete(id);

            if (!success)
                return NotFound();

            return Ok();
        }
    }

    // DTO для создания задачи
    public class CreateTaskRequest
    {
        public string Title { get; set; } = string.Empty;
    }
}
