using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TODO.Models;
using TODO.TaskData;

namespace TODO.Controllers
{
    
    [ApiController]
    public class TasksController : ControllerBase
    {
        private ITaskInterface _taskInterface;
        public TasksController(ITaskInterface taskInterface)
        {
            _taskInterface = taskInterface;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAllTask()
        {
            return Ok(_taskInterface.GetAllTasks());
        }
        [HttpGet]
        [Route("api/[controller]/{categoryname}")]
        public IActionResult GetTasks(String categoryname)
        {
            return Ok(_taskInterface.GetTasks(categoryname, ""));
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddTask(Task task)
        {
            _taskInterface.AddTask(task);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + task.Id, task);
        }
        /*[HttpDelete]
        [Route("api/[controller/{id}]")]
        public IActionResult DeleteTask(int id)
        {
            String result=_taskInterface.DeleteTask(id);
            return Ok();
        }*/

        [HttpPatch]
        [Route("api/update[controller]/{id}")]
        public IActionResult UpdateTask(int id, Task task)
        {
            var cat = _taskInterface.GetOneTask(id,"");
            if (cat != null)
            {
                _taskInterface.UpdateTask(id,task);
                return Ok("Task Updated successfully");
            }
            else
            {
                return NotFound("No Task With that ID");
            }
        }
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult MakeFavTask(int id, Task task)
        {
            var cat = _taskInterface.GetOneTask(id, "");
            if (cat != null)
            {
                _taskInterface.MakeFavourite(id);
                return Ok("Task Favoured");
            }
            else
            {
                return NotFound("No Task With that ID");
            }
        }
    }
}
