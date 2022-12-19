using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class EventoPersistence : IEventoPersistence
    {
        private readonly ProEventosContext _context;
        public EventoPersistence(ProEventosContext context)
        {
            _context = context;
            // _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            // Resolve este erro aqui:
            // Erro: The instance of entity type 'Evento' cannot be tracked because another 
            // instance with the same key value for {'Id'} is already being tracked.
        }       

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e=> e.Lotes)
                .Include(e=> e.RedesSociais);

            if(includePalestrantes)
                query.Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);


            query = query.AsNoTracking().OrderBy(e=> e.Id);

            return await query.ToArrayAsync();

        }
        public async Task<Evento> GetAllEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e=> e.Lotes)
                .Include(e=> e.RedesSociais);

            if(includePalestrantes)
                query.Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);


            query = query.AsNoTracking().OrderBy(e=> e.Id).Where(e=> e.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e=> e.Lotes)
                .Include(e=> e.RedesSociais);

            if(includePalestrantes)
                query.Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);


            query = query.AsNoTracking().OrderBy(e=> e.Id).Where(e=> e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}