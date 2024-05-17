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
        Equacao = DividirTermos();
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
                    { Regexes[6], Regexes[5], Regexes[7] },
                Entrada
            )
        );
    private void AdicionarBNaEntradaDividida(ref Dictionary<char, int> entradaDividida)
        => entradaDividida.Add(
            'b',
            EncontrarItemNaStringValidada(new []
                    { Regexes[6], Regexes[4], Regexes[8] },
                Entrada
            )
        );
    private void AdicionarCNaEntradaDividida(ref Dictionary<char, int> entradaDividida)
        => entradaDividida.Add(
            'c',
            EncontrarItemNaStringValidada(new []
                    { Regexes[4], Regexes[5], Regexes[9] },
                Entrada
            )
        );
    private Dictionary<char, int> DividirTermos()
    {
        Dictionary<char, int> entradaDividida = new Dictionary<char, int>();
        AdicionarANaEntradaDividida(ref entradaDividida);
        AdicionarBNaEntradaDividida(ref entradaDividida);
        AdicionarCNaEntradaDividida(ref entradaDividida);
        return entradaDividida;
    }

}