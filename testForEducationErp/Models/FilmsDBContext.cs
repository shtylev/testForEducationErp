using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web;

namespace testForEducationErp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Film> Films { get; set; } = new List<Film>();
        public ApplicationUser()
        {
        }
    }

    public class FilmsDBContext : IdentityDbContext<ApplicationUser>
    {
        public FilmsDBContext() : base("DefaultConnection") { }
        public DbSet<Film> Films { get; set; }

        public static FilmsDBContext Create()
        {
            return new FilmsDBContext();
        }
    }
}