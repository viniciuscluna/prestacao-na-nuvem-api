﻿using SmartOficina.Api.Enumerations;

namespace SmartOficina.Api.Dto;
public class PrestadorDto : Base
{
    public ETipoCadastroDto TipoCadastro { get; set; }
    public string? Nome { get; set; }
    public string? CPF { get; set; }
    public string? CpfRepresentante { get; set; }
    public string? CNPJ { get; set; }
    public string? RazaoSocial { get; set; }
    public string? NomeFantasia { get; set; }
    public string? NomeRepresentante { get; set; }
    public string? Telefone { get; set; }
    public string? EmailEmpresa { get; set; }
    public string? Endereco { get; set; }
    public string? EmailRepresentante { get; set; }
    public string? Logo {get; set; }
    public int SituacaoCadastral { get; set; }
    public DateTime? DataAbertura { get; set; }
    public DateTime? DataSituacaoCadastral { get; set; }

}
