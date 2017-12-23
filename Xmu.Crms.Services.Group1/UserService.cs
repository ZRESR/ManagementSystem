using System;
using System.Collections.Generic;
using System.Text;
using Xmu.Crms.Services.Group1.Dao;
using Xmu.Crms.Shared.Models;
using Xmu.Crms.Shared.Service;

namespace Xmu.Crms.Services.Group1
{
    class UserService : IUserService
    {
        private readonly IUserDao _userDao;
        public UserService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public UserInfo GetUserByUserId(long userId)
        {
            throw new NotImplementedException();
        }

        public void InsertAttendanceById(long classId, long seminarId, long userId, double longitude, double latitude)
        {
            throw new NotImplementedException();
        }

        public IList<UserInfo> ListAbsenceStudent(long seminarId, long classId)
        {
            throw new NotImplementedException();
        }

        public IList<Attendance> ListAttendanceById(long classId, long seminarId)
        {
            throw new NotImplementedException();
        }

        public IList<Course> ListCourseByTeacherName(string teacherName)
        {
            throw new NotImplementedException();
        }

        public IList<UserInfo> ListLateStudent(long seminarId, long classId)
        {
            throw new NotImplementedException();
        }

        public IList<UserInfo> ListPresentStudent(long seminarId, long classId)
        {
            throw new NotImplementedException();
        }

        public IList<UserInfo> ListUserByClassId(long classId, string numBeginWith, string nameBeginWith)
        {
            throw new NotImplementedException();
        }

        public IList<UserInfo> ListUserByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public IList<long> ListUserIdByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserByUserId(long userId, UserInfo user)
        {
            throw new NotImplementedException();
        }
    }
}
