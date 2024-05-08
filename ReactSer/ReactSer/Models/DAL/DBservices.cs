using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using ReactSer.Models;


/// <summary>
/// DBServices is a class created by me to provides some DataBase Services
/// </summary>
public class DBservices
{

    public DBservices()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //--------------------------------------------------------------------------------------------------
    // This method creates a connection to the database according to the connectionString name in the web.config 
    //--------------------------------------------------------------------------------------------------
    public SqlConnection connect(String conString)
    {

        //// read the connection string from the configuration file
        //IConfigurationRoot configuration = new ConfigurationBuilder()
        //.AddJsonFile("appsettings.json").Build();
        //string cStr = configuration.GetConnectionString("Data Source=LAPTOP-30NAD1N3\\SQLEXPRESS;Initial Catalog=ReactProject;Integrated Security=True");

        string cStr = "Data Source=Media.ruppin.ac.il;Initial Catalog=igroup115_test1; User ID=igroup115; Password=igroup115_53696";
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }


    //--------------------------------------------------------------------------------------------------
    // This method Inserts a user to the user table 
    //--------------------------------------------------------------------------------------------------
    public int InsertTeacher(Teacher t)
    {

        Console.WriteLine(t.name);
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        Dictionary<string, object> paramDic = new Dictionary<string, object>();
        paramDic.Add("@phone", t.phone);
        paramDic.Add("@name", t.name);
        paramDic.Add("@email", t.email);
        paramDic.Add("@password", t.password);
        paramDic.Add("@fields", t.fields);
        paramDic.Add("@img", t.img);



        cmd = CreateCommandWithStoredProcedure("InsertTeacher", con, paramDic);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            //int numEffected = Convert.ToInt32(cmd.ExecuteScalar()); // returning the id
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    //--------------------------------------------------------------------------------------------------
    // This method Inserts a user to the user table 
    //--------------------------------------------------------------------------------------------------
    public int InsertStudent(Student t)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        Dictionary<string, object> paramDic = new Dictionary<string, object>();
        paramDic.Add("@phone", t.phone);
        paramDic.Add("@name", t.name);
        paramDic.Add("@email", t.email);
        paramDic.Add("@password", t.password);
      
        paramDic.Add("@img", t.img);



        cmd = CreateCommandWithStoredProcedure("InsertStudent", con, paramDic);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            //int numEffected = Convert.ToInt32(cmd.ExecuteScalar()); // returning the id
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }




    /// <summary>
    /// //
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public int InsertClass(string studentemail, string teacheremail)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        Dictionary<string, object> paramDic = new Dictionary<string, object>();
        paramDic.Add("@studentemail", studentemail);
        paramDic.Add("@teacheremail", teacheremail);
 



