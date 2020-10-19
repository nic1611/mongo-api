using Microsoft.AspNetCore.Mvc;
using MongoApi.Collections;
using MongoApi.Dto;
using MongoDB.Driver;

namespace MongoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<InfectadoCollection> _infectadosCollection;

        public InfectadoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<InfectadoCollection>(typeof(InfectadoCollection).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadoDto dto)
        {
            var infectado = new InfectadoCollection(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);

            _infectadosCollection.InsertOne(infectado);
            
            return StatusCode(201, "Infectado adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadosCollection.Find(Builders<InfectadoCollection>.Filter.Empty).ToList();
            
            return Ok(infectados);
        }
    }
}