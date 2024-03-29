﻿namespace PrestacaoNuvem.Api.Domain.Model;

public class Cliente : Base
{
    public required string Nome { get; set; }   
    public required string Telefone { get; set; }  
    public required string Email { get; set; }
    public string? Rg { get; set; }
    //ToDo: Criar classe de CPF
    public required string CPF { get; set; }
    //ToDo: Criar classe de Endereço
    public string? Endereco { get; set; }
    public required Guid PrestadorId { get; set; }
    public Prestador Prestador{ get; set; }
    public ICollection<PrestacaoServico>? Servicos { get; set; }
    public ICollection<OrdemVenda>? OrdemVendas { get; set; }

}