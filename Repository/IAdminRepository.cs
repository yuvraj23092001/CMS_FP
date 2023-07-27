using SmsBackend.Models;
using SmsBackend.ViewModels;
using System.ComponentModel;

namespace SmsBackend.Repository
{
    public interface IAdminRepository
    {
        // teachers tasks 
        Task<List<TeacherViewModel>> GetAllTeachersAsync();

        Task<TeacherViewModel> GetTeacherIdAsync(int UserId);

        Task<TeacherViewModel> GetTeacherByClass(int ClassId);

       

        Task<User> AddTeacherAsync(TeacherViewModel teacher);

        Task UpdateTeacherAsync(int userId, TeacherViewModel teacher);

        Task<User> DeleteTeacherAsync(string email);

        // students tasks

        Task<List<StudentViewModel>> GetAllStudentAsync();

        Task<StudentViewModel> GetStudentIdAsync(int UserId);

        Task<StudentViewModel> GetStudentByEmail(string Email);

        Task<User> AddStudentAsync(StudentViewModel t);

        Task UpdateStudentAsync(int userId, StudentViewModel teacher);

        Task DeleteStudentAsync(string email);

        Task<StudentViewModel> GetStudentByClassId(int ClassId);

        // notice tasks 

        Task<List<NoticeViewModel>> GetAllNoticeAsync();

        Task<NoticeViewModel> GetNoticeByCreatedByAsync(int CreatedBy);

        Task<int> AddNoticeAsync(NoticeViewModel Notice);

        Task DeleteNoticeAsync(int Id);

        Task<int> AssignTeacherAsync(int T_id, int Subject_id);

        // attendence tasks 

        Task<Attendance> addAttendence(Attendance attendence);

        Task<List<Attendance>> GetAllAttendence();

        Task UpdateAttendenceAsync(int userId, Attendance attendance);

        // leave tasks 

        Task<Leave> addLeave(Leave leave);

        Task<Leave> getLeaveById(int LeaveId);

        Task updateLeaveById(int LeaveId, Leave leave);

    }
}