        cmd = CreateCommandWithStoredProcedure("insertClass", con, paramDic);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            //int numEffected = Convert.ToInt32(cmd.ExecuteScalar()); // returning the id
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }


    public int DeleteClass(string studentemail, string teacheremail)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        Dictionary<string, object> paramDic = new Dictionary<string, object>();
        paramDic.Add("@studentemail", studentemail);
        paramDic.Add("@teacheremail", teacheremail);




        cmd = CreateCommandWithStoredProcedure("DeleteClass", con, paramDic);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            //int numEffected = Convert.ToInt32(cmd.ExecuteScalar()); // returning the id
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    ////--------------------------------------------------------------------------------------------------
    //// This method Reads all students above a certain age
    //// This method uses the return value mechanism
    ////--------------------------------------------------------------------------------------------------
    public List<Student> GetClassStudent(string teacheremail)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }


        Dictionary<string, object> paramDic = new Dictionary<string, object>();
        paramDic.Add("@teacheremail", teacheremail);



        cmd = CreateCommandWithStoredProcedure("readClasses", con, paramDic);             // create the command

        List<Student> arr = new List<Student>();

        //try
        //{
        //    SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //    dataReader.Read();
        //    Student s = new Student();
        //    s.id = Convert.ToInt32(dataReader["id"]);
        //    s.phone = dataReader["phone"].ToString();
        //    s.name = dataReader["name"].ToString();
        //    s.email = dataReader["email"].ToString();
        //    s.password = dataReader["password"].ToString();
        //    s.img = dataReader["img"] as byte[];
        //    arr.Add(s);      
        //}
        //return arr;
        List<Student> studentList = new List<Student>();

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Student s = new Student();
                s.id = Convert.ToInt32(dataReader["id"]);
                s.phone = dataReader["phone"].ToString();
                s.name = dataReader["name"].ToString();
                s.email = dataReader["email"].ToString();
                s.password = dataReader["password"].ToString();
                s.img = dataReader["img"] as byte[];
                studentList.Add(s);
            }
            return studentList;
        }
        catch (Exception ex)
        {
            // write to log
            return null;
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
            // note that the return value appears only after closing the connection
        }
    }




    public List<Teacher> GetStudentClass(string studentemail)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }


        Dictionary<string, object> paramDic = new Dictionary<string, object>();
        paramDic.Add("@studentemail", studentemail);



        cmd = CreateCommandWithStoredProcedure("GetStudentClasses", con, paramDic);             // create the command

        List<Student> arr = new List<Student>();

        //try
        //{
        //    SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //    dataReader.Read();
        //    Student s = new Student();
        //    s.id = Convert.ToInt32(dataReader["id"]);
        //    s.phone = dataReader["phone"].ToString();
        //    s.name = dataReader["name"].ToString();
        //    s.email = dataReader["email"].ToString();
        //    s.password = dataReader["password"].ToString();
        //    s.img = dataReader["img"] as byte[];
        //    arr.Add(s);      
        //}
        //return arr;
        List<Teacher> studentList = new List<Teacher>();

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Teacher s = new Teacher();
                s.id = Convert.ToInt32(dataReader["id"]);
                s.phone = dataReader["phone"].ToString();
                s.name = dataReader["name"].ToString();
                s.email = dataReader["email"].ToString();
                s.password = dataReader["password"].ToString();
                s.fields = dataReader["fields"].ToString();
                s.img = dataReader["img"] as byte[];
                studentList.Add(s);
            }
            return studentList;
        }
        catch (Exception ex)
        {
            // write to log
            return null;
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
            // note that the return value appears only after closing the connection
        }
    }













    public List<Student> GetClassStudentOne(string teacheremail)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }


        Dictionary<string, object> paramDic = new Dictionary<string, object>();
        paramDic.Add("@teacheremail", teacheremail);



        cmd = CreateCommandWithStoredProcedure("readClassOne", con, paramDic);             // create the command

        List<Student> arr = new List<Student>();

        //try
        //{
        //    SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //    dataReader.Read();
        //    Student s = new Student();
        //    s.id = Convert.ToInt32(dataReader["id"]);
        //    s.phone = dataReader["phone"].ToString();
        //    s.name = dataReader["name"].ToString();
        //    s.email = dataReader["email"].ToString();
        //    s.password = dataReader["password"].ToString();
        //    s.img = dataReader["img"] as byte[];
        //    arr.Add(s);      
        //}
        //return arr;
        List<Student> studentList = new List<Student>();

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Student s = new Student();
                s.id = Convert.ToInt32(dataReader["id"]);
                s.phone = dataReader["phone"].ToString();
                s.name = dataReader["name"].ToString();
                s.email = dataReader["email"].ToString();
                s.password = dataReader["password"].ToString();
                s.img = dataReader["img"] as byte[];
                studentList.Add(s);
            }
            return studentList;
        }
        catch (Exception ex)
        {
            // write to log
            return null;
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
            // note that the return value appears only after closing the connection
        }
    }
    ////--------------------------------------------------------------------------------------------------
    //// This method Reads all students above a certain age
    //// This method uses the return value mechanism
    ////--------------------------------------------------------------------------------------------------
    public Teacher CheckExists(string email)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }


        Dictionary<string, object> paramDic = new Dictionary<string, object>();
        paramDic.Add("@email", email);



        cmd = CreateCommandWithStoredProcedure("CheckIfExists", con, paramDic);             // create the command

        Teacher s = new Teacher();

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            dataReader.Read();
            s.id = Convert.ToInt32(dataReader["id"]);
            s.phone = dataReader["phone"].ToString();
            s.name = dataReader["name"].ToString();
            s.email = dataReader["email"].ToString();
            s.password = dataReader["password"].ToString();
            s.fields = dataReader["fields"].ToString();
            s.img = dataReader["img"] as byte[];
            return s;
        }
        catch (Exception ex)
        {
            // write to log
            return null;
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
            // note that the return value appears only after closing the connection
        }
    }

