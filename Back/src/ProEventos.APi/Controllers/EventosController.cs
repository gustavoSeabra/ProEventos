using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contratos;
using ProEventos.Domain;


namespace ProEventos.APi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventosService _eventosService;
        public EventosController(IEventosService eventosService)
        {
            this._eventosService = eventosService;
           
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var eventos = await _eventosService.GetAllEventosAsync(true);

                if(eventos==null)
                    return NotFound("Nenhum evento encontrado");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar os eventos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
             try
            {
                var evento = await _eventosService.GetAllEventoByIdAsync(id, true);

                if(evento == null)
                    return NotFound("Nenhum evento encontrado");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar os eventos. Erro: {ex.Message}");
            }
        }

        [HttpGet("tema/{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
             try
            {
                var eventos = await _eventosService.GetAllEventosByTemaAsync(tema, true);

                if(eventos == null)
                    return NotFound("Nenhum eventos por tema não encontrados");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar os eventos. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Evento model)
        {
            try
            {
                var evento = await _eventosService.AddEventos(model);

                if(evento == null)
                    return BadRequest("Erro ao tentar adicionar evento");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar um evento. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, Evento model)
        {
            try
            {
                var evento = await _eventosService.UpdateEvento(id, model);

                if(evento == null)
                    return BadRequest("Erro ao tentar editar um evento");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar editar um evento. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                if(await _eventosService.DeleteEvento(id))
                    return Ok("Deletado");
                else
                    return BadRequest("Evento não deletado");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar excluir um evento. Erro: {ex.Message}");
            }
        }
    }
}
