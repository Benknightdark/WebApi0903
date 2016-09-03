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
using WebApi0903.Models;

namespace WebApi0903.Controllers
{
    [RoutePrefix("clients")]
    public class ClientsController : ApiController
    {
        private FabricsEntities db = new FabricsEntities();

        public ClientsController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        [Route("")]
        public IQueryable<Client> GetClient()
        {
            return db.Client;
        }

        [Route("{id:int}")]
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetClient(int id)
        {
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [Route("{id:int}/orders")]
        public IHttpActionResult GetClientOrder(int id)
        {
            var order = db.Order.Where(p => p.ClientId == id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [Route("{id:int}/orders/{*date:datetime}")]
        public IHttpActionResult GetClientOrderByDate(int id, DateTime date)
        {
            var order = db.Order.Where(p => p.ClientId == id
                && p.OrderDate.Value.Year == date.Year
                && p.OrderDate.Value.Month == date.Month
                && p.OrderDate.Value.Day == date.Day);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.Client.Count(e => e.ClientId == id) > 0;
        }
    }
}