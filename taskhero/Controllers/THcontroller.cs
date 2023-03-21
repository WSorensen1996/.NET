using Microsoft.AspNetCore.Mvc;
using taskhero.Models;
using taskhero.Models.DTOs;
using taskhero.Data;


// Setting up sql 
// Create sql server: -> sqllocaldb create "."
// NuGet -> add package -> EntityFramework.SQLServer && EntityFramework.Tools
// Settings i program.cs 
// SQL connection string i appsetting.json 


// FOrberedelse til TH: 
// TODO: 
// 1. Lave endpoints

// 2. Handle Azure SQL

//3. Handle API key 

//4. Håndtere filtering

//5. Auth håndtering 


//FeedPage -> '/api/tasks' && '/api/services' -> getOne -> getAll -> post 
//FeedPage -> '/api/categories' -> getAll

//ProfilePage -> '/api/userinformation' -> getOne


namespace taskhero.Controllers
{

    [Route("api/tasks")]
    [ApiController]
    public class taskheroAPIController : ControllerBase
    {

        // db read by dependency injection 
        private readonly tasksDbContext _db;
        public taskheroAPIController(tasksDbContext db)
        {
            _db = db;

        }

        [HttpGet]
        public ActionResult<IEnumerable<tasksDTO>> Gettask()
        {
            return Ok(_db.Task.ToList());
        }

        [HttpGet("{id:int}", Name = "task")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<tasksDTO> Gettask(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var task = _db.Task.FirstOrDefault(u => u.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPost]
        public ActionResult<tasksDTO> Createtask([FromBody] tasksDTO tasksDTO)
        {
            // // checking if the Item is unique
            if (_db.Task.FirstOrDefault(u => u.PrioritizationID == tasksDTO.PrioritizationID) != null)
            {
                ModelState.AddModelError("CustomError", "task already exists!");
                return BadRequest(ModelState);
            }

            if (tasksDTO == null)
            {
                return BadRequest(tasksDTO);
            }

            if (tasksDTO.Id != 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            tasks model = new(){
                Id = tasksDTO.Id,
                PrioritizationID = tasksDTO.PrioritizationID,
                TaskOwnerName = tasksDTO.TaskOwnerName,
                category = tasksDTO.category, 
                description = tasksDTO.description,
                imageURL = tasksDTO.imageURL,
                location = tasksDTO.location,
                ownerID = tasksDTO.ownerID,
                price = tasksDTO.price,
                subject = tasksDTO.subject,
                taskType = tasksDTO.taskType,
                timeCreated = tasksDTO.timeCreated

            };

            _db.Task.Add(model);
            _db.SaveChanges();


            // // Returns the url where the data is stored
            return CreatedAtRoute("task", new { id = tasksDTO.Id }, tasksDTO);

        }


        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id:int}", Name = "Deletetask")]
        public IActionResult Deletetask(int id)
        {
            if (id < 1)
            {
                return BadRequest();

            }

            var task = _db.Task.FirstOrDefault(u => u.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            _db.Task.Remove(task);
            _db.SaveChanges();
            return NoContent();

        }




        
    }
}
