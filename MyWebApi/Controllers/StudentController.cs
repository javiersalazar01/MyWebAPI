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
using MyWebApi.Models;
using MyWebApi.Models.Custom;

namespace MyWebApi.Controllers
{
    public class StudentController : ApiController
    {
        private TCADataBaseEntities db = new TCADataBaseEntities();

        // GET: api/Student
        public IQueryable<StudentModel> GetSTUDENTs()
        {
            return db.STUDENTs.Select(s => new StudentModel()
            {
                student_id = s.student_id,
                last_name = s.last_name,
                middle_name = s.middle_name,
                first_name = s.first_name,
                gender = s.gender,
                create_on = s.create_on,
                update_on = s.update_on

            });
        }

        // GET: api/Student/5
        [ResponseType(typeof(StudentModel))]
        public IHttpActionResult GetSTUDENT(int id)
        {
            STUDENT sTUDENT = db.STUDENTs.Find(id);
            if (sTUDENT == null)
            {
                return NotFound();
            }

            StudentModel model = new StudentModel()
            {
                student_id = sTUDENT.student_id,
                last_name = sTUDENT.last_name,
                middle_name = sTUDENT.middle_name,
                first_name = sTUDENT.first_name,
                gender = sTUDENT.gender,
                create_on = sTUDENT.create_on,
                update_on = sTUDENT.update_on
            };

            return Ok(model);
        }

        // PUT: api/Student/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSTUDENT(int id, STUDENT sTUDENT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sTUDENT.student_id)
            {
                return BadRequest();
            }

            db.Entry(sTUDENT).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!STUDENTExists(id))
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

        // POST: api/Student
        [ResponseType(typeof(STUDENT))]
        public IHttpActionResult PostSTUDENT(STUDENT sTUDENT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.STUDENTs.Add(sTUDENT);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sTUDENT.student_id }, sTUDENT);
        }

        // DELETE: api/Student/5
        [ResponseType(typeof(STUDENT))]
        public IHttpActionResult DeleteSTUDENT(int id)
        {
            STUDENT sTUDENT = db.STUDENTs.Find(id);
            if (sTUDENT == null)
            {
                return NotFound();
            }

            db.STUDENTs.Remove(sTUDENT);
            db.SaveChanges();

            return Ok(sTUDENT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool STUDENTExists(int id)
        {
            return db.STUDENTs.Count(e => e.student_id == id) > 0;
        }
    }
}