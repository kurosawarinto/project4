using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Car4Rent.Models;

namespace Car4Rent.Controllers
{
    public class RoleController : ApiController
    {
        private Car4RentEntities db = new Car4RentEntities();

        // GET: api/Role
        public IQueryable<role> Getroles()
        {
            return db.roles;
        }

        // GET: api/Role/5
        [ResponseType(typeof(role))]
        public IHttpActionResult Getrole(int id)
        {
            role role = db.roles.Find(id);
            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        // PUT: api/Role/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putrole(int id, role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != role.Role_id)
            {
                return BadRequest();
            }

            db.Entry(role).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!roleExists(id))
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

        // POST: api/Role
        [ResponseType(typeof(role))]
        public IHttpActionResult Postrole(role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.roles.Add(role);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = role.Role_id }, role);
        }

        // DELETE: api/Role/5
        [ResponseType(typeof(role))]
        public IHttpActionResult Deleterole(int id)
        {
            role role = db.roles.Find(id);
            if (role == null)
            {
                return NotFound();
            }

            db.roles.Remove(role);
            db.SaveChanges();

            return Ok(role);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool roleExists(int id)
        {
            return db.roles.Count(e => e.Role_id == id) > 0;
        }
    }
}