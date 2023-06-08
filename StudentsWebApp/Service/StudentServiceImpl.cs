using StudentsWebApp.DAO;
using StudentsWebApp.DTO;
using StudentsWebApp.Model;

namespace StudentsWebApp.Service
{
    public class StudentServiceImpl : IStudentService
    {
        private readonly IStudentDAO dao;

        public StudentServiceImpl(IStudentDAO dao)
        {
            this.dao = dao;
        }

        public void InsertStudent(StudentDTO? dto)
        {
            if (dto == null) return;

            Student? student = Map(dto);

            try
            {
                dao.Insert(student);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        
        public void UpdateStudent(StudentDTO? dto)
        {
            if (dto == null) return;

            Student? student = Map(dto);

            try
            {
                dao.Update(student);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public Student? DeleteStudent(int id)
        {
            Student? student;
            try
            {
                student = dao.GetById(id);
                if (student is null) return null;
                dao.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
            return student;
        }

        public List<Student> GetAllStudents()
        {      
            try
            {
                return dao.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public Student? GetStudentById(int id)
        {     
            try
            {
                return dao.GetById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        private Student? Map(StudentDTO? dto)
        {
            if (dto == null) return null;
            Student? student = new Student()
            {
                Id = dto.Id,
                Firstname = dto.Firstname,
                Lastname = dto.Lastname,
            };

            return student;
        }

    }
}
