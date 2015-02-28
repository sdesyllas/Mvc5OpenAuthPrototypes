using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OpenAuthPrototype.Models;

namespace OpenAuthPrototype.DAL
{
    public class AchievementContext : DbContext
    {
        public AchievementContext() : base("DefaultConnection")
        {
        }

        public DbSet<Achievement> Achievements { get; set; }
    }
}