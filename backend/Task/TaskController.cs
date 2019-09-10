using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace backend.task
{
    [Route("api/[controller]")]
    [ApiController]
    class TaskController: ControllerBase
    {
        private readonly TaskService _service;
        public TaskController(TaskService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Task>> getTaskList()
        {
            return _service.getTaskList();
        }
        [HttpGet("{id: length(24)}", Name = "findTask")]
        public ActionResult<Task> findTask(string id)
        {
            var task = _service.findTask(id);
            if (task == null)
            {
                return NotFound();
            }
            else
            {
                return task;
            }
        }

        [HttpPost]
        public ActionResult<Task> createTask(Task task)
        {
            _service.createTask(task);
            return CreatedAtRoute("findTask", new { _id = task._id.ToString() }, task);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult updateTask(string id, Task updatedTask)
        {
            var task = _service.findTask(id);

            if (task == null)
            {
                return NotFound();
            }

            _service.updateTask(id, updatedTask);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult deleteTask(string id)
        {
            var task = _service.findTask(id);

            if (task == null)
            {
                return NotFound();
            }

            _service.deleteTask(task._id);

            return NoContent();
        }
    }
}