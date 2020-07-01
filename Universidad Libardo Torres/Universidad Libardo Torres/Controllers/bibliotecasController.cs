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
    public class bibliotecasController : ApiController
    {
        private bibliotecaEntities1 db = new bibliotecaEntities1();

        // GET: api/bibliotecas
        public IQueryable<bibliotecas> Getbibliotecas()
        {
            return db.bibliotecas;
        }

        // GET: api/bibliotecas/5
        [ResponseType(typeof(bibliotecas))]
        public IHttpActionResult Getbibliotecas(int id)
        {
            bibliotecas bibliotecas = db.bibliotecas.Find(id);
            if (bibliotecas == null)
            {
                return NotFound();
            }

            return Ok(bibliotecas);
        }

        // PUT: api/bibliotecas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putbibliotecas(int id, bibliotecas bibliotecas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bibliotecas.biblioteca_id)
            {
                return BadRequest();
            }

            db.Entry(bibliotecas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!bibliotecasExists(id))
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

        // POST: api/bibliotecas
        [ResponseType(typeof(bibliotecas))]
        public IHttpActionResult Postbibliotecas(bibliotecas bibliotecas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.bibliotecas.Add(bibliotecas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bibliotecas.biblioteca_id }, bibliotecas);
        }

        // DELETE: api/bibliotecas/5
        [ResponseType(typeof(bibliotecas))]
        public IHttpActionResult Deletebibliotecas(int id)
        {
            bibliotecas bibliotecas = db.bibliotecas.Find(id);
            if (bibliotecas == null)
            {
                return NotFound();
            }

            db.bibliotecas.Remove(bibliotecas);
            db.SaveChanges();

            return Ok(bibliotecas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool bibliotecasExists(int id)
        {
            return db.bibliotecas.Count(e => e.biblioteca_id == id) > 0;
        }
    }
}