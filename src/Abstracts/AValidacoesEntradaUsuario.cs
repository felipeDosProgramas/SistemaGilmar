using System;
using System.Linq;
using System.Text.RegularExpressions;
using SistemaDoGilmar.Exceptions;

namespace SistemaDoGilmar.Abstracts;

public abstract class AValidacoesEntradaUsuario
{
    /// <summary>
    /// Se os Enums do C# suportassem nativamente segurar strings, eu faria um Enum
    /// com esses regexes para ficar mais fácil de usá-los sem ser por um índice numérico.
    /// To com preguiça de fazer aquela gambiarra com Reflection só para simular esse
    /// comportamento.
    /// </summary>
    protected readonly string[] Regexes = new[]
    {
        @"^([0-9]*?x\*\*2){1}(\+|-[0-9]+\*x)?(([+\-])[0-9]+)?(=0){1}$", // identificar a conta inteira com a notação LP
        @"[1-9]x\*\*[3-9]+", // validar se tem algo fora do comum com a notação LP
        @"^([0-9]*?x\^2){1}(\+|-[0-9]+\*x)?(([+\-])[0-9]+)?(=0){1}$", // identificar a conta inteira com a notação circunflexa
        @"[1-9]*?x\^[3-9]+", // validar se tem algo fora do comum com a notação LP
        @"^([0-9]*?x\*\*2){1}", // encontrar o 'A' com a notação LP
        @"(\+|-[0-9]+\*x){1}", // encontrar o 'B'
        @"(([+\-])[0-9]+)?(=0){1}$", // encontrar o 'C'
        @"^([0-9]*?x\^2){1}", // encontrar o 'A' com a notação circunflexa
        @"x|(\*\*2)|(^2)", //remover todos os "não números" do A
        @"x|\*" //remover todos os "não números" de B
    };
    protected void TestesEntradaLp(string entradaSanitizada)
    {
        if (!new Regex(Regexes[0]).IsMatch(entradaSanitizada))
            throw new NonSimplifiedEquationException();
        if (new Regex(Regexes[1]).IsMatch(entradaSanitizada))
            throw new NonQuadraticEquationException();
    }

    protected void TestesEntradaCircunflexa(string entradaSanitizada)
    {
        if (!new Regex(Regexes[2]).IsMatch(entradaSanitizada))
            throw new NonSimplifiedEquationException();
        if (new Regex(Regexes[1]).IsMatch(entradaSanitizada))
            throw new NonQuadraticEquationException();
    }
    /// <exception cref="NonSimplifiedEquationException"></exception>
    /// <exception cref="NonQuadraticEquationException"></exception>
    protected string ValidaEntrada(string entradaSanitizada, Action<string> testesEntrada)
    {
        testesEntrada(entradaSanitizada);
        return entradaSanitizada;
    }
    protected int EncontrarItemNaStringValidada(  string[] regexesAplicaveis, string stringValidada)
    {
        return Convert.ToInt32(
            regexesAplicaveis
                .Aggregate(stringValidada,
                    (current, regexAplicavel) => new Regex(regexAplicavel)
                        .Replace(current, ""))
        );
    }
}