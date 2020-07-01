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
using Universidad_Libardo_Torres.Models;

namespace Universidad_Libardo_Torres.Controllers
{
    public class autoresController : ApiController
    {
        private bibliotecaEntities1 db = new bibliotecaEntities1();

        // GET: api/autores
        public IQueryable<autores> Getautores()
        {
            return db.autores;
        }

        // GET: api/autores/5
        [ResponseType(typeof(autores))]
        public IHttpActionResult Getautores(int id)
        {
            autores autores = db.autores.Find(id);
            if (autores == null)
            {
                return NotFound();
            }

            return Ok(autores);
        }

        // PUT: api/autores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putautores(int id, autores autores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != autores.autor_id)
            {
                return BadRequest();
            }

            db.Entry(autores).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!autoresExists(id))
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

        // POST: api/autores
        [ResponseType(typeof(autores))]
        public IHttpActionResult Postautores(autores autores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.autores.Add(autores);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = autores.autor_id }, autores);
        }

        // DELETE: api/autores/5
        [ResponseType(typeof(autores))]
        public IHttpActionResult Deleteautores(int id)
        {
            autores autores = db.autores.Find(id);
            if (autores == null)
            {
                return NotFound();
            }

            db.autores.Remove(autores);
            db.SaveChanges();

            return Ok(autores);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool autoresExists(int id)
        {
            return db.autores.Count(e => e.autor_id == id) > 0;
        }
    }
}