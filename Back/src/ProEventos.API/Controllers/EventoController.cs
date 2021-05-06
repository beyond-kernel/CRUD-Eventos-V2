using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;
namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public EventoController()
        {
        }

        public IEnumerable<Evento> _evento = new Evento[]{
            new Evento(){
                EventoId = 1,
                Tema = "Angular 11 e .Net 5",
                Lote = "1º Lote",
                Local = "São Paulo",
                QtdPessoas = 250,
                ImagemURL = "foto1.png",
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
            },
            new Evento(){
                EventoId = 2,
                Tema = "Angular 11 e novidades",
                Lote = "2º Lote",
                Local = "Pernambuco",
                QtdPessoas = 350,
                ImagemURL = "fot2.png",
                DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy")
            }

         };

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }

        [HttpGet("{id}")]
        public Evento Get(int id)
        {
            return _evento.First(x => x.EventoId == id);
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
        public string Delete(int id)
        {
            return $"exemplo delete {id}";
        }
    }
}
