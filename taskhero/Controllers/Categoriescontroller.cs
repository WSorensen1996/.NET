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
    [Route("api/categories")]
    [ApiController]
    public class CategoriesAPIController : ControllerBase
    {

        // db read by dependency injection 
        private readonly categoriesDbContext _db;
        public CategoriesAPIController(categoriesDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<tasksDTO>> Getcategories()
        {
            return Ok(_db.category.ToList());
        }

        [HttpGet("{id:int}", Name = "categories")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<tasksDTO> Getcategories(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var categories = _db.category.FirstOrDefault(u => u.Id == id);

            if (categories == null)
            {
                return NotFound();
            }

            return Ok(categories);
        }

        
    }
}
