using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xmu.Crms.Services.Group1.Dao;
using Xmu.Crms.Shared.Models;

namespace Xmu.Crms.Services.Group1
{
    class UserDao:IUserDao
    {
        private readonly CrmsContext _db;

        public UserDao(CrmsContext db)
        {
            _db = db;
        }

        //通过Id查找用户
        public UserInfo Find(long userId)
        {
            UserInfo userInfo = _db.UserInfo.FirstOrDefault(u => u.Id == userId);
            return userInfo;
        }
        //查找这个班所有缺勤学生
        public List<UserInfo> FindAbsenceStudents(long seminarId, long classId)
        {
            List<UserInfo> list = (from s in _db.Attendences.Where(s => s.ClassInfo.Id == classId && s.Seminar.Id == seminarId && s.AttendanceStatus == AttendanceStatus.Absent)
                                   select s.Student).ToList<UserInfo>();
            return list;
        }
        //根据班级号和讨论课号查找出勤记录
        public IList<Attendance> FindAttendanceById(long seminarId, long classId)
        {
            List<Attendance> list =  _db.Attendences.Where(s => s.ClassInfo.Id == classId && s.Seminar.Id == seminarId).ToList<Attendance>();
            return list;
        }
        //根据老师姓名查询所有课程
        public IList<Course> FindCourseByTeacher(string teacherName)
        {
            List<Course> list = _db.Course.Where(u => u.Teacher.Name == teacherName).ToList<Course>();
            return list;
        }
        //根据班级号和讨论课号查找迟到学生
        public IList<UserInfo> FindLateStudents(long seminarId, long classId)
        {
            List<UserInfo> list = (from s in _db.Attendences.Where(s => s.ClassInfo.Id == classId && s.Seminar.Id == seminarId && s.AttendanceStatus== AttendanceStatus.Late)
                                  select s.Student).ToList<UserInfo>();
            return list;
        }
        //根据班级号和讨论课号查找老师位置
        Location FindTeacherLocation(long classId, long seminarId)
        {
            Location location = _db.Location.FirstOrDefault(l => l.ClassInfo.Id == classId && l.Seminar.Id == seminarId);
            return location;
        }
        //插入attendance记录
        void AddAttendance(Attendance attendance)
        {
            _db.Attendences.Add(attendance);
            _db.SaveChanges();
        }
    }
}
