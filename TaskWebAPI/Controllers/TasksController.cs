using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskWebAPI.Models;
using TaskWebAPI.Repository;
using TaskWebAPI.Validations;
using Task = TaskWebAPI.Models.Task;

namespace TaskWebAPI.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class TasksController : Controller
    {   
        private readonly IDataRepository _repository;

        public TasksController(IDataRepository dataRepository) 
        {
           _repository = dataRepository;
        }

        // GET: Retrieve all tasks
        [HttpGet("all")]
        [Authorize]
        public ActionResult GetAllTasks()
        {
            try
            {
                List<Task> listOfTasks = _repository.FindAllTasks();

                if (listOfTasks is null)
                {
                    return NoContent();
                }
                return Ok(new ApiResponse<object>(true, "Retrieved all tasks", listOfTasks));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(false, "Error occurred", ex.Message));
            }
            
        }

        // GET: Retrieve Task By Id
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult GetTaskById(int id)
        {
            try
            {
                Task task = _repository.FindTaskById(id);
                
                if (task is null)
                {
                    return NotFound(new ApiResponse<string>(true, $"Task with ID {id} not found.",null ));
                }
            
                return Ok(new ApiResponse<object>(true, $"Task with ID {id} found.", task));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(false, "An error occurred", ex.Message));
            }
        }

        // POST:Create New Task
        [HttpPost("create")]
        [Authorize]
        public ActionResult CreateTask([FromBody]Task task)
        {
            try
            {
                TaskValidator validator = new TaskValidator();

                var result = validator.Validate(task);
                
                if (!result.IsValid)
                {
                    string errorMessages = string.Join(" | ", result.Errors.Select(e => e.ErrorMessage));
                    return BadRequest(new ApiResponse<Task>(false, errorMessages, null));
                }
                _repository.AddTask(task);
                return Ok(new ApiResponse<Task>(true, "Created Task", task));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(false, "An error occurred", ex.Message));
            }
        }

        // PUT: Edit Task with specific Id
        [HttpPut("edit/{id}")]
        [Authorize]
        public ActionResult EditTask(int id, Task task)
        {
            try
            {
                TaskValidator validator = new TaskValidator();

                var result = validator.Validate(task);

                if (!result.IsValid)
                {
                    string errorMessages = string.Join(" | ", result.Errors.Select(e => e.ErrorMessage));
                   
                    return BadRequest(new ApiResponse<Task>(false, errorMessages, null));
                }

                bool updateStatus=_repository.UpdateTask(id,task);

                if (!updateStatus)
                {
                    return NotFound(new ApiResponse<string>(true, $"Task with ID {id} not found.", null));
                }


                return Ok(new ApiResponse<Task>(true, "Edited Task", task));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(false, "An error occurred", ex.Message));
            }
        }

        // DEL: Delete Task with Id
        [HttpDelete("delete/{id}")]
        [Authorize]
        public ActionResult DeleteTask(int id)
        {
            try
            {
                bool deleteStatus = _repository.DeleteTaskById(id);

                if (!deleteStatus) 
                {
                    return NotFound(new ApiResponse<string>(true, $"Task with ID {id} not found.", null));

                }

                return Ok(new ApiResponse<string>(true, $"Deleted Task with Id: {id}", null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(false, "An error occurred", ex.Message));
            }
        }

        // PATCH: Edit Status to Complete
        [HttpPatch("edit-status/{id}")]
        [Authorize]
        public ActionResult EditStatus(int id)
        {
            try
            {
                bool editStatus = _repository.UpdateStatus(id);

                if (!editStatus)
                {
                    return NotFound(new ApiResponse<string>(true, $"Task with ID {id} not found.", null));
                }

                    return Ok(new ApiResponse<string>(true, "Updated Status", null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(false, "An error occurred", ex.Message));
            }
        }
    }
}
