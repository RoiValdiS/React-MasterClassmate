namespace ReactSer.Models
{
    public class Student
    {
        public int id { get; set; }
        public string phone { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public byte[] img { get; set; }
        public Student() { }
        public Student(int id, string phone, string name , string email, string password, byte[] img)
        {
            this.id = id;
            this.phone = phone;
            this.name = name;
            this.email = email;
            this.password = password;
            this.img = img;
        }
        public static List<Student> ReadAllStudent()
        {
            DBservices db = new DBservices();
            return db.ReadStudents();
       }
        public static Student GetByEmail(string email)
        {
            DBservices db = new DBservices();
            return db.CheckIfStudentExists(email);
        }
        public static int InsertStudent(Student s)
        {
            DBservices db=  new DBservices();
            return db.InsertStudent(s);
        }
        public static Student LogInStudent(string email, string password)
        {
            DBservices db = new DBservices();
            return db.LogInStudent(email, password);
        }
        public static int UpdateStudentImg(string email, byte[] img)
        {
            DBservices db = new DBservices();
            return db.UpdateStudentImg(email, img);
        }
    }
}
