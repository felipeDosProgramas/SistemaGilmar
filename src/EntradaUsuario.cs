using System;
using System.Collections.Generic;
using SistemaDoGilmar.Enums;

namespace SistemaDoGilmar;

public class EntradaUsuario
{
    public string Entrada { get; set; }

    public EntradaUsuario(string entrada, TipoEntrada tipoEntrada)
    {
        this.Entrada = entrada.ToLower();
        if (tipoEntrada == TipoEntrada.NotacaoExpoenteLinguagensProgramacao)
        {

        }
    }

    private Dictionary<int, string> DividirComNotacaoLp()
    {
        string[] entrada = Entrada.Split('x');
        Console.WriteLine(entrada.ToString());
        throw new NotImplementedException();
    }

}