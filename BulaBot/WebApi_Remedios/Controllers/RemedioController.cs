using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_Remedios.Models;

namespace WebApi_Remedios.Controllers
{
    public class RemedioController : ApiController
    {
        static readonly IRemedioRepositorio repositorio = new RemedioRepositorio();

        public IEnumerable<Remedio> GetAllRemedios()
        {
            return repositorio.GetAll();
        }

        public Remedio GetRemedio(int id)
        {
            Remedio item = repositorio.Get(id);
            if(item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<Remedio> GetRemedioPorNome(string nome)
        {
            //return repositorio.GetAll().Where(
            //    r => string.Equals(r.Nome, nome, StringComparison.OrdinalIgnoreCase));
            return repositorio.GetAll().Where(
                r => r.Nome.ToUpper().Contains(nome.ToUpper()));
        }

        public HttpResponseMessage PostRemedio(Remedio item)
        {
            item = repositorio.Add(item);
            var response = Request.CreateResponse<Remedio>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutRemedio(int id, Remedio remedio)
        {
            remedio.Id = id;
            if (!repositorio.Update(remedio))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteRemedio(int id)
        {
            Remedio item = repositorio.Get(id);
            if(item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repositorio.Remove(id);
        }
    }
}
