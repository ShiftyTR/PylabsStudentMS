using PylabsStudentMS.Entity;
using PylabsStudentMS.Factory.IFactory;
using PylabsStudentMS.Models;
using PylabsStudentMS.Services.IService;
using System.Text.Json;

namespace PylabsStudentMS.Factory
{
    public class ExamFactory : IExamFactory
    {
        IExamResultService _examResultService;
        public ExamFactory(IExamResultService examResultService)
        {
            _examResultService = examResultService;
        }
        public ExamResponseModel CalculateScore(ExamRequestModel examResultModel, string cryptoLink)
        {
            var examResult = _examResultService.GetExamWithCrptoLink(cryptoLink);
            var json = GetExamJson(cryptoLink);
            Exam exam = JsonSerializer.Deserialize<Exam>(json);
            var questionCount = exam.Questions.Count;
            foreach (var question in exam.Questions)
            {
                if (examResultModel.Answers.TryGetValue(question.Number, out var answerUser)) { 
                    var answer = question.Answers.Where(x => x.IsCorrect).FirstOrDefault();
                    if (answer != null && answer.Label == answerUser)
                    {
                        examResult.CorrectAnswerCount++;
                    }
                    else
                    {
                        examResult.WrongAnswerCount++;
                    }
                }

                
            }

            double score = 100;
            var oneQestionScore = score / questionCount;
            examResult.Score = oneQestionScore * examResult.CorrectAnswerCount;
            examResult.IsDone = true;

            _examResultService.Update(examResult);
            ExamResponseModel examResponseModel = new ExamResponseModel();
            examResponseModel.Score = examResult.Score;
            examResponseModel.CryptoLink = examResult.CryptoLink;
            examResponseModel.WrongAnswerCount = examResult.WrongAnswerCount;
            examResponseModel.CorrectAnswerCount = examResult.CorrectAnswerCount;
            examResponseModel.ExamId = examResult.Id;
            examResponseModel.Student = new();
            examResponseModel.Student.FirstName = examResult.User.FirstName;
            examResponseModel.Student.LastName = examResult.User.LastName;
            examResponseModel.Student.UserName = examResult.User.UserName;
            return examResponseModel;
        }
        public string GetExamJson(string cryptoLink)
        {
            var examResult = _examResultService.GetExamWithCrptoLink(cryptoLink);
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string jsonPath = Path.Combine(path, "jsons", examResult.JsonExamId.ToString() + ".json");
            string json = System.IO.File.ReadAllText(jsonPath);
            return json;
        }
        public ExamResult CreateExam(int userId, int examId)
        {
            return _examResultService.CreateExam(userId, examId);
        }
        public List<ExamResponseModel> GetAllExamResults()
        {
            List<ExamResponseModel> examResponseModels = new();
            var exams = _examResultService.Get().ToList();
            foreach (var item in exams)
            {
                ExamResponseModel examResponseModel = new ExamResponseModel();
                examResponseModel.CryptoLink = item.CryptoLink;
                examResponseModel.Score = item.Score;
                examResponseModel.WrongAnswerCount = item.WrongAnswerCount;
                examResponseModel.CorrectAnswerCount = item.CorrectAnswerCount;
                examResponseModel.ExamId = item.Id;
                examResponseModel.Student = new();
                examResponseModel.Student.FirstName = item.User.FirstName;
                examResponseModel.Student.LastName = item.User.LastName;
                examResponseModel.Student.UserName = item.User.UserName;
                examResponseModels.Add(examResponseModel);
            }
            return examResponseModels;
        }
    }
}