using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xmu.Crms.Shared.Exceptions;
using Xmu.Crms.Shared.Models;
using Xmu.Crms.Shared.Service;

namespace Xmu.Crms.Services.Group1
{
    public class UserService : IUserService
    {
        private readonly CrmsContext _db;

        // 在构造函数里添加依赖的Service（参考模块标准组的类图）
        public UserService(CrmsContext db)
        {
            _db = db;
        }

        public bool InsertAttendanceById(long classId, long seminarId, long userId, double longitude, double latitude)
        {
            throw new NotImplementedException();
        }

        public List<Attendance> ListAttendanceById(long classId, long seminarId)
        {
            throw new NotImplementedException();
        }

        public UserInfo SignUpPhone(UserInfo user)
        {
            var us = _db.UserInfo.SingleOrDefault(u => u.Phone == user.Phone);
            if (us == null)
            {
                throw new UserNotFoundException();
            }
            if (user.Password != us.Password) // 千万不要真的用明文存储密码！
            {
                throw new PasswordErrorException();
            }
            return us;
        }

        public bool DeleteTeacherAccount(long userId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteStudentAccount(long userId)
        {
            throw new NotImplementedException();
        }

        public UserInfo GetUserByUserId(long id)
        {
            // 调用Entity framework
            var user = _db.UserInfo.Include(u => u.School).SingleOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            // 调用依赖的 Serivce
           
            return user;
        }

        public List<long> ListUserIdByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUserByUserId(long userId, UserInfo user)
        {
            throw new NotImplementedException();
        }

        public List<UserInfo> ListUserByClassId(long classId, string numBeginWith, string nameBeginWith)
        {
            throw new NotImplementedException();
        }

        public List<UserInfo> ListUserByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public List<UserInfo> ListPresentStudent(long seminarId, long classId)
        {
            throw new NotImplementedException();
        }

        public List<UserInfo> ListAbsenceStudent(long seminarId, long classId)
        {
            throw new NotImplementedException();
        }

        public List<Course> ListCourseByTeacherName(string teacherName)
        {
            throw new NotImplementedException();
        }



        List<Attendance> IUserService.ListAttendanceById(long classId, long seminarId)
        {
            throw new NotImplementedException();
        }

        UserInfo IUserService.GetUserByUserId(long userId)
        {
            var user = _db.UserInfo.SingleOrDefault(u => u.Id == userId);
            return user;
        }

        List<long> IUserService.ListUserIdByUserName(string userName)
        {
            throw new NotImplementedException();
        }



        List<UserInfo> IUserService.ListUserByClassId(long classId, string numBeginWith, string nameBeginWith)
        {
            throw new NotImplementedException();
        }

        List<UserInfo> IUserService.ListUserByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        List<UserInfo> IUserService.ListPresentStudent(long seminarId, long classId)
        {
            throw new NotImplementedException();
        }

        List<UserInfo> IUserService.ListAbsenceStudent(long seminarId, long classId)
        {
            throw new NotImplementedException();
        }

        List<Course> IUserService.ListCourseByTeacherName(string teacherName)
        {
            throw new NotImplementedException();
        }

        void IUserService.InsertAttendanceById(long classId, long seminarId, long userId, double longitude, double latitude)
        {
            throw new NotImplementedException();
        }

        void IUserService.UpdateUserByUserId(long userId, UserInfo user)
        {
            throw new NotImplementedException();
        }
    }
}