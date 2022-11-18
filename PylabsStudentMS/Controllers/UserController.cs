using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PylabsStudentMS.Factory.IFactory;
using PylabsStudentMS.Models;

namespace PylabsStudentMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        IUserFactory _userFactory;
        public UserController(IUserFactory userFactory)
        {
            _userFactory = userFactory;
        }
        [HttpPost("CreateUser")]
        public IActionResult CreateUser(UserCreateRequestModel model)
        {
            return Ok(_userFactory.CreateUser(model));
        }

    }
}
