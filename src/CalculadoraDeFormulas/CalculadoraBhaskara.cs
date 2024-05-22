using System;
using System.Collections.Generic;
using System.Linq;
using SistemaDoGilmar.Abstracts;
using SistemaDoGilmar.Enums;

namespace SistemaDoGilmar.CalculadoraDeFormulas;

public class CalculadoraBhaskara(string entrada, TipoEntrada tipoEntrada) : AValidacoesEntradaUsuario
{
    private string _entradaSanitizada = SanitizaEntrada(entrada.ToLower().Trim());
    public string Entrada { get; set; }
    public Dictionary<char, double> Equacao { get; private set; }

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
            Console.Clear();
            Console.WriteLine($"Exceção capturada: {e.GetType()} \n Mensagem: {e.Message}");
            return false;
        }
    }

    public void SetNovaEntrada(string entrada)
    {
        _entradaSanitizada = SanitizaEntrada(entrada.ToLower().Trim());
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

    private Dictionary<char, double> DividirTermos()
    {
        Dictionary<char, double> entradaDividida = new ();
        AdicionarANaEntradaDividida(ref entradaDividida, Entrada);
        AdicionarBNaEntradaDividida(ref entradaDividida, Entrada);
        AdicionarCNaEntradaDividida(ref entradaDividida, Entrada);
        return entradaDividida;
    }
}