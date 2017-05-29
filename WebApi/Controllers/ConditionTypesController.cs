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
    public class ConditionTypesController : ApiController
    {
        private Context db = new Context();

        // GET: api/ConditionTypes
        public IQueryable<ConditionType> GetConditionTypes()
        {
            return db.ConditionTypes;
        }

        // GET: api/ConditionTypes/5
        [ResponseType(typeof(ConditionType))]
        public IHttpActionResult GetConditionType(int id)
        {
            ConditionType conditionType = db.ConditionTypes.Find(id);
            if (conditionType == null)
            {
                return NotFound();
            }

            return Ok(conditionType);
        }

        // PUT: api/ConditionTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConditionType(int id, ConditionType conditionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != conditionType.Id)
            {
                return BadRequest();
            }

            db.Entry(conditionType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConditionTypeExists(id))
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

        // POST: api/ConditionTypes
        [ResponseType(typeof(ConditionType))]
        public IHttpActionResult PostConditionType(ConditionType conditionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ConditionTypes.Add(conditionType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ConditionTypeExists(conditionType.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = conditionType.Id }, conditionType);
        }

        // DELETE: api/ConditionTypes/5
        [ResponseType(typeof(ConditionType))]
        public IHttpActionResult DeleteConditionType(int id)
        {
            ConditionType conditionType = db.ConditionTypes.Find(id);
            if (conditionType == null)
            {
                return NotFound();
            }

            db.ConditionTypes.Remove(conditionType);
            db.SaveChanges();

            return Ok(conditionType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConditionTypeExists(int id)
        {
            return db.ConditionTypes.Count(e => e.Id == id) > 0;
        }
    }
}