using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Class;

namespace Api.Controllers
{
    public class ControladorPrincipal : ApiController
    {
        // GET: api/ControladorPrincipal
        public IEnumerable<Persona_Jorge> Get()
        {
            using (practicantesEntities1 db = new practicantesEntities1())
            {
                return db.Persona_Jorge.ToList();
            }
        }

        // GET: api/ControladorPrincipal/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ControladorPrincipal
        public HttpResponseMessage Post([FromBody]Persona_Jorge Insertar)
        {
            int resp = 0;
            HttpResponseMessage msj = null;
            try
            {
                using (practicantesEntities1 entities = new practicantesEntities1())
                {
                    entities.Entry(Insertar).State = System.Data.Entity.EntityState.Added;
                    resp = entities.SaveChanges();
                    msj = Request.CreateResponse(HttpStatusCode.OK, resp);
                }
            }
            catch (Exception exe)
            {
                msj = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exe.Message);
            }
            return msj;
        }

        // PUT: api/ControladorPrincipal/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ControladorPrincipal/5
        public void Delete(int id)
        {
        }
    }
}
