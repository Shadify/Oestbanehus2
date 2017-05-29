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
    [RoutePrefix("api/ConditionsOfItems")]
    public class ConditionsOfItemsController : ApiController
    {
        private Context db = new Context();

        // GET: api/ConditionsOfItems
        public IQueryable<ConditionsOfItem> GetConditionsOfItems()
        {
            return db.ConditionsOfItems;
        }

        // GET: api/ConditionsOfItems/5
        [Route("apartment/{id:int}")]
        public IQueryable<ConditionsOfItem> GetConditionsOfItem(int id)
        {
            var conditions = (from c in db.ConditionsOfItems
                               where c.ApartmentId == id
                               select c);

            return conditions;
        }

        // GET a condition with its comments
        [Route("{id:int}/comments")]
        public FUCKYOU GetCondition(int id)
        {
            var conditions = (from c in db.ConditionsOfItems
                              where id == c.Id join com in db.Comments on c.Id equals com.ConditionId into h
                              select new FUCKYOU {
                                  Id = c.Id,
                                  ApartmentId = c.ApartmentId,
                                  ConditionType = c.ConditionType,
                                  Description = c.Description,
                                  Picture = c.Picture,
                                  Status = c.Status,
                                  Comments = h
                              }
                               ).Single();

            return conditions;
        }

        // GET: api/ConditionsOfItems/5
        [ResponseType(typeof(ConditionsOfItem))]
        public IHttpActionResult GetConditionsOfApartment(int id)
        {
            ConditionsOfItem conditionsOfItem = db.ConditionsOfItems.Find(id);
            if (conditionsOfItem == null)
            {
                return NotFound();
            }

            return Ok(conditionsOfItem);
        }

        // PUT: api/ConditionsOfItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConditionsOfItem(int id, ConditionsOfItem conditionsOfItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != conditionsOfItem.Id)
            {
                return BadRequest();
            }

            db.Entry(conditionsOfItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConditionsOfItemExists(id))
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

        // POST: api/ConditionsOfItems
        [ResponseType(typeof(ConditionsOfItem))]
        public IHttpActionResult PostConditionsOfItem(ConditionsOfItem conditionsOfItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ConditionsOfItems.Add(conditionsOfItem);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                if (ConditionsOfItemExists(conditionsOfItem.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = conditionsOfItem.Id }, conditionsOfItem);
        }

        // DELETE: api/ConditionsOfItems/5
        [ResponseType(typeof(ConditionsOfItem))]
        public IHttpActionResult DeleteConditionsOfItem(int id)
        {
            ConditionsOfItem conditionsOfItem = db.ConditionsOfItems.Find(id);
            if (conditionsOfItem == null)
            {
                return NotFound();
            }

            db.ConditionsOfItems.Remove(conditionsOfItem);
            db.SaveChanges();

            return Ok(conditionsOfItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConditionsOfItemExists(int id)
        {
            return db.ConditionsOfItems.Count(e => e.Id == id) > 0;
        }
    }
}