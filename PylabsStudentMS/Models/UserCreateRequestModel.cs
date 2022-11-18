namespace PylabsStudentMS.Models
{
    public class UserCreateRequestModel
    {
        public string Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
