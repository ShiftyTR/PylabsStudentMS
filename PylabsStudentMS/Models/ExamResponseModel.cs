namespace PylabsStudentMS.Models
{
    public class ExamResponseModel
    {
        public int ExamId { get; set; }
        public string CryptoLink { get; set; }
        public double Score { get; set; }
        public int WrongAnswerCount { get; set; }
        public int CorrectAnswerCount { get; set; }
        public Student Student { get; set; }
    }
    public class Student
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
