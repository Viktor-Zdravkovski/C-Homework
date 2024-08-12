using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace ApiHomework1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        [HttpGet("getallusers")]
        public ActionResult<List<string>> GetAll()
        {
            return StatusCode(StatusCodes.Status200OK, UsersStaticDb.Users);
        }

        [HttpGet("getone/{id}")]
        public ActionResult<string> GetOne(int id)
        {
            try
            {
                if (id < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "The index has negative value. Please try again.");
                }

                if (id >= UsersStaticDb.Users.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"There is no resource on index {id}");
                }

                return StatusCode(StatusCodes.Status200OK, UsersStaticDb.Users[id]);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred.");
            }
        }

        [HttpPost("create")]

        public IActionResult AddUser([FromBody] string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "The body of the request can not be empty");
                }

                UsersStaticDb.Users.Add(name);
                return StatusCode(StatusCodes.Status201Created, $"The name: {name}, has been successufuly added");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ("An error has occured"));

            }
        }


        [HttpDelete]
        public IActionResult Delete([FromBody]string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "The body of the request can not be empty");
            }
            if (!UsersStaticDb.Users.Contains(name))
            {
                return StatusCode(StatusCodes.Status404NotFound, $"The name: {name} was not found");
            }

            UsersStaticDb.Users.Remove(name);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
