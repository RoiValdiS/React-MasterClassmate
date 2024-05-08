namespace ReactSer.Models
{
    public class Teacher
    {
        public int id { get; set; }
        public string phone { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string fields { get; set; }
        public byte[] img { get; set; }
        public Teacher(int id, string phone, string name, string email, string password, string fields, byte[] img)
        {
            this.id = id;
            this.phone = phone;
            this.name = name;
            this.email = email;
            this.password = password;
            this.fields = fields;
            this.img = img;
        }
        public Teacher() { }
        public static List<Teacher> ReadTeachers()
        {
            DBservices db = new DBservices();
            return db.ReadTeachers();
        }
        public static Teacher CheckIfExists(string email)
        {
            DBservices db = new DBservices();
            return db.CheckExists(email);
        }
        public static int Insert(Teacher t)
        {
            DBservices db = new DBservices();
            return db.InsertTeacher(t);
        }
        public static Teacher LogInTeacher(string email, string password)
        {
            DBservices db = new DBservices();
            return db.LogInTeacher(email, password);
        }
        public static int Update(Teacher t)
        {
            DBservices dB = new DBservices();
            return dB.UpdateTeacher(t);
        }

        public static int InsertClass(string studentemail, string teacheremail)
        {
            DBservices db = new DBservices();
            return db.InsertClass(studentemail, teacheremail);
        }
        public static List<Student> GetClassStudent(string teaceeremail)
        {
            DBservices db = new DBservices();
            return db.GetClassStudent(teaceeremail);
        }
        public static int updateClass(string studentemail, string teacheremail)
        {
            DBservices db = new DBservices();
            return db.Updateclass(studentemail, teacheremail);
        }
        public static List<Student> GetClassStudentOne(string teaceeremail)
        {
            DBservices db = new DBservices();
            return db.GetClassStudentOne(teaceeremail);
        }
        public static int DeleteClass(string studentemail, string teacheremail)
        {
            DBservices db = new DBservices();
            return db.DeleteClass(studentemail, teacheremail);
        }
        public static List<Teacher> GetStudentClasses(string studentemail)
        {
            DBservices db = new DBservices();
            return db.GetStudentClass(studentemail);
        }
    }

}
