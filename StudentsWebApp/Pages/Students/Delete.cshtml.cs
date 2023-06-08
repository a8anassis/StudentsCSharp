using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsWebApp.DTO;
using StudentsWebApp.Service;

namespace StudentsWebApp.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentService studentService;

        public DeleteModel(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        public void OnGet()
        {
            try
            {
                int id = int.Parse(Request.Query["id"]);
                studentService.DeleteStudent(id);
                Response.Redirect("/Students/index");
            }
            catch (Exception)
            {
                Response.Redirect("/Error");
            }
        }
    }
}
