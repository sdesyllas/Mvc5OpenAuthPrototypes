﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using OpenAuthPrototype.DAL;
using OpenAuthPrototype.Models;

namespace OpenAuthPrototype.Controllers
{
    public class AchievementsController : ApiController
    {
        private AchievementContext db = new AchievementContext();

        // GET: api/Achievements
        public IQueryable<Achievement> GetAchievements()
        {
            return db.Achievements.Take(10).OrderByDescending(x=>x.DateCreated);
        }

        // GET: api/Achievements/5
        [ResponseType(typeof(Achievement))]
        public IHttpActionResult GetAchievement(int id)
        {
            Achievement achievement = db.Achievements.Find(id);
            if (achievement == null)
            {
                return NotFound();
            }

            return Ok(achievement);
        }

        // PUT: api/Achievements/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAchievement(int id, Achievement achievement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != achievement.ID)
            {
                return BadRequest();
            }

            db.Entry(achievement).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AchievementExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Achievements
        [ResponseType(typeof(Achievement))]
        public IHttpActionResult PostAchievement(Achievement achievement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Achievements.Add(achievement);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = achievement.ID }, achievement);
        }

        // DELETE: api/Achievements/5
        [ResponseType(typeof(Achievement))]
        public IHttpActionResult DeleteAchievement(int id)
        {
            Achievement achievement = db.Achievements.Find(id);
            if (achievement == null)
            {
                return NotFound();
            }

            db.Achievements.Remove(achievement);
            db.SaveChanges();

            return Ok(achievement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AchievementExists(int id)
        {
            return db.Achievements.Count(e => e.ID == id) > 0;
        }
    }
}