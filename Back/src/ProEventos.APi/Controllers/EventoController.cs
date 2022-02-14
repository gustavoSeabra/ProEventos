using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.APi.Models;

namespace ProEventos.APi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private IEnumerable<Evento> _eventos;

        public EventoController(ILogger<EventoController> logger)
        {
            this._eventos = new Evento[]  {
                new Evento() {
                    EventoId = 1,
                    Tema = "Angular 11 e .net 5",
                    Local = "Belo Horizonte",
                    Lote = "1º Lote",
                    QtdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(2).ToShortDateString()
                    
                },
                new Evento() {
                    EventoId = 2,
                    Tema = "Angular e suas novidades",
                    Local = "São Paulo",
                    Lote = "2º Lote",
                    QtdPessoas = 350,
                    DataEvento = DateTime.Now.AddDays(3).ToShortDateString()
                    
                }
            };
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return this._eventos;
        }

        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return this._eventos.Where(e=> e.EventoId.Equals(id)).FirstOrDefault();  
        }
    }
}
