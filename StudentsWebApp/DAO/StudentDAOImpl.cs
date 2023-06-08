
using StudentsWebApp.DAO.DBUtil;
using StudentsWebApp.Model;
using System.Data.SqlClient;

namespace StudentsWebApp.DAO
{
    public class StudentDAOImpl : IStudentDAO
    {
        public void Insert(Student? student)
        {
            if (student == null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                conn!.Open();
                string sql = "INSERT INTO STUDENTS " +
                             "(FIRSTNAME, LASTNAME) VALUES " +
                             "(@firstname, @lastname)";

                using SqlCommand command = new(sql, conn);
                command.Parameters.AddWithValue("@firstname", student.Firstname);
                command.Parameters.AddWithValue("@lastname", student.Lastname);

                command.ExecuteNonQuery();   
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Update(Student? student)
        {
            if (student == null) return;
           
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                conn!.Open();
                string sql = "UPDATE STUDENTS SET FIRSTNAME=@firstname, " +
                             " LASTNAME=@lastname WHERE ID=@id";

                using SqlCommand command = new(sql, conn);
                command.Parameters.AddWithValue("@firstname", student.Firstname);
                command.Parameters.AddWithValue("@lastname", student.Lastname);
                command.Parameters.AddWithValue("@id", student.Id);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                conn!.Open();
                string sql = "DELETE FROM STUDENTS WHERE ID=@id";
                using SqlCommand command = new(sql, conn);
                command.Parameters.AddWithValue("@id", id);
                int rowsAffected = command.ExecuteNonQuery(); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public Student? GetById(int id)
        {
            Student? student = null;
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                conn!.Open();
                string sql = "SELECT * FROM STUDENTS WHERE ID=@id";
                using SqlCommand command = new(sql, conn);
                command.Parameters.AddWithValue("@id", id);

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    student = new()
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2)
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }

            return student;
        }

        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();   
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                conn!.Open();
                string sql = "SELECT * FROM STUDENTS";
                using SqlCommand command = new(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Student student = new()
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2)
                    };

                    students.Add(student);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
            return students;
        }   
    }
}
