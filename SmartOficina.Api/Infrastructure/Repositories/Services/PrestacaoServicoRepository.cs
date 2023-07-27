﻿using SmartOficina.Api.Domain.Model;

namespace SmartOficina.Api.Infrastructure.Repositories.Services;

public class PrestacaoServicoRepository : GenericRepository<PrestacaoServico>, IPrestacaoServicoRepository
{
    private readonly OficinaContext _context;
    private readonly IServicoRepository _servicoRepository;

    public PrestacaoServicoRepository(OficinaContext context, IServicoRepository servicoRepository) : base(context)
    {
        _context = context;
        _servicoRepository = servicoRepository;
    }

    public async Task<PrestacaoServico> FindById(Guid id)
    {
        var result = _context.PrestacaoServico
            .Where(f => f.Id == id)
            .Include(i => i.Prestador)
            .Include(i => i.Cliente)
            .Include(i => i.Veiculo)
            .Include(i => i.Servicos)
                .ThenInclude(i => i.SubServico)
                .ThenInclude(i => i.Categoria)
            .ToList();
        await _context.DisposeAsync();

        return result.FirstOrDefault();
    }

    public async Task<PrestacaoServico> Update(PrestacaoServico item)
    {
        if (item.Servicos.Any())
        {
            foreach (var servico in item.Servicos)
            {
                var servicoConsulta = _context.Set<Servico>().AsNoTracking().FirstOrDefault(x => x.Id == servico.Id);

                if (servicoConsulta == null)
                {
                    servico.PrestacaoServicoId = item.Id;
                    await _context.Set<Servico>().AddAsync(servico);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.Set<Servico>().Update(servico);
                    await _context.SaveChangesAsync();
                }
            }
        }
        _context.Set<PrestacaoServico>().Update(item);
        await _context.SaveChangesAsync();
        await _context.DisposeAsync();
        
        return item;
    }

    public async Task ChangeStatus(Guid id, EPrestacaoServicoStatus status)
    {
        var prestacao = await _context.PrestacaoServico.FindAsync(id);
        if (prestacao is not null)
        {
            prestacao.Status = status;
            await _context.SaveChangesAsync();
            await _context.DisposeAsync();
        }
        else throw new Exception("Prestacao não encontrada");
    }

    public async Task<ICollection<PrestacaoServico>> GetByPrestador(Guid prestadorId)
    {
        var result = await _context.PrestacaoServico
            .Where(f => f.PrestadorId == prestadorId)
            .Include(i => i.Prestador)
            .Include(i => i.Cliente)
            .Include(i => i.Veiculo)
            .Include(i => i.Servicos)
                .ThenInclude(i => i.SubServico)
                .ThenInclude(i => i.Categoria)
            .ToArrayAsync();
        await _context.DisposeAsync();

        return result;
    }
}