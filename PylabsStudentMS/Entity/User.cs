namespace PylabsStudentMS.Entity
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
