using PylabsStudentMS.Entity;
using PylabsStudentMS.Models;

namespace PylabsStudentMS.Services.IService
{
    public interface IExamResultService : IService<ExamResult,int>
    {
        public ExamResult GetExamWithCrptoLink(string link);
        public ExamResult CreateExam(int userId, int examId);
    }
}
