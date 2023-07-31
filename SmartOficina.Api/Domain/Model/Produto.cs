﻿namespace SmartOficina.Api.Domain.Model;

public class Produto : Base
{
    public Produto()
    {

    }
    public required string Nome { get; set; }
    public required string Marca { get; set; }
    public string? Modelo { get; set; }
    public DateTime? Data_validade { get; set; }
    public string Garantia { get; set; }
    public required float Valor_Compra { get; set; }
    public required float Valor_Venda { get; set; }
    public required int Qtd { get; set; }
    public required Guid PrestadorId { get; set; }
}
