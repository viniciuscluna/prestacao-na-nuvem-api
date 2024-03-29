﻿namespace PrestacaoNuvem.Api.Infrastructure.Repositories.Interfaces;

public interface IPrestacaoServicoRepository : IGenericRepository<PrestacaoServico>
{
    Task ChangeStatus(PrestacaoServico prestacaoServico, EPrestacaoServicoStatus status);
    Task<ICollection<PrestacaoServico>> GetByPrestador(Guid prestadorId);
    Task<PrestacaoServico> Update(PrestacaoServico item);
    Task<ICollection<PrestacaoServico>> GetByPrestacoesServicosStatus(Guid prestadorId, ICollection<EPrestacaoServicoStatus> statusPrestacao);

}
