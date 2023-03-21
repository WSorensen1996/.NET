using Microsoft.AspNetCore.Mvc;
using taskhero.Models;
using taskhero.Models.DTOs;
using taskhero.Data;
using Microsoft.AspNetCore.Authorization;
using taskhero.Model; 


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

    
    //[Authorize(Roles = UserRoles.Admin)]
    [ApiController]
    [Route("api/userinformation")]
    public class userinformationAPIController : ControllerBase
    {

        // db read by dependency injection 
        private readonly userinformationDbContext _db;
        public userinformationAPIController(userinformationDbContext db)
        {
            _db = db;

        }

        [HttpGet]
        public ActionResult<IEnumerable<userInformationDTO>> GetUserInformation()
        {
            return Ok(_db.userinformationList.ToList());
        }

        [HttpGet("{id:int}", Name = "userinformation")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<userInformationDTO> GetUserInformation(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var dataBaseOutput = _db.userinformationList.FirstOrDefault(u => u.Id == id);

            if (dataBaseOutput == null)
            {
                return NotFound();
            }

            return Ok(dataBaseOutput);
        }

        [HttpPost]
        public ActionResult<userInformationDTO> CreateUserInformation([FromBody] userInformationDTO userInformationDTO)
        {

            // CHECK IF USER IS AUTH TO POST 

            /////////////////////////////////////////////////////////

            // // checking if the Item is unique
            if (_db.userinformationList.FirstOrDefault(u => u.Id == userInformationDTO.Id) != null)
            {
                ModelState.AddModelError("CustomError", "Already exists!");
                return BadRequest(ModelState);
            }

            if (userInformationDTO == null)
            {
                return BadRequest(userInformationDTO);
            }

            if (userInformationDTO.Id != 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            userInformation model = new(){
                Id = userInformationDTO.Id,
                birthday = userInformationDTO.birthday,
                catchprase = userInformationDTO.catchprase, 
                description = userInformationDTO.description,
                firstname = userInformationDTO.firstname,
                lastname = userInformationDTO.lastname, 
                imageURL= userInformationDTO.imageURL,
                TermsAndConditionsAccepted = userInformationDTO.TermsAndConditionsAccepted


            };

            _db.userinformationList.Add(model);
            _db.SaveChanges();


            // // Returns the url where the data is stored
            return CreatedAtRoute("userinformation", new { id = userInformationDTO.Id }, userInformationDTO);

        }


        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id:int}", Name = "Deleteuserinformation")]
        public IActionResult Deleteuserinformation(int id)
        {
            if (id < 1)
            {
                return BadRequest();

            }

            var dataBaseOutput = _db.userinformationList.FirstOrDefault(u => u.Id == id);
            if (dataBaseOutput == null)
            {
                return NotFound();
            }

            _db.userinformationList.Remove(dataBaseOutput);
            _db.SaveChanges();
            return NoContent();

        }




        
    }
}
