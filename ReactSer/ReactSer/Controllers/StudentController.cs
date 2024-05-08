using Microsoft.AspNetCore.Mvc;
using ReactSer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReactSer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // POST api/<TeacherController>
        [HttpPost]
        [Route("Insert1")]
        public int Insert([FromBody] Student t)
        {
            return Student.InsertStudent(t);
        }

        [HttpPost]
        [Route("LogInStudent/email/{email}/password/")]
        public Student LogInStudent1(string email, [FromBody] string password)
        {
            return Student.LogInStudent(email, password);
        }

        // POST api/<StudentController>
        [HttpGet]
        [Route("GetByEmail/email/{email}")]
        public Student GetByEmail1(string email)
        {
            return Student.GetByEmail(email);
        }
        // GET: api/<StudentController>
        [HttpGet]
        [Route("ReadAll1")]
        public List<Student> ReadAll()
        {
            return Student.ReadAllStudent();
        }
        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        // PUT api/<StudentController>/5
        [HttpPut("UpdateImg1/email/{email}")]
        public int Put(string email, [FromBody] byte[] img)
        {
            return Student.UpdateStudentImg(email, img);
        }
        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
