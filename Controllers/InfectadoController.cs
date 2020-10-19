using Microsoft.AspNetCore.Mvc;
using MongoApi.Collections;
using MongoApi.Dto;
using MongoApi.Interfaces;

namespace MongoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        private readonly IInfectadoRepository _repo;

        public InfectadoController(IInfectadoRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadoDto dto)
        {
            var infectado = new InfectadoCollection(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);

            _repo.Create(infectado);
            
            return StatusCode(201, "Infectado adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _repo.Get();
            
            return Ok(infectados);
        }
    }
}