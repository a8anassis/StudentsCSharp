using StudentsWebApp.DTO;

namespace StudentsWebApp.Validator
{
    /// <summary>
    /// Utility class. No instances of this
    /// class should be available.
    /// </summary>
    public class StudentValidator
    {
        private StudentValidator() { }

        public static string Validate(StudentDTO? dto)
        {
            if (dto == null || dto is not StudentDTO)
            {
                return "Invalid data";
            }

            if (dto.Firstname?.Length < 2 || dto.Firstname?.Length > 50)
            {
                return "Firstname not valid";
            }

            if (dto.Lastname?.Length < 2 || dto.Lastname?.Length > 50)
            {
                return "Lastname not valid";
            }

            return "";
        }
    }
}
