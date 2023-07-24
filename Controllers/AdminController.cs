using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmsBackend.Repository;
using SmsBackend.ViewModels;

namespace SmsBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepostitory;

         public AdminController(IAdminRepository adminRepostitory)
        {
            _adminRepostitory = adminRepostitory;

        }

        // Teacher operations 


        // method 1

        [HttpGet("teachers")]
        public async Task<IActionResult> GetAllTeacher()
        {
            var teachers = await _adminRepostitory.GetAllTeachersAsync();
            if (teachers == null)
            {
                return NotFound();
            }
            return Ok(teachers);
        }

        // no need to use createdataction currently but need to use in future projects as it is part of best practices.

        [HttpPost("teachers/")]

        public async Task<IActionResult> AddTeacher([FromBody] TeacherViewModel teacher)
        {
            var id = await _adminRepostitory.AddTeacherAsync(teacher);
            return Ok(id);/*CreatedAtAction(nameof(GetTeacherByID), new { UserId = id, Controller = "Admin" }, id);*/
        }
    
        
        // method to get teacher by the id 

        [HttpGet("teacher-id/{id}")]

        public async Task<IActionResult> GetTeacherByID([FromRoute] int id)
        {
            var teachers = await _adminRepostitory.GetTeacherIdAsync(id);
            if (teachers == null)
            {
                return NotFound( new { message = "teacher operation is returning a null value meaning teacher by the provided id doesnot exist. "});
            }
            return Ok(teachers);
        }

        // method to get teacher by the classId
        [HttpGet("teacher-classid/{ClassId}")]

        public async Task<IActionResult> GetTeacherByClassId([FromRoute] int ClassId)
        {
            var teachers = await _adminRepostitory.GetTeacherByClass(ClassId);
            if (teachers == null)
            {
                return NotFound(new { message = "teacher operation is returning a null value meaning teacher by the provided class id doesnot exist. " });
            }
            return Ok(teachers);
        }

        // method to update the details of the teacher by using user id 
        [HttpPut("teacher/update/{UserId}")]

        public async Task<IActionResult> updateTeacherById([FromBody] TeacherViewModel teachersViewModel, [FromRoute] int UserId)
        {
            await _adminRepostitory.UpdateTeacherAsync(UserId, teachersViewModel);
            return Ok();
        }


        // method to delete the record of a teacher by email 
        [HttpDelete("{email}")]

        public async Task<IActionResult> DeleteTeacher([FromRoute] string email)
        {
            await _adminRepostitory.DeleteTeacherAsync(email); 
            return Ok();
        }

        // Student operations 

        // method to get list of all students also we are checking if user role matches or not.

        [HttpGet("students")]
        public async Task<IActionResult> GetAllStudent()
        {
            var teachers = await _adminRepostitory.GetAllStudentAsync();
            if (teachers == null)
            {
                return NotFound();
            }
            return Ok(teachers);
        }


        // method to add students to the userbase

        [HttpPost("students/")]

        public async Task<IActionResult> AddStudents([FromBody] StudentViewModel student)
        {
            var id = await _adminRepostitory.AddStudentAsync(student);
            return Ok(id);
        }

        // method to get student by the id 

        [HttpGet("student-id/{id}")]

        public async Task<IActionResult> GetStudentByID([FromRoute] int id)
        {
            var students = await _adminRepostitory.GetStudentIdAsync(id);
            if (students == null)
            {
                return NotFound(new { message = "student operation is returning a null value meaning student by the provided id doesnot exist. " });
            }
            return Ok(students);
        }

        // method to get student by the email 

        [HttpGet("student/{Email}")]

        public async Task<IActionResult> GetTeacherByEmail([FromRoute] string Email)
        {
            var teachers = await _adminRepostitory.GetStudentByEmail(Email);
            if (teachers == null)
            {
                return NotFound(new { message = "student operation is returning a null value meaning student by the provided Email doesnot exist. " });
            }
            return Ok(teachers);
        }

        // method to update student user by userid 


        // method to delete the student by the email id 

        [HttpDelete("student-delete/{email}")]

        public async Task<IActionResult> DeleteStudent([FromRoute] string email)
        {
            await _adminRepostitory.DeleteStudentAsync(email);
            return Ok();
        }

        // Notice operations 

        // method to get all notices 

        [HttpGet("notice/")]

        public async Task<IActionResult> GetAllNoticesAsync()
        {
            var notice = await _adminRepostitory.GetAllNoticeAsync();

            if( notice == null)
            {
                return NotFound();
            }

            return Ok(notice);
        }

        // method to get notices by created by  

        [HttpGet("notice/{id}")]

        public async Task<IActionResult> GetNoticeByCreatedBy([FromRoute] int id)
        {
            var notice = await _adminRepostitory.GetNoticeByCreatedByAsync(id);

            if(notice == null)
            {
                return NotFound();
            }

            return Ok(notice);
        }

        // method to add new notice to the database 

        [HttpPost("notice/")]

        public async Task<IActionResult> AddNotice([FromBody] NoticeViewModel notice)
        {
            var id = await _adminRepostitory.AddNoticeAsync(notice);
            return Ok(id);
        }

        // method to delete a notice by notice id 

        [HttpDelete("notice-delete/{id}")]

        public async Task<IActionResult> DeleteNotice([FromRoute] int id)
        {
            await _adminRepostitory.DeleteNoticeAsync(id);
            return Ok();
        }

        // Subject teacher operations 
        // using apis assign teachers to the list of subjects 
        [HttpGet("Subject-teacher")]

        public async Task<IActionResult> AssignTeachersToSubject([FromQuery] int T_id, [FromQuery] int Subject_id)
        {
            var id = await _adminRepostitory.AssignTeacherAsync(T_id, Subject_id);

            if(id == 0)
            {
                return NotFound( new { message = "Please enter a valid subject id "});
            }

            return Ok(id);

        }


        // Attendence operations 


    }
}
