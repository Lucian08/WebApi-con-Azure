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
using WebApi.Models;

namespace WebApi.Controllers
{
    public class DiasController : ApiController
    {
        private ProyectoEntities db = new ProyectoEntities();

        // GET: api/Dias
        public IQueryable<Dias> GetDias()
        {
            return db.Dias;
        }

        // GET: api/Dias/5
        [ResponseType(typeof(Dias))]
        public IHttpActionResult GetDias(int id)
        {
            Dias dias = db.Dias.Find(id);
            if (dias == null)
            {
                return NotFound();
            }

            return Ok(dias);
        }

        // PUT: api/Dias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDias(int id, Dias dias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dias.Id)
            {
                return BadRequest();
            }

            db.Entry(dias).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiasExists(id))
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

        // POST: api/Dias
        [ResponseType(typeof(Dias))]
        public IHttpActionResult PostDias(Dias dias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Dias.Add(dias);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dias.Id }, dias);
        }

        // DELETE: api/Dias/5
        [ResponseType(typeof(Dias))]
        public IHttpActionResult DeleteDias(int id)
        {
            Dias dias = db.Dias.Find(id);
            if (dias == null)
            {
                return NotFound();
            }

            db.Dias.Remove(dias);
            db.SaveChanges();

            return Ok(dias);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DiasExists(int id)
        {
            return db.Dias.Count(e => e.Id == id) > 0;
        }
    }
}