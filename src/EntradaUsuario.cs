using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SistemaDoGilmar.Enums;
using SistemaDoGilmar.Exceptions;

namespace SistemaDoGilmar;

public class EntradaUsuario
{
    private readonly string[] _regexes = new[]
    {
        @"^([0-9]*?x\*\*2){1}(\+|-[0-9]+\*x)?(([+\-])[0-9]+)?(=0){1}$",
        @"[1-9]x\*\*[3-9]+",
        @"^([0-9]*?x\^2){1}(\+|-[0-9]+\*x)?(([+\-])[0-9]+)?(=0){1}$",
        @"[1-9]*?x\^[3-9]+",
        @"^([0-9]*?x\*\*2){1}",
        @"(\+|-[0-9]+\*x){1}",
        @"(([+\-])[0-9]+)?(=0){1}$",
        @"^([0-9]*?x\^2){1}",
    };
    public string Entrada { get; set; }
    public Dictionary<char, int> Equacao { get; set; }
    private TipoEntrada _tipoEntrada;

    public EntradaUsuario(string entrada, TipoEntrada tipoEntrada)
    {
        _tipoEntrada = tipoEntrada;
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
            .Aggregate((anterior, proximo) => anterior + separador + proximo);
    }

    /// <exception cref="NonSimplifiedEquationException"></exception>
    /// <exception cref="NonQuadraticEquationException"></exception>
    private string ValidaEntrada(string entradaSanitizada, Action<string> testesEntrada)
    {
        testesEntrada(entradaSanitizada);
        return entradaSanitizada;
    }

    private void TestesEntradaLp(string entradaSanitizada)
    {
        if (!new Regex(_regexes[0]).IsMatch(entradaSanitizada))
            throw new NonSimplifiedEquationException();
        if (new Regex(_regexes[1]).IsMatch(entradaSanitizada))
            throw new NonQuadraticEquationException();
    }

    private void TestesEntradaCircunflexa(string entradaSanitizada)
    {
        if (!new Regex(_regexes[2]).IsMatch(entradaSanitizada))
            throw new NonSimplifiedEquationException();
        if (new Regex(_regexes[1]).IsMatch(entradaSanitizada))
            throw new NonQuadraticEquationException();
    }
    private Dictionary<char, int> DividirComNotacaoLp()
    {
        Entrada = Regex.Replace(Entrada, @"/x\*\*0/", "1");
        string[] entradaDividida = Entrada.Split('x');
        Dictionary<char, int> mockEntradaDividida = new Dictionary<char, int>();
        return mockEntradaDividida;
    }

}