using StudentsWebApp.Model;

namespace StudentsWebApp.DAO
{
    public interface IStudentDAO
    {
        void Insert(Student? student);
        void Update(Student? student);
        void Delete(int id);
        Student? GetById(int id);
        List<Student> GetAll();
    }
}
