using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static readonly List<User> Users = new()
        {
            new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith",
                Email = "john.smith@techhive.com",
                Department = "IT"
            },
            new User
            {
                Id = 2,
                FirstName = "Sarah",
                LastName = "Jones",
                Email = "sarah.jones@techhive.com",
                Department = "HR"
            }
        };

        // GET: api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers(
            int page = 1,
            int pageSize = 10)
        {
            try
            {
                var result = Users
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        // GET: api/users/1
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            try
            {
                var user = Users.FirstOrDefault(u => u.Id == id);

                if (user == null)
                    return NotFound("User not found.");

                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        // POST: api/users
        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(user.FirstName))
                    return BadRequest("First name is required.");

                if (string.IsNullOrWhiteSpace(user.LastName))
                    return BadRequest("Last name is required.");

                if (string.IsNullOrWhiteSpace(user.Email) ||
                    !user.Email.Contains("@"))
                    return BadRequest("Valid email is required.");

                if (string.IsNullOrWhiteSpace(user.Department))
                    return BadRequest("Department is required.");

                user.Id = Users.Max(u => u.Id) + 1;

                Users.Add(user);

                return CreatedAtAction(
                    nameof(GetUser),
                    new { id = user.Id },
                    user);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        // PUT: api/users/1
        [HttpPut("{id}")]
        public IActionResult UpdateUser(
            int id,
            User updatedUser)
        {
            try
            {
                var user = Users.FirstOrDefault(u => u.Id == id);

                if (user == null)
                    return NotFound("User not found.");

                if (string.IsNullOrWhiteSpace(updatedUser.FirstName))
                    return BadRequest("First name is required.");

                if (string.IsNullOrWhiteSpace(updatedUser.LastName))
                    return BadRequest("Last name is required.");

                if (string.IsNullOrWhiteSpace(updatedUser.Email) ||
                    !updatedUser.Email.Contains("@"))
                    return BadRequest("Valid email is required.");

                user.FirstName = updatedUser.FirstName;
                user.LastName = updatedUser.LastName;
                user.Email = updatedUser.Email;
                user.Department = updatedUser.Department;

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        // DELETE: api/users/1
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var user = Users.FirstOrDefault(u => u.Id == id);

                if (user == null)
                    return NotFound("User not found.");

                Users.Remove(user);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}