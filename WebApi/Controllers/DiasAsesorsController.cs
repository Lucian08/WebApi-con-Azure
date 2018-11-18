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
    public class DiasAsesorsController : ApiController
    {
        private ProyectoEntities db = new ProyectoEntities();

        // GET: api/DiasAsesors
        public IQueryable<DiasAsesor> GetDiasAsesor()
        {
            return db.DiasAsesor;
        }

        // GET: api/DiasAsesors/5
        [ResponseType(typeof(DiasAsesor))]
        public IHttpActionResult GetDiasAsesor(int id)
        {
            DiasAsesor diasAsesor = db.DiasAsesor.Find(id);
            if (diasAsesor == null)
            {
                return NotFound();
            }

            return Ok(diasAsesor);
        }

        // PUT: api/DiasAsesors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDiasAsesor(int id, DiasAsesor diasAsesor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != diasAsesor.Id)
            {
                return BadRequest();
            }

            db.Entry(diasAsesor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiasAsesorExists(id))
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

        // POST: api/DiasAsesors
        [ResponseType(typeof(DiasAsesor))]
        public IHttpActionResult PostDiasAsesor(DiasAsesor diasAsesor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DiasAsesor.Add(diasAsesor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = diasAsesor.Id }, diasAsesor);
        }

        // DELETE: api/DiasAsesors/5
        [ResponseType(typeof(DiasAsesor))]
        public IHttpActionResult DeleteDiasAsesor(int id)
        {
            DiasAsesor diasAsesor = db.DiasAsesor.Find(id);
            if (diasAsesor == null)
            {
                return NotFound();
            }

            db.DiasAsesor.Remove(diasAsesor);
            db.SaveChanges();

            return Ok(diasAsesor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DiasAsesorExists(int id)
        {
            return db.DiasAsesor.Count(e => e.Id == id) > 0;
        }
    }
}