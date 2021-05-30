using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.Models;
namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public EventoController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _dataContext.Eventos;
        }

        [HttpGet("{id}")]
        public Evento Get(int id)
        {
            return _dataContext.Eventos.First(x => x.EventoId == id);
        }

        [HttpPost("{id}")]
        public string Post(int id)
        {
            return $"exemplo post {id}";
        }


        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"exemplo put {id}";
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var evento = _dataContext.Eventos.FirstOrDefault(x => x.EventoId == id);

            if (evento.EventoId > 0)
            {
                _dataContext.Eventos.Remove(evento );
                _dataContext.SaveChanges();
                return StatusCode(1);
            }

           return StatusCode(id);
        }
    }
}
