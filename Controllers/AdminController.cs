using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmsBackend.Models;
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

        [HttpPost("teachers/add")]

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
                return NotFound(new { message = "teacher operation is returning a null value meaning teacher by the provided id doesnot exist. " });
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

        [HttpPost("students/add")]

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

        public async Task<IActionResult> GetstudentbyEmail([FromRoute] string Email)
        {
            var teachers = await _adminRepostitory.GetStudentByEmail(Email);
            if (teachers == null)
            {
                return NotFound(new { message = "student operation is returning a null value meaning student by the provided Email doesnot exist. " });
            }
            return Ok(teachers);
        }

        // method to get student by the class id so as to retrieve data for attendence by class teacher 

        [HttpGet("student-classid/{ClassId}")]

        public async Task<IActionResult> GetStudentByClassId([FromRoute] int ClassId)
        {
            var teachers = await _adminRepostitory.GetStudentByClassId(ClassId);
            if (teachers == null)
            {
                return NotFound(new { message = "student operation is returning a null value meaning the provided class id is not right. " });
            }
            return Ok(teachers);
        }


        // method to update student user by userid 

        [HttpPut("student/update/{UserId}")]

        public async Task<IActionResult> updateStudentById([FromBody] StudentViewModel StudentViewModel, [FromRoute] int UserId)
        {
            await _adminRepostitory.UpdateStudentAsync(UserId, StudentViewModel);
            return Ok();
        }

        // method to delete the student by the email id 

        [HttpDelete("student-delete/{email}")]

        public async Task<IActionResult> DeleteStudent([FromRoute] string email)
        {
            await _adminRepostitory.DeleteStudentAsync(email);
            return Ok();
        }

        // Notice operations 

        // method to get all notices 

        [HttpGet("notice/get")]

        public async Task<IActionResult> GetAllNoticesAsync()
        {
            var notice = await _adminRepostitory.GetAllNoticeAsync();

            if (notice == null)
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

            if (notice == null)
            {
                return NotFound();
            }

            return Ok(notice);
        }

        // method to add new notice to the database 

        [HttpPost("notice/add")]

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

            if (id == 0)
            {
                return NotFound(new { message = "Please enter a valid subject id " });
            }

            return Ok(id);

        }


        // Attendence operations 

        // We dont need to delete attendence as teacher will be the one marking it 
        // we just need a add attendence method and update attendence method 

        [HttpPost("attendence/add")]

        // add attendence of a user 
        public async Task<IActionResult> AddAttendence([FromBody] Attendance student)
        {
            var id = await _adminRepostitory.addAttendence(student);
            return Ok(id);
        }

        // update attendence of a student by userId 


        [HttpPut("attendence/update/{UserId}")]

        public async Task<IActionResult> updateAttendenceById([FromBody] Attendance attedence, [FromRoute] int UserId)
        {
            await _adminRepostitory.UpdateAttendenceAsync(UserId, attedence);
            return Ok();
        }


        // Leave operations 

        // Student applys for a leave but isApproved is set as false in the start 

        [HttpPost("leave/add")]

        public async Task<IActionResult> addLeave(Leave leave)
        {
            var id = await _adminRepostitory.addLeave(leave);

            if (id == null)
            {
                return NotFound(new { Message = " Not able to add leave to the system " });
            }

            return Ok(id);
        }

        //  Get leaves applied by leave id  

        [HttpGet("leave/{id}")]

        public async Task<IActionResult> getLeaveByUserId([FromRoute] int id)
        {
            var leave = await _adminRepostitory.getLeaveById(id);

            if (leave == null)
            {
                return NotFound();
            }

            return Ok(leave);
        }

        // Update leaves isApproved by teacher of the class 
        [HttpPut("leave/update/{UserId}")]

        public async Task<IActionResult> updateLeaveById([FromRoute] int LeaveId, [FromBody] Leave leave)
        {
            await _adminRepostitory.updateLeaveById(LeaveId, leave);
            return Ok();
        }


    } 
}
