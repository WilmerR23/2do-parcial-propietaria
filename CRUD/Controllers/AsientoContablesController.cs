﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class AsientoContablesController : ApiController
    {
        private Context db = new Context();

        // GET: api/AsientoContables
        public IQueryable<AsientoContable> GetAsientoContable()
        {
            return db.AsientoContable;
        }

        // GET: api/AsientoContables/5
        [ResponseType(typeof(AsientoContable))]
        public IHttpActionResult GetAsientoContable(int id)
        {
            AsientoContable asientoContable = db.AsientoContable.Find(id);
            if (asientoContable == null)
            {
                return NotFound();
            }

            return Ok(asientoContable);
        }

        // PUT: api/AsientoContables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAsientoContable(int id, AsientoContable asientoContable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != asientoContable.Id)
            {
                return BadRequest();
            }

            db.Entry(asientoContable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsientoContableExists(id))
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

        // POST: api/AsientoContables
        [ResponseType(typeof(AsientoContable))]
        public IHttpActionResult PostAsientoContable(AsientoContable asientoContable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AsientoContable.Add(asientoContable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = asientoContable.Id }, asientoContable);
        }

        // DELETE: api/AsientoContables/5
        [ResponseType(typeof(AsientoContable))]
        public IHttpActionResult DeleteAsientoContable(int id)
        {
            AsientoContable asientoContable = db.AsientoContable.Find(id);
            if (asientoContable == null)
            {
                return NotFound();
            }

            db.AsientoContable.Remove(asientoContable);
            db.SaveChanges();

            return Ok(asientoContable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AsientoContableExists(int id)
        {
            return db.AsientoContable.Count(e => e.Id == id) > 0;
        }
    }
}