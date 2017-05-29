using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/People")]
    public class PeopleController : ApiController
    {
        private Context db = new Context();

        // GET: api/People
        public IQueryable<Person> GetPersons()
        {
            return db.Persons;
        }

        [Route("{id:int}/details")]
        public IQueryable<PersonWithDetails> GetPersonDetails(int id)
        {
            var person = (from c in db.Persons
                          where c.Id == id
                          join a in db.Apartments on c.ApartmentId equals a.Id into personDetails
                          from pd in personDetails
                          join b in db.Buildings on pd.BuildingId equals b.Id into apartmentOwnerBuilding
                          from aob in apartmentOwnerBuilding
                          join ad in db.Cities on aob.ZipCode equals ad.ZipCode
                          select new PersonWithDetails
                          {
                              Id = c.Id,
                              MoveInDate = c.MoveInDate.ToString(),
                              MoveOutDate = c.MoveOutDate.ToString(),
                              Name = c.Name,
                              Phone = c.Phone,
                              Email = c.Email,
                              apartment = pd,
                              City = aob.City.City1,
                              ZipCode = aob.ZipCode
                          });

            return person;
        }

        // GET: api/People/5
        [ResponseType(typeof(Person))]
        public IHttpActionResult GetPerson(int id)
        {
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }



        // PUT: api/People/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerson(int id, Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.Id)
            {
                return BadRequest();
            }

            db.Entry(person).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // POST: api/People
        
        [Route("add")]
        public IHttpActionResult PostPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Persons.Add(person);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PersonExists(person.Id))
                {
                    return Conflict();

                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = person.Id }, person);
        }

        // POST: LOGIN
        [HttpPost]
        [Route("login")]
        public IHttpActionResult LoginPerson(Person log)
        {

            var foundPerson = (from p in db.Persons where p.Email == log.Email select p).Single();

            if (foundPerson != null)
            {
                if(foundPerson.Password == log.Password)
                {
                    return Ok(foundPerson);
                } else
                {
                    return NotFound();
                }
            } else
            {
                return NotFound();
            } 
        }


        // DELETE: api/People/5
        [ResponseType(typeof(Person))]
        public IHttpActionResult DeletePerson(int id)
        {
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return NotFound();
            }

            db.Persons.Remove(person);
            db.SaveChanges();

            return Ok(person);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonExists(int id)
        {
            return db.Persons.Count(e => e.Id == id) > 0;
        }
    }
}