namespace PylabsStudentMS.Entity
{
    public class ExamResult : IEntity
    {
        public int Id { get; set; }
        public string CryptoLink { get; set; }
        public bool IsDone { get; set; }
        public int JsonExamId { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public double Score { get; set; }
        public int WrongAnswerCount { get; set; }
        public int CorrectAnswerCount { get; set; }
    }
}
