using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SmsBackend.Models;
using SmsBackend.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmsBackend.Repository
{
    public class AdminRepostitory : IAdminRepository
    {
        private readonly FinalSmsContext _context;

        public AdminRepostitory(FinalSmsContext context)
        {
            _context = context;
        }

        // All the teacher methods 

        // method to get all teachers without any filters
        public async Task<List<TeacherViewModel>> GetAllTeachersAsync()
        {
            return await (from t in _context.Users.Where(u => u.UserRole == 1)


                          select new TeacherViewModel
                          {

                              UserId = t.UserId,
                              FName = t.FirstName,
                              LName = t.LastName,
                              Password = t.Password,
                              Email = t.EmailId,
                              UserRole = t.UserRole,
                              Dob = t.Dob,
                              salary = (int)t.Salary

                          }).ToListAsync();
        }

        // method to add new teachers and we are taking the class which they will teach
        public async Task<User> AddTeacherAsync(TeacherViewModel teacher)
        {
            var teachers = new User()
            {
                FirstName = teacher.FName,
                LastName = teacher.LName,
                EmailId = teacher.Email,
                UserRole = 1, // manually setting the user role to 1 as it indicates of teacher
                Dob = (System.DateTime)teacher.Dob,
                Password = teacher.Password,
                Salary = teacher.salary,
                Contact = teacher.Contact,
                FkClassId = teacher.ClassId  // we will give the admin the permission to add any teacher to any stearm 

            };


            _context.Users.Add(teachers);

            await _context.SaveChangesAsync();

            return teachers;
        }

        // method to get specific teacher by their user id 
        public async Task<TeacherViewModel> GetTeacherIdAsync(int UserId)
        {
            var records = await _context.Users.Where(t => t.UserId == UserId && t.UserRole == 1).Select(t => new TeacherViewModel()
            {

                UserId = t.UserId,
                FName = t.FirstName,
                LName = t.LastName,
                Password = t.Password,
                Email = t.EmailId,
                UserRole = t.UserRole,
                salary = (int)t.Salary,
                Contact = t.Contact,
                Dob = t.Dob,
            }).FirstOrDefaultAsync();
            return records;
        }

        // method to get teachers by their class number 
        public async Task<TeacherViewModel> GetTeacherByClass(int ClassId)
        {
            var records = await _context.Users.Where(t => t.FkClassId == ClassId && t.UserRole == 1).Select(t => new TeacherViewModel()
            {

                UserId = t.UserId,
                FName = t.FirstName,
                LName = t.LastName,
                Password = t.Password,
                Email = t.EmailId,
                UserRole = t.UserRole,
                salary = (int)t.Salary,
                Contact = t.Contact,
                Dob = t.Dob,
                ClassId = (int)t.FkClassId,
            }).FirstOrDefaultAsync();
            return records;
        }



        // method to update the details of the different teacher 
        // since we are not returning any data we will not have Task<T> just Task
        public async Task UpdateTeacherAsync(int userId, TeacherViewModel teacher)
        {
            var teachers = new User()
            {
                FkClassId = teacher.ClassId,
                UserId = userId,
                FirstName = teacher.FName,
                LastName = teacher.LName,
                Password = teacher.Password,
                EmailId = teacher.Email,
                UserRole = teacher.UserRole,
                Salary = teacher.salary,
                Contact = teacher.Contact,
                Dob = teacher.Dob,
            };

            _context.Users.Update(teachers);
            await _context.SaveChangesAsync();

        }

        // method to delete the teachers based on their email 
        public async Task<User> DeleteTeacherAsync(string email)
        {
            User? teachers = _context.Users.Where(x => x.EmailId == email && x.UserRole == 1).FirstOrDefault(); // we are just matching userrole for precaution as we dont need it as email is unique.


            _context.Users.Remove(teachers);

            await _context.SaveChangesAsync();

            return teachers;
        }

        // Student 

        // methods to get all students from the user database 

        public async Task<List<StudentViewModel>> GetAllStudentAsync()
        {

            return await (from t in _context.Users.Where(u => u.UserRole == 0)
                          select new StudentViewModel
                          {
                              UserId = t.UserId,
                              FName = t.FirstName,
                              LName = t.LastName,
                              Password = t.Password,
                              Email = t.EmailId,
                              UserRole = t.UserRole,
                              Dob = t.Dob


                          }).ToListAsync();



        }

        // methods to get students by matching given userid 
        public async Task<StudentViewModel> GetStudentIdAsync(int UserId)
        {


            var records = await _context.Users.Where(t => t.UserId == UserId).Select(t => new StudentViewModel()
            {
                UserId = t.UserId,
                FName = t.FirstName,
                LName = t.LastName,
                Password = t.Password,
                Email = t.EmailId,
                UserRole = t.UserRole,
                Dob = t.Dob


            }).FirstOrDefaultAsync();
            return records;
        }

        // method to student by matching the email 
        public async Task<StudentViewModel> GetStudentByEmail(string Email)
        {
            var records = await _context.Users.Where(t => t.EmailId == Email).Select(t => new StudentViewModel()
            {
                UserId = t.UserId,
                FName = t.FirstName,
                LName = t.LastName,
                Password = t.Password,
                Email = t.EmailId,
                UserRole = t.UserRole,
                Dob = t.Dob


            }).FirstOrDefaultAsync();
            return records;
        }

        // method to get students by classid

        public async Task<StudentViewModel> GetStudentByClassId(int ClassId)
        {
            var records = await _context.Users.Where(t => t.FkClassId == ClassId).Select(t => new StudentViewModel()  // we are comparing the class id of the student and the given class id 
            {
                UserId = t.UserId,
                FName = t.FirstName,
                LName = t.LastName,
                Password = t.Password,
                Email = t.EmailId,
                UserRole = t.UserRole,
                Dob = t.Dob


            }).FirstOrDefaultAsync();
            return records;
        }




        // Method to add users to database 
        public async Task<User> AddStudentAsync(StudentViewModel t)
        {
            var Students = new User()
            {
                UserId = t.UserId,
                FirstName = t.FName,
                LastName = t.LName,
                Password = t.Password,
                EmailId = t.Email,
                UserRole = 0,
                Dob = t.Dob


            };

            _context.Users.Add(Students);

            await _context.SaveChangesAsync();

            return Students;

        }

        // method to update a student using their id 

        public async Task UpdateStudentAsync(int userId, StudentViewModel teacher)
        {
            var students = new User()
            {
                FkClassId = 0,
                UserId = userId,
                FirstName = teacher.FName,
                LastName = teacher.LName,
                Password = teacher.Password,
                EmailId = teacher.Email,
                UserRole = teacher.UserRole,
                Salary = 0,
                Contact = 0,
                Dob = teacher.Dob,
            };

            _context.Users.Update(students);
            await _context.SaveChangesAsync();

        }

        // method to delete a specific student using email as it is unique 
        public async Task DeleteStudentAsync(string email)
        {
            var student = _context.Users.Where(x => x.EmailId == email).FirstOrDefault();

            _context.Users.Remove(student);

            await _context.SaveChangesAsync();

        }
        
        

        // All the notice methods  

        // method to get all notices 
        public async Task<List<NoticeViewModel>> GetAllNoticeAsync()
        {
            return await (from n in _context.Notices
                          from i in _context.Users
                          where n.FkCreatedBy == i.UserId
                          select new NoticeViewModel
                          {
                              Id = n.Id,
                              Notice1 = n.Notice1,
                              FkCreatedBy = i.UserId,
                              CreatedOn = n.CreatedOn
                          }).ToListAsync();

        }

        // method to get notices where we use created by operation to find specific news.
        public async Task<NoticeViewModel> GetNoticeByCreatedByAsync(int CreatedBy)
        {
            var records = await _context.Notices.Where(x => x.FkCreatedBy == CreatedBy).Select(x => new NoticeViewModel()
            {
                Id = x.Id,
                Notice1 = x.Notice1,
                CreatedOn = x.CreatedOn,
                FkCreatedBy = x.FkCreatedBy,
            }
            ).FirstOrDefaultAsync();
            return records;
        }

        // method to add new notices to the array

        public async Task<int> AddNoticeAsync(NoticeViewModel Notice)
        {
            var new_notice = new Notice()
            {
                Notice1 = Notice.Notice1,
                CreatedOn = Notice.CreatedOn,
                FkCreatedBy = Notice.FkCreatedBy,
            };

            _context.Notices.Add(new_notice);
            await _context.SaveChangesAsync();

            return Notice.Id;
        }


        // method to delete a specific notice from the array using a notice id 

        public async Task DeleteNoticeAsync(int Id)
        {
            var notice = _context.Notices.Where(x =>x.Id == Id).FirstOrDefault();
            _context.Notices.Remove(notice);
            await _context.SaveChangesAsync();
        }

        // Subject teacher operations 

        // assign teachers to the subjects so we are able to add 

        public async Task<int> AssignTeacherAsync(int T_id , int Subject_id)
        {
            var new_assignment = new SubjectTeacher()
            {
                FkSubjectId = Subject_id,
                FkTeacherId = T_id,
            };
            _context.SubjectTeachers.Add(new_assignment);
            await _context.SaveChangesAsync();

            return new_assignment.Id;

        }

        // Attendence operations 
        public async Task<Attendance> addAttendence(Attendance attendence)
        {
            var st_attendence = new Attendance()
            {
                Attended = attendence.Attended,
                FkSubjectId = attendence.FkSubjectId,
                FkUserId = attendence.FkUserId,
            };

            _context.Attendances.Add(st_attendence);
            await _context.SaveChangesAsync();
            return attendence;
        }

        // attendence reteval by subject id 
        public async Task<List<Attendance>> GetAllAttendence()
        {
            return await (from a in _context.Attendances
                          from i in _context.SubjectTeachers
                          where a.FkSubjectId == i.FkSubjectId
                          select new Attendance
                          {
                             FkSubjectId= i.FkSubjectId,
                             Attended = a.Attended,
                             FkUserId = a.FkUserId,
                          }).ToListAsync();
        }

        // Update attendence of student by userId 
       
        public async Task UpdateAttendenceAsync(int userId, Attendance attendance)
        {
            var attendence = new Attendance()
            {
                Attended = attendance.Attended,
                FkSubjectId = attendance.FkSubjectId,
                FkUserId = attendance.FkUserId,
            };

            _context.Attendances.Update(attendance);
            await _context.SaveChangesAsync();
        }
        

        // Leave operations 

        // Add leaves to be applied by the students and isApproved is not controlled by student 

        public async Task<Leave> addLeave(Leave leave)
        {
            var Leave = new Leave()
            {
                FkLeaveId = leave.FkLeaveId,
                IsApproved = 0, // student cannot have the leave approved at the time of creation 
                Leave1 = leave.Leave1, // reason is put in this file 

            };

            _context.Leaves.Add(Leave);

            await _context.SaveChangesAsync();

            return Leave;
        }

        // Get leave by leave id  we are using this api due to database design otherwise we are able to add classid in leave .so we are able to show all leaves of students to the class teacher
        // and then we will create leave by class id 

        public async Task<Leave> getLeaveById(int LeaveId) // leave id is not same is id in leave 
        {
            var leave = await _context.Leaves.Where(x => x.FkLeaveId == LeaveId).Select(x => new Leave()
            {
                Leave1 = x.Leave1,
                FkLeaveId = x.FkLeaveId,
                IsApproved = x.IsApproved,

            }).FirstOrDefaultAsync();
           
            return leave;
        }

        // update the status of leave application from the teacher side 

        public async Task updateLeaveById(int LeaveId, Leave leave)
        {
            var item = new Leave()
            {
                Id = LeaveId, // overriding the current data with updated data
                IsApproved = leave.IsApproved,
                Leave1 = leave.Leave1,
                FkLeaveId = leave.FkLeaveId,
            };

            _context.Leaves.Update(item);
            await _context.SaveChangesAsync();

            
        }
    }

}



