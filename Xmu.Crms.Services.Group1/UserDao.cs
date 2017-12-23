using System;
using System.Collections.Generic;
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
    }
}
