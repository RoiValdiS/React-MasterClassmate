using Microsoft.AspNetCore.Mvc;
using ReactSer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReactSer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        // GET: api/<TeacherController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        [HttpGet]
        [Route("Read")]
        public List<Teacher> GetTeachers()
        {
            return Teacher.ReadTeachers();
        }
        // POST api/<TeacherController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        // POST api/<TeacherController>
        [HttpPost]
        [Route("Insert1")]
        public int Insert([FromBody] Teacher t)
        {
            Console.WriteLine(t.name);
            return Teacher.Insert(t);
        }
        // POST api/<TeacherController>
        [HttpGet]
        [Route("checkif/email/{email}")]
        public Teacher CheckExists(string email)
        {
            return Teacher.CheckIfExists(email);
        }
        // POST api/<TeacherController>
        [HttpGet]
        [Route("GetClassStudent/teacheremail/{teacheremail}")]
        public List<Student> GetClassStudent1(string teacheremail)
        {
            return Teacher.GetClassStudent(teacheremail);
        }
        [HttpGet]
        [Route("GetClassStudentOne/teacheremail/{teacheremail}")]
        public List<Student> GetClassStudentOne1(string teacheremail)
        {
            return Teacher.GetClassStudentOne(teacheremail);
        }
        [HttpPost]
        [Route("LogInTeacher/email/{email}/password/")]
        public Teacher LogInTeacher1(string email, [FromBody] string password)
        {
            return Teacher.LogInTeacher(email, password);
        }

        [HttpGet]
        [Route("GetStudentClasses/studentemail/{studentemail}")]
        public List<Teacher> GetStudentClasses1(string studentemail)
        {
            return Teacher.GetStudentClasses(studentemail);
        }

        [HttpPost]
        [Route("InsertClass/studentemail/{studentemail}/teacheremail/{teacheremail}")]
        public int InsertClass1(string studentemail, string teacheremail)
        {
            return Teacher.InsertClass(studentemail,teacheremail);
        }
        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        // PUT api/<TeacherController>/5
        [HttpPut]
        [Route("UpdateT")]
        public int Put([FromBody] Teacher t)
        {
            return Teacher.Update(t);
        }
        [HttpPut]
        [Route("UpdateClass")]
        public int UpdateClass1(string studentemail, string teacheremail)
        {
            return Teacher.updateClass(studentemail, teacheremail);
        }
        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        // DELETE api/<TeacherController>/5
        [HttpDelete]
        [Route("DeleteClass/studentemail/{studentemail}/teacheremail/{teacheremail}")]
        public int Delete(string studentemail, string teacheremail)
        {
            return Teacher.DeleteClass(studentemail, teacheremail);
        }
    }
}
