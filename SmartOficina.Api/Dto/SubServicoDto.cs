﻿namespace SmartOficina.Api.Dto;

public class SubServicoDto
{
    public string Titulo { get; set; }
    public string Desc { get; set; }
    public Guid? CategoriaId { get; set; }
    public Guid? Id { get; set; }
    public CategoriaServicoDto? Categoria { get; set; }
}