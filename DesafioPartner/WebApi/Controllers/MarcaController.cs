using System.Web.Http;
using System.Net.Http;
using System.Net;
using System;
using Dados;
using Models.Interfaces;
using Models;

namespace WebApiCliente.Controllers
{
    public class MarcaController : ApiController
    {
        private readonly IMarcaRepository _marcaRepository;
        public MarcaController()
        {
            _marcaRepository = new MarcaRepository();
        }

        // GET: api/Marca/GetMarcas
        [HttpGet]
        [Route("api/Marca/GetMarcas")]
        public HttpResponseMessage Get()
        {
            try
            {
                var listarMarcas = _marcaRepository.GetMarcas();
                return Request.CreateResponse(HttpStatusCode.OK, listarMarcas, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message, "application/json");
            }
        }

        // GET: api/Marca/GetMarcaById/5
        [HttpGet]
        [Route("api/Marca/GetMarcaById/{id}")]
        public HttpResponseMessage Get(Int64 id)
        {
            try
            {
                var marca = _marcaRepository.GetMarca(id);
                return Request.CreateResponse(HttpStatusCode.OK, marca, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message, "application/json");
            }
        }

        // GET: api/Marca/GetListaPatrimonioByMarcaId/5/name
        [HttpGet]
        [Route("api/Marca/GetListaPatrimonioByMarcaId/{id}/{nome}")]
        public HttpResponseMessage Get(Int64 id, string nome)
        {
            try
            {
                var marca = _marcaRepository.GetPatrimonioByMarca(id, nome);
                return Request.CreateResponse(HttpStatusCode.OK, marca, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message, "application/json");
            }
        }

        // POST: api/Marca/Insert
        [HttpPost]
        [Route("api/Marca/Insert")]
        public HttpResponseMessage Post([FromBody] Marca marca)
        {
            try
            {
                var verificaMarca = _marcaRepository.GetMarca(marca.Nome);
                if (String.IsNullOrWhiteSpace(verificaMarca.Nome))
                {
                    _marcaRepository.PostMarca(marca);
                    return Request.CreateResponse(HttpStatusCode.OK, "Marca cadastrada com sucesso", "application/json");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.PreconditionFailed, "Esta marca já existe", "application/json");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed, ex.Message, "application/json");
            }
        }

        // POST: api/Marca/Update
        [HttpPost]
        [Route("api/Marca/Update")]
        public HttpResponseMessage Put([FromBody] Marca marca)
        {
            try
            {
                var verificaMarca = _marcaRepository.GetMarca(marca.Nome);
                if (verificaMarca.MarcaId == 0 || (verificaMarca.MarcaId == marca.MarcaId && verificaMarca.Nome == marca.Nome))
                {
                    _marcaRepository.PutMarca(marca);
                    return Request.CreateResponse(HttpStatusCode.OK, "Marca cadastrada com sucesso", "application/json");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.PreconditionFailed, "Esta marca já existe", "application/json");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed, ex.Message, "application/json");
            }
        }

        // DELETE: api/Marca/Delete/5
        [HttpGet]
        [Route("api/Marca/Delete/{id}")]
        public HttpResponseMessage Delete(Int64 id)
        {
            try
            {
                _marcaRepository.DeleteMarca(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Marca exclída com suuucesso", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed, ex.Message, "application/json");
            }
        }
    }
}
