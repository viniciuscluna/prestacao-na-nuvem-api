﻿namespace SmartOficina.Api.Infrastructure.Repositories.Interfaces;

public interface ISubServicoRepository : IGenericRepository<SubServico>
{
    Task<ICollection<SubServico>> GetAllWithIncludes();
}