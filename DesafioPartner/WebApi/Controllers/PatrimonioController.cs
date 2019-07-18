using System.Web.Http;
using System.Net.Http;
using System.Net;
using System;
using Dados;
using Models.Interfaces;
using Models;

namespace WebApiCliente.Controllers
{
    public class PatrimonioController : ApiController
    {
        private readonly IPatrimonioRepository _patrimonioRepository;
        public PatrimonioController()
        {
            _patrimonioRepository = new PatrimonioRepository();
        }

        // GET: api/Patrimonio
        [HttpGet]
        [Route("api/Patrimonio/GetPatrimonios")]
        public HttpResponseMessage Get()
        {
            try
            {
                var listarPatrimonios = _patrimonioRepository.GetPatrimonios();
                return Request.CreateResponse(HttpStatusCode.OK, listarPatrimonios, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message, "application/json");
            }
        }

        // GET: api/Patrimonio/5
        [HttpGet]
        [Route("api/Patrimonio/GetPatrimonioById/{id}")]
        public HttpResponseMessage Get(Int64 id)
        {
            try
            {
                var patrimonio = _patrimonioRepository.GetPatrimonio(id);
                return Request.CreateResponse(HttpStatusCode.OK, patrimonio, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message, "application/json");
            }
        }

        // POST: api/Patrimonio
        [HttpPost]
        [Route("api/Patrimonio/Insert")]
        public HttpResponseMessage Post([FromBody] Patrimonio patrimonio)
        {
            try
            {
                _patrimonioRepository.PostPatrimonio(patrimonio);
                return Request.CreateResponse(HttpStatusCode.OK, "Patrimonio cadastrada com sucesso", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message, "application/json");
            }
        }

        // POST: api/Patrimonio
        [HttpPost]
        [Route("api/Patrimonio/Update")]
        public HttpResponseMessage Put([FromBody] Patrimonio patrimonio)
        {
            try
            {
                _patrimonioRepository.PutPatrimonio(patrimonio);
                return Request.CreateResponse(HttpStatusCode.OK, "Patrimonio cadastrada com sucesso", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message, "application/json");
            }
        }

        // DELETE: api/Marca/5
        [HttpGet]
        [Route("api/Patrimonio/Delete/{id}")]
        public HttpResponseMessage Delete(Int64 id)
        {
            try
            {
                _patrimonioRepository.DeletePatrimonio(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Patrimonio exclída com sucesso", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message, "application/json");
            }
        }
    }
}
