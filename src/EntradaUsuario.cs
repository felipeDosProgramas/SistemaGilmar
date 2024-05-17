using System;
using System.Collections.Generic;
using System.Linq;
using SistemaDoGilmar.Abstracts;
using SistemaDoGilmar.Enums;

namespace SistemaDoGilmar;

public class EntradaUsuario : AValidacoesEntradaUsuario
{
    public string Entrada { get; set; }
    public Dictionary<char, int> Equacao { get; set; }

    public EntradaUsuario(string entrada, TipoEntrada tipoEntrada)
    {
        Action<string> validacoes = tipoEntrada == TipoEntrada.NotacaoExpoenteLinguagensProgramacao
            ? TestesEntradaLp
            : TestesEntradaCircunflexa;
        Entrada = ValidaEntrada(
            SanitizaEntrada(entrada.ToLower().Trim()),
            validacoes
        );
        Equacao = tipoEntrada == TipoEntrada.NotacaoExpoenteLinguagensProgramacao
            ? DividirComNotacaoLp()
            : throw new NotImplementedException("notação com Expoente escrito em acento circunflexo ainda não implementado");
    }

    private string SanitizaEntrada(string entrada)
    {
        foreach (var s in new [] { '+', '-', 'x', '=' })
            TrimaPartesEquacao(s, ref entrada);
        return entrada;
    }

    private void TrimaPartesEquacao(char separador, ref string entrada)
    {
        entrada = entrada.Split(separador)
            .Select(str => str.Trim())
            .Aggregate(
                (anterior, proximo) => anterior + separador + proximo
            );
    }

    private void AdicionarANaEntradaDividida(ref Dictionary<char, int> entradaDividida)
        => entradaDividida.Add(
            'a',
            EncontrarItemNaStringValidada(new []
                    { Regexes[5], Regexes[6], Regexes[8] },
                Entrada
            )
        );

    private Dictionary<char, int> DividirComNotacaoLp()
    {
        Dictionary<char, int> entradaDividida = new Dictionary<char, int>();

        return entradaDividida;
    }

}