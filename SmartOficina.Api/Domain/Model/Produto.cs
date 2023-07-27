﻿namespace SmartOficina.Api.Domain.Model;
public class Produto : Base
{
    public required string Nome { get; set; }
    public required string Marca { get; set; }
    public string? Modelo { get; set; }
    public DateTime? Data_validade { get; set; }
    public required string Garantia { get; set; }
    //ToDo: Colocar required acima de 0.01 centavos
    public required float Valor_Compra { get; set; }
    //ToDo: Colocar required acima de 0.01 centavos
    public required float Valor_Venda { get; set; }
}