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
    public class AsesorsController : ApiController
    {
        private ProyectoEntities db = new ProyectoEntities();

        // GET: api/Asesors
        public IQueryable<Asesor> GetAsesor()
        {
            return db.Asesor;
        }

        // GET: api/Asesors/5
        [ResponseType(typeof(Asesor))]
        public IHttpActionResult GetAsesor(int id)
        {
            Asesor asesor = db.Asesor.Find(id);
            if (asesor == null)
            {
                return NotFound();
            }

            return Ok(asesor);
        }

        // PUT: api/Asesors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAsesor(int id, Asesor asesor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != asesor.Id)
            {
                return BadRequest();
            }

            db.Entry(asesor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsesorExists(id))
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

        // POST: api/Asesors
        [ResponseType(typeof(Asesor))]
        public IHttpActionResult PostAsesor(Asesor asesor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Asesor.Add(asesor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = asesor.Id }, asesor);
        }

        // DELETE: api/Asesors/5
        [ResponseType(typeof(Asesor))]
        public IHttpActionResult DeleteAsesor(int id)
        {
            Asesor asesor = db.Asesor.Find(id);
            if (asesor == null)
            {
                return NotFound();
            }

            db.Asesor.Remove(asesor);
            db.SaveChanges();

            return Ok(asesor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AsesorExists(int id)
        {
            return db.Asesor.Count(e => e.Id == id) > 0;
        }
    }
}