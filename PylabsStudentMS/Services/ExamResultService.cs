using Microsoft.EntityFrameworkCore;
using PylabsStudentMS.Data;
using PylabsStudentMS.Entity;
using PylabsStudentMS.Services.IService;
using System.Linq.Expressions;

namespace PylabsStudentMS.Services
{
    public class ExamResultService : IExamResultService
    {
        private readonly ApiContext _context;
        public ExamResultService(IConfiguration configuration)
        {
            _context = new ApiContext(configuration);
        }
        public ExamResult Add(ExamResult entity)
        {
            var response =_context.ExamResult.Add(entity);
            Save();
            return response.Entity;
        }
        public ExamResult CreateExam(int userId, int examId)
        {
            var examResult = new ExamResult
            {
                UserId = userId,
                JsonExamId = examId,
                CryptoLink = Guid.NewGuid().ToString(),
            };
            Add(examResult);
            return examResult;
        }
        public void Delete(int id)
        {
            var user = _context.ExamResult.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                _context.ExamResult.Remove(user);
                Save();
            }
        }

        public void Delete(ExamResult entity)
        {
            _context.ExamResult.Remove(entity);
            Save();
        }

        public List<ExamResult> Get(Expression<Func<ExamResult, bool>> exp = null)
        {
            List<ExamResult> examResults;
            if (exp != null)

            {
                examResults = _context.ExamResult.Where(exp).Include(x=>x.User).ToList();
            }
            else
            {
                examResults = _context.ExamResult.Include(x => x.User).ToList();
            }
            return examResults;
        }

        public ExamResult Get(int id)
        {
            return _context.ExamResult.FirstOrDefault(x => x.Id == id);
        }
        public ExamResult GetExamWithCrptoLink(string link)
        {
            return _context.ExamResult.Include(x=>x.User).FirstOrDefault(x => x.CryptoLink == link);
        }
        public void Update(ExamResult entity)
        {
            _context.ExamResult.Add(entity);
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
