using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using todoApp.Models;
using todoApp.Repository;

namespace todoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        DBConnect conn = new DBConnect();
        [HttpGet("{order}")]
        public IActionResult getTasks( string order)
        {
            if (order.Trim().Equals(""))
            {
                order = "desc";
            }
            List<Models.Task> list = conn.getTasks(order);
            return StatusCode(200, list);
        }
        [HttpGet]
        public IActionResult getTasks()
        {
            List<Models.Task> list = conn.getTasks("");
            return StatusCode(200, list);
        }
        [HttpPost]
        public IActionResult insertTask(Models.Task task)
        {
            int result = conn.insertTask( task);
            return StatusCode(200, result);
        }
        [HttpPut]
        public IActionResult updateTask(Models.Task task)
        {
            int result = conn.updateTask(task);
            return StatusCode(200, result);
        }
        [HttpDelete("{taskId}")]
        public IActionResult deleteTask(Guid taskId)
        {
            int result = conn.deleteTask(taskId);
            return StatusCode(200, result);
        }
    }
}
