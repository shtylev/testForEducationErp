using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testForEducationErp.Models;

namespace testForEducationErp.DAL
{
    public static class Films
    {
        public static List<Film> GetFilms(string filterTitle, int? filterYearStart, int? filterYearEnd, string filterProducer)
        {
            return Config.db.Films.Where(f => (string.IsNullOrEmpty(filterTitle) || f.Title.ToLower().Contains(filterTitle)) &&
                (filterYearStart == null || filterYearStart == 0 || f.YearRelease >= filterYearStart) &&
                (filterYearEnd == null || filterYearEnd == 0 || f.YearRelease <= filterYearEnd) &&
                (string.IsNullOrEmpty(filterProducer) || f.Producer.ToLower().Contains(filterProducer))).ToList();
        }
        public static Film GetFilmByID(int id)
        {
            return Config.db.Films.Where(f => f.Id == id).FirstOrDefault();
        }
    }
}