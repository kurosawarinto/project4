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
    public class EmployeeController : ApiController
    {
        private Car4RentEntities db = new Car4RentEntities();

        // GET: api/Employee
        public IQueryable<employee> Getemployees()
        {
            return db.employees;
        }

        // GET: api/Employee/5
        [ResponseType(typeof(employee))]
        public IHttpActionResult Getemployee(int id)
        {
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employee/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putemployee(int id, employee employee)
        {


            if (id != employee.Employee_id)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!employeeExists(id))
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

        // POST: api/Employee
        [ResponseType(typeof(employee))]
        public IHttpActionResult Postemployee(employee employee)
        {
            

            db.employees.Add(employee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee.Employee_id }, employee);
        }

        // DELETE: api/Employee/5
        [ResponseType(typeof(employee))]
        public IHttpActionResult Deleteemployee(int id)
        {
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.employees.Remove(employee);
            db.SaveChanges();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool employeeExists(int id)
        {
            return db.employees.Count(e => e.Employee_id == id) > 0;
        }
    }
}