using Microsoft.AspNetCore.Mvc;
using ClinicaAPI.Data;
using ClinicaAPI.Models;
using System.Linq;

namespace ClinicaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly ClinicaContext _context;

        public PacientesController(ClinicaContext context)
        {
            _context = context;
        }

        // GET: api/pacientes
        [HttpGet]
        public IActionResult GetAll()
        {
            var pacientes = _context.Pacientes.ToList();
            return Ok(pacientes);
        }

        // GET: api/pacientes/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var paciente = _context.Pacientes.Find(id);
            if (paciente == null)
                return NotFound();
            return Ok(paciente);
        }

        // POST: api/pacientes
        [HttpPost]
        public IActionResult Create([FromBody] Paciente paciente)
        {
            if (paciente == null)
                return BadRequest();

            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
            return Ok(paciente);
        }

        // PUT: api/pacientes/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Paciente paciente)
        {
            if (id != paciente.Id)
                return BadRequest();

            var existing = _context.Pacientes.Find(id);
            if (existing == null)
                return NotFound();

            existing.Nombre = paciente.Nombre;
            existing.Edad = paciente.Edad;
            existing.Diagnostico = paciente.Diagnostico;

            _context.SaveChanges();
            return Ok(existing);
        }

        // DELETE: api/pacientes/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var paciente = _context.Pacientes.Find(id);
            if (paciente == null)
                return NotFound();

            _context.Pacientes.Remove(paciente);
            _context.SaveChanges();
            return NoContent();
        }
    }
}