/// <summary>
/// ///////////////////
/// </summary>
/// <param name="email"></param>
/// <returns></returns>
    public Student CheckIfStudentExists(string email)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }


        Dictionary<string, object> paramDic = new Dictionary<string, object>();
        paramDic.Add("@email", email);



        cmd = CreateCommandWithStoredProcedure("GetStudentsByEmail", con, paramDic);             // create the command

        Student s = new Student();

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            dataReader.Read();
            s.id = Convert.ToInt32(dataReader["id"]);
            s.phone = dataReader["phone"].ToString();
            s.name = dataReader["name"].ToString();
            s.email = dataReader["email"].ToString();
            s.password = dataReader["password"].ToString();
            s.img = dataReader["img"] as byte[];
            return s;
        }
        catch (Exception ex)
        {
            // write to log
            return null;
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
            // note that the return value appears only after closing the connection
        }
    }







    // log in teacher
    public Teacher LogInTeacher(string email, string password)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }


        Dictionary<string, object> paramDic = new Dictionary<string, object>();
        paramDic.Add("@email", email);
        paramDic.Add("password", password);



        cmd = CreateCommandWithStoredProcedure("LogInTeacher", con, paramDic);             // create the command

        Teacher s = new Teacher();

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            dataReader.Read();
            s.id = Convert.ToInt32(dataReader["id"]);
            s.phone = dataReader["phone"].ToString();
            s.name = dataReader["name"].ToString();
            s.email = dataReader["email"].ToString();
            s.password = dataReader["password"].ToString();
            s.fields = dataReader["fields"].ToString();
            s.img = dataReader["img"] as byte[] ?? new byte[0];
            return s;
        }
        catch (Exception ex)
        {
            // write to log
            return null;
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
            // note that the return value appears only after closing the connection
        }
    }




    public Student LogInStudent(string email, string password)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }


        Dictionary<string, object> paramDic = new Dictionary<string, object>();
        paramDic.Add("@email", email);
        paramDic.Add("password", password);



        cmd = CreateCommandWithStoredProcedure("LogInStudent", con, paramDic);             // create the command

        Student s = new Student();

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            dataReader.Read();
            s.id = Convert.ToInt32(dataReader["id"]);
            s.phone = dataReader["phone"].ToString();
            s.name = dataReader["name"].ToString();
            s.email = dataReader["email"].ToString();
            s.password = dataReader["password"].ToString();
            s.img = dataReader["img"] as byte[];
            return s;
        }
        catch (Exception ex)
        {
            // write to log
            return null;
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
            // note that the return value appears only after closing the connection
        }
    }
    //}
    ////--------------------------------------------------------------------------------------------------
    //// This method update a student to the student table 
    ////--------------------------------------------------------------------------------------------------
    public int UpdateTeacher(Teacher t)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        Dictionary<string, object> paramDic = new Dictionary<string, object>();
        paramDic.Add("@phone", t.phone);
        paramDic.Add("@name", t.name);
        paramDic.Add("@email", t.email);
        paramDic.Add("@password", t.password);
        paramDic.Add("@fields", t.fields);
        paramDic.Add("@img", t.img);


        cmd = CreateCommandWithStoredProcedure("UpdateTeacher", con, paramDic);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }



    /// <summary>
    /// //
    /// </summary>

    /// <returns></returns>
    public int Updateclass(string studentemail , string teacheremail)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        Dictionary<string, object> paramDic = new Dictionary<string, object>();
        paramDic.Add("@studentemail",studentemail);
        paramDic.Add("@teacheremail", teacheremail);
 

        cmd = CreateCommandWithStoredProcedure("updateVerified", con, paramDic);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }


    public int UpdateStudentImg(string email, byte[] img)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        Dictionary<string, object> paramDic = new Dictionary<string, object>();
        paramDic.Add("@email", email);

        paramDic.Add("@img", img);


        cmd = CreateCommandWithStoredProcedure("updateStudentImg", con, paramDic);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }



    ////--------------------------------------------------------------------------------------------------
    //// This method Reads all students
    ////--------------------------------------------------------------------------------------------------
    public List<Teacher> ReadTeachers()
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("asd"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }


        cmd = CreateCommandWithStoredProcedure("GetTeachers", con, null);             // create the command


        List<Teacher> studentList = new List<Teacher>();

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Teacher s = new Teacher();
                s.id = Convert.ToInt32(dataReader["id"]);
                s.phone = dataReader["phone"].ToString();
                s.name = dataReader["name"].ToString();
                s.email = dataReader["email"].ToString(); 
                s.password = dataReader["password"].ToString();
                s.fields = dataReader["fields"].ToString();
                s.img = dataReader["img"] as byte[] ?? new byte[0];
                studentList.Add(s);
            }
            return studentList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }




    public List<Student> ReadStudents()
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("asd"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }


        cmd = CreateCommandWithStoredProcedure("GetStudents", con, null);             // create the command


        List<Student> studentList = new List<Student>();

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Student s = new Student();
                s.id = Convert.ToInt32(dataReader["id"]);
                s.phone = dataReader["phone"].ToString();
                s.name = dataReader["name"].ToString();
                s.email = dataReader["email"].ToString();
                s.password = dataReader["password"].ToString();
                s.img = dataReader["img"] as byte[];
                studentList.Add(s);
            }
            return studentList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }




    //---------------------------------------------------------------------------------
    // Create the SqlCommand using a stored procedure
    //---------------------------------------------------------------------------------
    private SqlCommand CreateCommandWithStoredProcedure(String spName, SqlConnection con, Dictionary<string, object> paramDic)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        if(paramDic != null)
            foreach (KeyValuePair<string, object> param in paramDic) {
                cmd.Parameters.AddWithValue(param.Key,param.Value);

            }


        return cmd;
    }



}
