using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    [RoutePrefix("api/Buildings")]
    public class BuildingsController : ApiController
    {
        private Context db = new Context();

        // GET: api/Buildings
        public IQueryable<BuildingWithCity> GetBuildings()
        {
            var buildings = (from ep in db.Buildings
                             join e in db.Cities on ep.ZipCode.ToString() equals e.ZipCode.ToString()
                             select new BuildingWithCity
                             {
                                 Id = ep.Id,
                                 Street = ep.Street,
                                 ZipCode = ep.ZipCode,
                                 City = e.City1
                             });
            return buildings;
        }


        [Route("conditions")]
        public IQueryable<BuildingConditions> GetBuildingsWithConditions()
        {
            var apwc = (from ap in db.Apartments
                             join c in db.ConditionsOfItems on ap.Id equals c.ApartmentId select new ApartmentWithConditions
                             {
                                 Id = ap.Id,
                                 BuildingId = ap.BuildingId,
                                 Size = ap.Size,
                                 Price = ap.Price,
                                 NumberOfRooms = ap.NumberOfRooms,
                                 Floor = ap.Floor,
                                 ApartmentNumber = ap.ApartmentNumber,
                                 Street = ap.Street,
                                 ConditionsOfItems = ap.ConditionsOfItems
                             });

           var result = (from b in db.Buildings
            join a in apwc on b.Id equals a.BuildingId into bac
            from p in bac 
            join c in db.Cities on b.ZipCode equals c.ZipCode
            select new BuildingConditions
            {
                Id = b.Id,
                Street = b.Street,
                ZipCode = b.ZipCode,
                City = c.City1,
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

        // GET: api/Buildings/5
        [ResponseType(typeof(Building))]
        public IHttpActionResult GetBuilding(int id)
        {
            Building building = db.Buildings.Find(id);
            if (building == null)
            {
                return NotFound();
            }

            return Ok(building);
        }

        // PUT: api/Buildings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBuilding(int id, Building building)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != building.Id)
            {
                return BadRequest();
            }

            db.Entry(building).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildingExists(id))
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

        // POST: api/Buildings
        [ResponseType(typeof(Building))]
        public IHttpActionResult PostBuilding(Building building)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Buildings.Add(building);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BuildingExists(building.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = building.Id }, building);
        }

        // DELETE: api/Buildings/5
        [ResponseType(typeof(Building))]
        public IHttpActionResult DeleteBuilding(int id)
        {
            Building building = db.Buildings.Find(id);
            if (building == null)
            {
                return NotFound();
            }

            db.Buildings.Remove(building);
            db.SaveChanges();

            return Ok(building);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BuildingExists(int id)
        {
            return db.Buildings.Count(e => e.Id == id) > 0;
        }
    }
}