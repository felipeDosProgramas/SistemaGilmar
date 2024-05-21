using System;

namespace SistemaDoGilmar.Exceptions;

public class NonQuadraticEquationException : Exception
{
    public NonQuadraticEquationException(string message = "O programa aceita apenas equações quedráticas") { }
}