using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PylabsStudentMS.Factory;
using PylabsStudentMS.Factory.IFactory;
using PylabsStudentMS.Models;
using PylabsStudentMS.Services.IService;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace PylabsStudentMS.Controllers
{
    public class ExamController : Controller
    {
        IExamFactory _examFactory;
        public ExamController(IExamFactory examFactory)
        {
            _examFactory = examFactory;
        }
        [HttpGet("Exam/{cryptoLink}")]
        public IActionResult Exam(string cryptoLink)
        {
            var json = _examFactory.GetExamJson(cryptoLink);
            return Ok(json);
        }
        [HttpPost("Exam/{cryptoLink}")]
        public IActionResult Exam(string cryptoLink, [FromBody] ExamRequestModel examResultModel)
        {
            var result = _examFactory.CalculateScore(examResultModel, cryptoLink);
            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("CreateExam")]
        public IActionResult CreateExam(int userId, int examId)
        {
            return Ok(_examFactory.CreateExam(userId, examId));
        }
        [Authorize(Roles = "Admin" )]
        [HttpGet("GetAllExamResults")]
        public IActionResult GetAllExamResults()
        {
            return Ok(_examFactory.GetAllExamResults());
        }
    }
}
