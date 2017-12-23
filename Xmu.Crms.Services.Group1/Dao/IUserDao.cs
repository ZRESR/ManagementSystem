﻿using System;
using System.Collections.Generic;
using System.Text;
using Xmu.Crms.Shared.Models;
namespace Xmu.Crms.Services.Group1.Dao
{
    interface IUserDao
    {
        //通过Id查用户
        UserInfo Find(long userId);
        //查找这个班所有缺勤学生
        List<UserInfo> FindAbsenceStudents(long seminarId, long classId);
        //根据班级号和讨论课号查找出勤记录
        IList<Attendance> FindAttendanceById(long seminarId, long classId);
        //根据老师姓名查询所有课程
        IList<Course> FindCourseByTeacher(string teacherName);
        //根据班级号和讨论课号查找迟到学生
        IList<UserInfo> FindLateStudents(long seminarId, long classId);
        //根据班级号和讨论课号查找老师位置
        Location FindTeacherLocation(long classId, long seminarId);
        //插入attendance记录
        void AddAttendance(Attendance attendance);
    }
}
