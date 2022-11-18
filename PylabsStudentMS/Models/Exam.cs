namespace PylabsStudentMS.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string ExamName { get; set; }
        public List<Question> Questions { get; set; }
    }
    public class Question
    {
        public int Number { get; set; }
        public string Text { get; set; }
        public List<Answer> Answers { get; set; }
    }
    public class Answer
    {
        public string Label { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}