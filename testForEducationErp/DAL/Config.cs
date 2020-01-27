using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testForEducationErp.Models;

namespace testForEducationErp.DAL
{
    public sealed class Config
    {
        static FilmsDBContext _db;
        public static FilmsDBContext db
        {
            get
            {
                if (_db == null)
                    return _db = new FilmsDBContext();
                else
                    return _db;
            }
        }
    }
}