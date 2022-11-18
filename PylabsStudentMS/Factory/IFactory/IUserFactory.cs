using PylabsStudentMS.Entity;
using PylabsStudentMS.Models;

namespace PylabsStudentMS.Factory.IFactory
{
    public interface IUserFactory
    {
        public User CreateUser(UserCreateRequestModel model);
    }
}
