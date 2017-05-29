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
using WebApi.Models.WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Requests")]
    public class RequestsController : ApiController
    {
        private Context db = new Context();

        // GET: api/Requests
        public IQueryable<Request> GetRequests()
        {
            return db.Requests;
        }

        [Route("apartment/{id:int}")]
        public IQueryable<Request> GetConditionsOfItem(int id)
        {
            var conditions = (from c in db.Requests
                              where c.ApartmentId == id
                              select c);

            return conditions;
        }

        //RETURN ALL BUILDINGS WITH REQUESTS
        [Route("Buildings")]
        public IQueryable<BuildingRequests> GetBuildingsWithRequests()
        {
            var apwc = (from ap in db.Apartments
                        join r in db.Requests on ap.Id equals r.ApartmentId
                        select new ApartmentWithRequests
                        {
                            Id = ap.Id,
                            BuildingId = ap.BuildingId,
                            Size = ap.Size,
                            Price = ap.Price,
                            NumberOfRooms = ap.NumberOfRooms,
                            Floor = ap.Floor,
                            ApartmentNumber = ap.ApartmentNumber,
                            Street = ap.Street,
                            Requests = ap.Requests
                        });

            var result = (from b in db.Buildings
                          join a in apwc on b.Id equals a.BuildingId into bac
                          from p in bac
                          join c in db.Cities on b.ZipCode equals c.ZipCode
                          select new BuildingRequests
                          {
                              Id = b.Id,
                              Street = b.Street,
                              ZipCode = b.ZipCode,
                              City = c.City1
                          }).ToList();

            for (int i = 0; i < result.Count(); i++)
            {
                foreach (var item2 in apwc)
                {
                    if (result.ElementAt(i).Id.ToString() == item2.BuildingId.ToString())
                    {
                        result.ElementAt(i).Apartments.Add(item2);
                    }
                }
            }
            return result.AsQueryable();
        }

        //Get request with comments
        [HttpGet]
        [Route("{id:int}/details")]
        public DetailRequest detailedRequest(int id)
        {
            var request = (from c in db.Requests
                              where id == c.Id
                              join com in db.Persons on c.AuthorId equals com.Id into h
                              select new DetailRequest
                              {
                                  Id = c.Id,
                                  AuthorId = c.AuthorId,
                                  Description = c.Description,
                                  Title = c.Title,
                                  Picture = c.Picture,
                                  Date = c.Date,
                                  Person = c.Person
                              }
                               ).Single();

            return request;
        }

        // GET: api/Requests/5
        [ResponseType(typeof(Request))]
        public IHttpActionResult GetRequest(int id)
        {
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return NotFound();
            }

            return Ok(request);
        }

        // PUT: api/Requests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRequest(int id, Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != request.Id)
            {
                return BadRequest();
            }

            db.Entry(request).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
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

        // POST: api/Requests
        [ResponseType(typeof(Request))]
        public IHttpActionResult PostRequest(Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Requests.Add(request);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                if (RequestExists(request.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = request.Id }, request);
        }

        // DELETE: api/Requests/5
        [ResponseType(typeof(Request))]
        public IHttpActionResult DeleteRequest(int id)
        {
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return NotFound();
            }

            db.Requests.Remove(request);
            db.SaveChanges();

            return Ok(request);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestExists(int id)
        {
            return db.Requests.Count(e => e.Id == id) > 0;
        }
    }
}