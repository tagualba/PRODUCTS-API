using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using ProductsAPI.Models;
using ProductsAPI.Data.Request;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {

        private readonly ILogger<ClientController> _logger;
        private ClientModel _clientModel;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
            _clientModel = new ClientModel();
        }   


        #region GET


        [HttpGet]
        [Route("getbyid")]
        //  Obtiene un cliente por el email
        public GetClientResponse GetById(string request)
        {
            var getClientRequest = JsonSerializer.Deserialize<GetClientRequest>(request);
            return _clientModel.GetById(getClientRequest);
        }

        [HttpGet]
        [Route("getbyemail")]
        //  Obtiene un cliente por el email
        public GetClientResponse GetByEmail(string request)
        {
            var getClientRequest = JsonSerializer.Deserialize<GetClientRequest>(request);
            return _clientModel.GetByEmail(getClientRequest);
        }

        [HttpGet]
        [Route("getclients")]
        //  Obtiene toda la lista de clientes
        public GetClientsResponse GetClients()
        {
            return _clientModel.GetClients();
        }

        [HttpGet]
        [Route("getidentypes")]
        //  Obtiene toda la lista de tipos de identificacion
        public GetIdenTypesResponse GetIdenTypes()
        {
            return _clientModel.GetIdenTypes();
        }


        #endregion


        #region POST


        [HttpPost]
        [Route("post")]
        //  Carga un cliente
        public int Post(string request)
        {
            var loadClientRequest = JsonSerializer.Deserialize<LoadClientRequest>(request);
            return _clientModel.Post(loadClientRequest);
        }

        [HttpPost]
        [Route("loadnewsletter")]
        //  Carga una adhesion al newsletter
        public int LoadNewsLetter(string request)
        {
            var loadNewsLetterRequest = JsonSerializer.Deserialize<LoadNewsLetterRequest>(request);
            return _clientModel.LoadNewsLetter(loadNewsLetterRequest);
        }


        #endregion
    }
}
