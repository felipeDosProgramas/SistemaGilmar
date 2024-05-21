using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SistemaDoGilmar.Exceptions;

namespace SistemaDoGilmar.Abstracts;

public abstract class AValidacoesEntradaUsuario : ACalculadoraEQuadratica
{
    /// <summary>
    /// Se os Enums do C# suportassem nativamente segurar strings, eu faria um Enum
    /// com esses regexes para ficar mais fácil de usá-los sem ser por um índice numérico.
    /// To com preguiça de fazer aquela gambiarra com Reflection só para simular esse
    /// comportamento.
    /// </summary>
    private readonly string[] _regexes = new[]
    {
        @"^([0-9]*?x\*\*2){1}(\+|-[0-9]+\*x)?(([+\-])[0-9]+)?(=0){1}$", // identificar a conta inteira com a notação LP
        @"[1-9]x\*\*[3-9]+", // validar se tem algo fora do comum com a notação LP
        @"^([0-9]*?x\^2){1}(\+|-[0-9]+\*x)?(([+\-])[0-9]+)?(=0){1}$", // identificar a conta inteira com a notação circunflexa
        @"[1-9]*?x\^[3-9]+", // validar se tem algo fora do comum com a notação LP
        @"^(([0-9]*?x\*\*2){1})|(([0-9]*?x\^2){1})", // encontrar o 'A' independente da notação
        @"(\+|-[0-9]+\*x){1}", // encontrar o 'B'
        @"(([+\-])[0-9]+)?(=0){1}$", // encontrar o 'C'
        @"[x]|(\*\*2)|(\^2)", //remover todos os "não números" do A
        @"[x]|\*", //remover todos os "não números" de B
        @"[=0]", //remover todos os "não números" de C
    };
    /// <summary>
    /// Realiza a validação da equação quando a mesma está no formato de entrada LP
    /// </summary>
    /// <exception cref="NonSimplifiedEquationException"></exception>
    /// <exception cref="NonQuadraticEquationException"></exception>
    protected void TestesEntradaLp(string entradaSanitizada)
    {
        if (!new Regex(_regexes[0]).IsMatch(entradaSanitizada))
            throw new NonSimplifiedEquationException();
        if (new Regex(_regexes[1]).IsMatch(entradaSanitizada))
            throw new NonQuadraticEquationException();
    }
    /// <summary>
    /// Realiza a validação da equação quando a mesma está no formato de entrada Circunflexa
    /// </summary>
    /// <exception cref="NonSimplifiedEquationException"></exception>
    /// <exception cref="NonQuadraticEquationException"></exception>
    protected void TestesEntradaCircunflexa(string entradaSanitizada)
    {
        if (!new Regex(_regexes[2]).IsMatch(entradaSanitizada))
            throw new NonSimplifiedEquationException();
        if (new Regex(_regexes[1]).IsMatch(entradaSanitizada))
            throw new NonQuadraticEquationException();
    }
    /// <exception cref="NonSimplifiedEquationException"></exception>
    /// <exception cref="NonQuadraticEquationException"></exception>
    protected static string ValidaEntrada(string entradaSanitizada, Action<string> testesEntrada)
    {
        testesEntrada(entradaSanitizada);
        return entradaSanitizada;
    }

    private int EncontrarItemNaStringValidada(  string[] regexesAplicaveis, string stringValidada)
    {
        return Convert.ToInt32(
            regexesAplicaveis
                .Aggregate(stringValidada, (current, regexAplicavel)
                    => new Regex(regexAplicavel).Replace(current, ""))
        );
    }
    protected void AdicionarANaEntradaDividida(ref Dictionary<char, double> entradaDividida, string entrada)
        => entradaDividida.Add(
            'a',
            EncontrarItemNaStringValidada(new []
                    { _regexes[6], _regexes[5], _regexes[7] },
                entrada
            )
        );
    protected void AdicionarBNaEntradaDividida(ref Dictionary<char, double> entradaDividida, string entrada)
        => entradaDividida.Add(
            'b',
            EncontrarItemNaStringValidada(new []
                    { _regexes[6], _regexes[4], _regexes[8] },
                entrada
            )
        );

    protected void AdicionarCNaEntradaDividida(ref Dictionary<char, double> entradaDividida, string entrada)
        => entradaDividida.Add(
            'c',
            EncontrarItemNaStringValidada(new[]
                    { _regexes[4], _regexes[5], _regexes[9] },
                entrada
            )
        );
}