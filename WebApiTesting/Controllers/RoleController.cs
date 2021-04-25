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
    public class RoleController : ApiController
    {
        private IRoles _db;

        public RoleController()
        {
            this._db = new RoleDb(new TestingContext());
        }

        // GET: api/Role
        public List<Role> GetRole()
        {
            return _db.GetRoles();
        }

        // GET: api/Role/5
        [ResponseType(typeof(Role))]
        public IHttpActionResult GetRole(int id)
        {
            Role role = _db.GetRole(id);
            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        // PUT: api/Role/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRole(int id, Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != role.Id)
            {
                return BadRequest();
            }

            _db.EditRole(role);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Role
        [ResponseType(typeof(Role))]
        public IHttpActionResult PostRole(Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.AddRole(role);

            return CreatedAtRoute("DefaultApi", new { id = role.Id }, role);
        }

        // DELETE: api/Role/5
        [ResponseType(typeof(Role))]
        public IHttpActionResult DeleteRole(int id)
        {
            Role role = _db.GetRole(id);
            if (role == null)
            {
                return NotFound();
            }

            _db.DeleteRoleByRole(role);

            return Ok(role);
        }

    }
}