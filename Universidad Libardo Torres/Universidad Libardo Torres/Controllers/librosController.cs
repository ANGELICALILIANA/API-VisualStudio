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
    public class librosController : ApiController
    {
        private bibliotecaEntities1 db = new bibliotecaEntities1();

        // GET: api/libros
        public IQueryable<libros> Getlibros()
        {
            return db.libros;
        }

        // GET: api/libros/5
        [ResponseType(typeof(libros))]
        public IHttpActionResult Getlibros(int id)
        {
            libros libros = db.libros.Find(id);
            if (libros == null)
            {
                return NotFound();
            }

            return Ok(libros);
        }

        // PUT: api/libros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putlibros(int id, libros libros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != libros.libro_id)
            {
                return BadRequest();
            }

            db.Entry(libros).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!librosExists(id))
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

        // POST: api/libros
        [ResponseType(typeof(libros))]
        public IHttpActionResult Postlibros(libros libros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.libros.Add(libros);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = libros.libro_id }, libros);
        }

        // DELETE: api/libros/5
        [ResponseType(typeof(libros))]
        public IHttpActionResult Deletelibros(int id)
        {
            libros libros = db.libros.Find(id);
            if (libros == null)
            {
                return NotFound();
            }

            db.libros.Remove(libros);
            db.SaveChanges();

            return Ok(libros);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool librosExists(int id)
        {
            return db.libros.Count(e => e.libro_id == id) > 0;
        }
    }
}