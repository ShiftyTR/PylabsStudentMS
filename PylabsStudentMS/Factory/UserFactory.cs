using PylabsStudentMS.Entity;
using PylabsStudentMS.Factory.IFactory;
using PylabsStudentMS.Models;
using PylabsStudentMS.Services.IService;

namespace PylabsStudentMS.Factory
{
    public class UserFactory : IUserFactory
    {
        IUserService _userService;
        public UserFactory(IUserService userService)
        {
            _userService = userService;
        }
        public User CreateUser(UserCreateRequestModel model)
        {
            User user = new User();
            user.UserName = model.UserName;
            user.LastName = model.LastName;
            user.Password = model.Password;
            user.Role = model.Role;
            user.FirstName = model.FirstName;
            
            return _userService.Add(user);
        }
    }
}
