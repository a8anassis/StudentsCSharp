using StudentsWebApp.DTO;
using StudentsWebApp.Model;

namespace StudentsWebApp.Service
{
    public interface IStudentService
    {
        void InsertStudent(StudentDTO? dto);
        void UpdateStudent(StudentDTO? dto);
        Student? DeleteStudent(int id);
        Student? GetStudentById(int id);
        List<Student> GetAllStudents();
    }
}
