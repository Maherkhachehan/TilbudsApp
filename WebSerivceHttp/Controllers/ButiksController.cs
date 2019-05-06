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
    public class ButiksController : ApiController
    {
        private TilbudsAppContext db = new TilbudsAppContext();

        // GET: api/Butiks
        public IQueryable<Butik> GetButik()
        {
            return db.Butik;
        }

        // GET: api/Butiks/5
        [ResponseType(typeof(Butik))]
        public IHttpActionResult GetButik(int id)
        {
            Butik butik = db.Butik.Find(id);
            if (butik == null)
            {
                return NotFound();
            }

            return Ok(butik);
        }

        // PUT: api/Butiks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutButik(int id, Butik butik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != butik.Id)
            {
                return BadRequest();
            }

            db.Entry(butik).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ButikExists(id))
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

        // POST: api/Butiks
        [ResponseType(typeof(Butik))]
        public IHttpActionResult PostButik(Butik butik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Butik.Add(butik);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = butik.Id }, butik);
        }

        // DELETE: api/Butiks/5
        [ResponseType(typeof(Butik))]
        public IHttpActionResult DeleteButik(int id)
        {
            Butik butik = db.Butik.Find(id);
            if (butik == null)
            {
                return NotFound();
            }

            db.Butik.Remove(butik);
            db.SaveChanges();

            return Ok(butik);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ButikExists(int id)
        {
            return db.Butik.Count(e => e.Id == id) > 0;
        }
    }
}