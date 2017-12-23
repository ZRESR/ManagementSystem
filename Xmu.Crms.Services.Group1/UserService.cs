using System;
using System.Collections.Generic;
using System.Text;
using Xmu.Crms.Services.Group1.Dao;
using Xmu.Crms.Shared.Models;
using Xmu.Crms.Shared.Service;
using Xmu.Crms.Shared.Exceptions;

namespace Xmu.Crms.Services.Group1
{
    class UserService : IUserService
    {
        private readonly IUserDao _userDao;
        private readonly ICourseService _courseService;
        public UserService(IUserDao userDao, ICourseService courseService)
        {
            _userDao = userDao;
            _courseService = courseService;
        }

        // 根据用户Id获取用户的信息
        public UserInfo GetUserByUserId(long userId)
        {
            if (userId.GetType().ToString() != "System.Int64")
                throw new UserNotFoundException();//id格式错误 
            UserInfo userInfo = _userDao.Find(userId);
            if(userInfo==null)
                throw new UserNotFoundException();//未找到对应用户
            return userInfo;
        }

        // InsertAttendanceById中用到的方法
        private static double rad(double d)
        {
            return d * Math.PI / 180.0;
        }
        // 根据班级id，讨论课id，学生id，经度，纬度进行签到 在方法中通过班级id，讨论课id获取当堂课发起签到的位置
        public void InsertAttendanceById(long classId, long seminarId, long userId, double longitude, double latitude)
        {
            if (seminarId.GetType().ToString() != "System.Int64" || classId.GetType().ToString() != "System.Int64"
                || userId.GetType().ToString() != "System.Int64")
                throw new ArgumentException();//id格式错误
            Location location = _userDao.FindTeacherLocation(classId, seminarId);
            if(location == null)
            {
                throw new ClassNotFoundException();
                throw new SeminarNotFoundException();
            }
            double tLongtitude = location.Longitude;
            double tLatitude = location.Latitude;
            double EARTH_RADIUS = 6378.137;//地球半径
            double radLat1 = rad(tLatitude);
            double radLat2 = rad(latitude);
            double a = radLat1 - radLat2;
            double b = rad(tLongtitude) - rad(longitude);
            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
             Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * EARTH_RADIUS;
            s = Math.Round(s * 10000) / 10000;//s为经纬度换算出的实际距离（单位km）
            Attendance attendance = new Attendance();
            attendance.ClassInfo.Id = classId;
            attendance.Seminar.Id = seminarId;
            if(s<0.1 && location.Status==1)   
                attendance.AttendanceStatus = AttendanceStatus.Present;
            else if(s<0.1 && location.Status==0)
                attendance.AttendanceStatus = AttendanceStatus.Late;
            _userDao.AddAttendance(attendance);

        }

        //list 处于缺勤状态的学生列表
        public IList<UserInfo> ListAbsenceStudent(long seminarId, long classId)
        {
            if (seminarId.GetType().ToString() != "System.Int64" || classId.GetType().ToString() != "System.Int64")
                throw new ArgumentException();//id格式错误
            IList<UserInfo> list  = _userDao.FindAbsenceStudents(seminarId, classId);
            if (list == null)
            {
                throw new ClassNotFoundException();//未找到对应班级
                throw new SeminarNotFoundException();//未找到对应讨论课
            }
            return list;
        }

        // 根据班级id，讨论课id获取当堂课签到信息
        public IList<Attendance> ListAttendanceById(long classId, long seminarId)
        {
            if (seminarId.GetType().ToString() != "System.Int64" || classId.GetType().ToString() != "System.Int64")
                throw new ArgumentException();//id格式错误
            IList < Attendance > list= _userDao.FindAttendanceById(seminarId, classId);
            if(list==null)
            {
                throw new ClassNotFoundException();//未找到对应班级
                throw new SeminarNotFoundException();//未找到对应讨论课
            }
            return list;
        }

        // 根据教师名称列出课程名称
        //public IList<Course> ListCourseByTeacherName(string teacherName)
        //{
        //    CourseService courseService = new CourseService();
        //    IList<Course> list = _userDao.FindCourseByTeacher(teacherName);
        //    IList<UserInfo> users = ListUserByUserName(teacherName);
        //    foreach (UserInfo u in users)
        //    {
        //        if (u.Type == Shared.Models.Type.Teacher)
        //        {
        //            list += courseService.ListCourseByUserId(u.Id);
        //        }
        //    }
        //    return list;
        //}

        //list 处于迟到状态的学生的列表
        public IList<UserInfo> ListLateStudent(long seminarId, long classId)
        {
            if (seminarId.GetType().ToString() != "System.Int64" || classId.GetType().ToString() != "System.Int64")
                throw new ArgumentException();//id格式错误
            IList<UserInfo> list = _userDao.FindLateStudents(seminarId, classId);
            if (list == null)
            {
                throw new ClassNotFoundException();//未找到对应班级
                throw new SeminarNotFoundException();//未找到对应讨论课
            }
            return list;
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
