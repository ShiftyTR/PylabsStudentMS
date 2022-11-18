using PylabsStudentMS.Entity;

namespace PylabsStudentMS.Services.IService
{
    public interface IUserService: IService<User,int>
    {
        public User? Authenticate(string userName, string password);
    }
}
