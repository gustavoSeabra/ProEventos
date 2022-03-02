using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.APi.Data;
using ProEventos.APi.Models;

namespace ProEventos.APi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly DataContext _context;
        public EventoController(DataContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return this._context.Eventos;
        }

        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return this._context.Eventos.FirstOrDefault(e=> e.EventoId.Equals(id));
        }
    }
}
