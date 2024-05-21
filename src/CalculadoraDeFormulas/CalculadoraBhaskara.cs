using System;
using System.Collections.Generic;
using System.Linq;
using SistemaDoGilmar.Abstracts;
using SistemaDoGilmar.Enums;

namespace SistemaDoGilmar.CalculadoraDeFormulas;

public class CalculadoraBhaskara(string entrada, TipoEntrada tipoEntrada) : AValidacoesEntradaUsuario
{
    private readonly string _entradaSanitizada = SanitizaEntrada(entrada.ToLower().Trim());
    public string Entrada { get; set; }
    public Dictionary<char, int> Equacao { get; private set; }

    public bool EntradaEValida()
    {
        try
        {
            Entrada = ValidaEntrada(
                _entradaSanitizada,
                tipoEntrada == TipoEntrada.NotacaoExpoenteLinguagensProgramacao
                    ? TestesEntradaLp
                    : TestesEntradaCircunflexa
            );
            Equacao = DividirTermos();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exceção capturada: {e.GetType()} \n Mensagem: {e.Message}");
            return false;
        }
    }
    private static string SanitizaEntrada(string entrada)
    {
        foreach (var s in new [] { '+', '-', 'x', '=' })
            TrimaPartesEquacao(s, ref entrada);
        return entrada;
    }

    private static void TrimaPartesEquacao(char separador, ref string entrada)
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
        Dictionary<char, int> entradaDividida = new ();
        AdicionarANaEntradaDividida(ref entradaDividida);
        AdicionarBNaEntradaDividida(ref entradaDividida);
        AdicionarCNaEntradaDividida(ref entradaDividida);
        return entradaDividida;
    }

}