using DSW1_API_EF_CUROTAQUILA_JEFFERSON.Model;
using DSW1_API_EF_CUROTAQUILA_JEFFERSON.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSW1_API_EF_CUROTAQUILA_JEFFERSON.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocentesController : ControllerBase
    {
        private readonly DocenteService _docenteService;

        public DocentesController(DocenteService docenteService)
        {
            _docenteService = docenteService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var docentes = _docenteService.ListarDocentes();
            return Ok(docentes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var docente = _docenteService.BuscarDocentePorId(id);
            if (docente == null)
            {
                return NotFound();
            }
            return Ok(docente);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Docentes docente)
        {
            _docenteService.RegistrarDocente(docente);
            return CreatedAtAction(nameof(Get), new { id = docente.Codigo }, docente);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Docentes docente)
        {
            if (id != docente.Codigo)
            {
                return BadRequest();
            }

            _docenteService.ActualizarDocente(docente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _docenteService.EliminarDocentePorId(id);
            return NoContent();
        }
    }
}
