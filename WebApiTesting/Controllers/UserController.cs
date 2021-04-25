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
using WebApiTesting.Models;
using WebApiTesting.Services;

namespace WebApiTesting.Controllers
{
    public class UserController : ApiController
    {
        private IUsers _db;

        public UserController()
        {
            this._db = new UserDb(new TestingContext());
        }

       
        public List<User> GetUser()
        {
            return _db.GetUsers();
        }

        // GET: api/User/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = _db.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/User/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            _db.EditUser(user);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/User
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.AddUser(user);

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/User/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = _db.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            _db.DeleteUserByUser(user);

            return Ok(user);
        }

    }
}