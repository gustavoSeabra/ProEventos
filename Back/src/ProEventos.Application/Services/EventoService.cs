using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application.Services
{
    public class EventoService : IEventosService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IEventoPersistence _eventoPersistence;

        public EventoService(IGeralPersistence geralPersistence, IEventoPersistence eventoPersistence)
        {
            _geralPersistence = geralPersistence;
            _eventoPersistence = eventoPersistence;
        }


        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralPersistence.Add<Evento>(model);
                if(await _geralPersistence.SaveChangesAsync())
                    return await _eventoPersistence.GetAllEventoByIdAsync(model.Id, false);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersistence.GetAllEventoByIdAsync(eventoId, false);
                if(evento is null)
                    return null;

                model.Id = evento.Id;
                
                _geralPersistence.Update(model);
                
                if(await _geralPersistence.SaveChangesAsync())
                    return await _eventoPersistence.GetAllEventoByIdAsync(model.Id, false);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoPersistence.GetAllEventoByIdAsync(eventoId, false);
                if(evento is null)
                    throw new Exception("Evento para delete não foi encontrado");

                _geralPersistence.Delete<Evento>(evento);
                
                return await _geralPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetAllEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventoByIdAsync(eventoId, includePalestrantes);
                if(eventos == null)
                    return null;

                return eventos;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventosAsync(includePalestrantes);
                if(eventos == null)
                    return null;

                return eventos;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if(eventos == null)
                    return null;

                return eventos;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}