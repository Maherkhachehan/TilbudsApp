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
    public class FirmasController : ApiController
    {
        private TilbudsAppContext db = new TilbudsAppContext();

        // GET: api/Firmas
        public IQueryable<Firma> GetFirma()
        {
            return db.Firma;
        }

        // GET: api/Firmas/5
        [ResponseType(typeof(Firma))]
        public IHttpActionResult GetFirma(int id)
        {
            Firma firma = db.Firma.Find(id);
            if (firma == null)
            {
                return NotFound();
            }

            return Ok(firma);
        }

        // PUT: api/Firmas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFirma(int id, Firma firma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != firma.Id)
            {
                return BadRequest();
            }

            db.Entry(firma).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FirmaExists(id))
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

        // POST: api/Firmas
        [ResponseType(typeof(Firma))]
        public IHttpActionResult PostFirma(Firma firma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Firma.Add(firma);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FirmaExists(firma.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = firma.Id }, firma);
        }

        // DELETE: api/Firmas/5
        [ResponseType(typeof(Firma))]
        public IHttpActionResult DeleteFirma(int id)
        {
            Firma firma = db.Firma.Find(id);
            if (firma == null)
            {
                return NotFound();
            }

            db.Firma.Remove(firma);
            db.SaveChanges();

            return Ok(firma);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FirmaExists(int id)
        {
            return db.Firma.Count(e => e.Id == id) > 0;
        }
    }
}