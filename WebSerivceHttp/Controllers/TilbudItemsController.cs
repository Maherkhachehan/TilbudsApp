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
    public class TilbudItemsController : ApiController
    {
        private TilbudsAppContext db = new TilbudsAppContext();

        // GET: api/TilbudItems
        public IQueryable<TilbudItem> GetTilbudItem()
        {
            return db.TilbudItem;
        }

        // GET: api/TilbudItems/5
        [ResponseType(typeof(TilbudItem))]
        public IHttpActionResult GetTilbudItem(int id)
        {
            TilbudItem tilbudItem = db.TilbudItem.Find(id);
            if (tilbudItem == null)
            {
                return NotFound();
            }

            return Ok(tilbudItem);
        }

        // PUT: api/TilbudItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTilbudItem(int id, TilbudItem tilbudItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tilbudItem.Id)
            {
                return BadRequest();
            }

            db.Entry(tilbudItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TilbudItemExists(id))
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

        // POST: api/TilbudItems
        [ResponseType(typeof(TilbudItem))]
        public IHttpActionResult PostTilbudItem(TilbudItem tilbudItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TilbudItem.Add(tilbudItem);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TilbudItemExists(tilbudItem.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tilbudItem.Id }, tilbudItem);
        }

        // DELETE: api/TilbudItems/5
        [ResponseType(typeof(TilbudItem))]
        public IHttpActionResult DeleteTilbudItem(int id)
        {
            TilbudItem tilbudItem = db.TilbudItem.Find(id);
            if (tilbudItem == null)
            {
                return NotFound();
            }

            db.TilbudItem.Remove(tilbudItem);
            db.SaveChanges();

            return Ok(tilbudItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TilbudItemExists(int id)
        {
            return db.TilbudItem.Count(e => e.Id == id) > 0;
        }
    }
}