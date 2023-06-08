using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsWebApp.DTO;
using StudentsWebApp.Model;
using StudentsWebApp.Service;
using StudentsWebApp.Validator;

namespace StudentsWebApp.Pages.Students
{
    public class UpdateModel : PageModel
    {
        private readonly IStudentService studentService;
        public string ErrorMessage { get; set; } = "";
        public StudentDTO StudentDto { get; set; } = new();

        public UpdateModel(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        public void OnGet()
        {
            try
            {
                Student? student;

                int id = int.Parse(Request.Query["id"]);
                student = studentService.GetStudentById(id);

                StudentDto = ConvertToDto(student);
                // return Page();
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }

        public void OnPost()
        {
            StudentDto.Id = int.Parse(Request.Form["id"]);
            StudentDto.Firstname = Request.Form["firstname"];
            StudentDto.Lastname = Request.Form["lastname"];

            ErrorMessage = StudentValidator.Validate(StudentDto);

            if (!ErrorMessage.Equals("")) return;

            try
            {
                studentService.UpdateStudent(StudentDto);
                Response.Redirect("/Students/index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private StudentDTO ConvertToDto(Student? student)
        {
            StudentDTO dto = new()
            {
                Id = student!.Id,
                Firstname = student.Firstname,
                Lastname = student.Lastname
            };

            return dto;
        }
    }
}
