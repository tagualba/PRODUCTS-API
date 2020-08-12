using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsAPI.Models;
using ProductsAPI.Data.Request;
using System.Text.Json;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public GetClientResponse Get(string request)
        {
            var getClientRequest = JsonSerializer.Deserialize<GetClientRequest>(request);
            return _clientModel.Get(getClientRequest);
        }

        [HttpGet]
        public GetClientsResponse GetClients(string request)
        {
            var getClientsRequest = JsonSerializer.Deserialize<GetClientsRequest>(request);
            return _clientModel.GetClients(getClientsRequest);
        }


        #endregion

        #region POST

        [HttpPost]
        public int Post(string request)
        {
            var loadClientRequest = JsonSerializer.Deserialize<LoadClientRequest>(request);
            return _clientModel.Post(loadClientRequest);
        }

        [HttpPost]
        public int LoadNewsLetter(string request)
        {
            var loadNewsLetterRequest = JsonSerializer.Deserialize<LoadNewsLetterRequest>(request);
            return _clientModel.LoadNewsLetter(loadNewsLetterRequest);
        }

        #endregion

    }
}
