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
using WebSerivceHttp;

namespace WebSerivceHttp.Controllers
{
    public class ByersController : ApiController
    {
        private TilbudsAppContext db = new TilbudsAppContext();

        // GET: api/Byers
        public IQueryable<Byer> GetByer()
        {
            return db.Byer;
        }

        // GET: api/Byers/5
        [ResponseType(typeof(Byer))]
        public IHttpActionResult GetByer(int id)
        {
            Byer byer = db.Byer.Find(id);
            if (byer == null)
            {
                return NotFound();
            }

            return Ok(byer);
        }

        // PUT: api/Byers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutByer(int id, Byer byer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != byer.Id)
            {
                return BadRequest();
            }

            db.Entry(byer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ByerExists(id))
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

        // POST: api/Byers
        [ResponseType(typeof(Byer))]
        public IHttpActionResult PostByer(Byer byer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Byer.Add(byer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ByerExists(byer.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = byer.Id }, byer);
        }

        // DELETE: api/Byers/5
        [ResponseType(typeof(Byer))]
        public IHttpActionResult DeleteByer(int id)
        {
            Byer byer = db.Byer.Find(id);
            if (byer == null)
            {
                return NotFound();
            }

            db.Byer.Remove(byer);
            db.SaveChanges();

            return Ok(byer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ByerExists(int id)
        {
            return db.Byer.Count(e => e.Id == id) > 0;
        }
    }
}