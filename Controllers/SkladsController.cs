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
using Web_Api.Entities;
using Web_Api.Models;

namespace Web_Api.Controllers
{
    public class SkladsController : ApiController
    {
        private Inventarizacia_ob_VUZaEntities db = new Inventarizacia_ob_VUZaEntities();

        // GET: api/Sklads
        [ResponseType(typeof(List<ResponseSklad>))]

        public IHttpActionResult GetSklad()
        {
            return Ok(db.Sklad.ToList().ConvertAll(p => new ResponseSklad(p)));
        }

        // GET: api/Sklads/5
        [ResponseType(typeof(Sklad))]
        public IHttpActionResult GetSklad(int id)
        {
            Sklad sklad = db.Sklad.Find(id);
            if (sklad == null)
            {
                return NotFound();
            }

            return Ok(sklad);
        }

        // PUT: api/Sklads/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSklad(int id, Sklad sklad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sklad.ID_item)
            {
                return BadRequest();
            }

            db.Entry(sklad).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkladExists(id))
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

        // POST: api/Sklads
        [ResponseType(typeof(Sklad))]
        public IHttpActionResult PostSklad(Sklad sklad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sklad.Add(sklad);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sklad.ID_item }, sklad);
        }

        // DELETE: api/Sklads/5
        [ResponseType(typeof(Sklad))]
        public IHttpActionResult DeleteSklad(int id)
        {
            Sklad sklad = db.Sklad.Find(id);
            if (sklad == null)
            {
                return NotFound();
            }

            db.Sklad.Remove(sklad);
            db.SaveChanges();

            return Ok(sklad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SkladExists(int id)
        {
            return db.Sklad.Count(e => e.ID_item == id) > 0;
        }
    }
}