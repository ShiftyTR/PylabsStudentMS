using PylabsStudentMS.Entity;
using PylabsStudentMS.Models;

namespace PylabsStudentMS.Factory.IFactory
{
    public interface IExamFactory
    {
        public ExamResponseModel CalculateScore(ExamRequestModel examResultModel, string cryptoLink);
        public string GetExamJson(string cryptoLink);
        public ExamResult CreateExam(int userId, int examId);
        public List<ExamResponseModel> GetAllExamResults();
    }
}
