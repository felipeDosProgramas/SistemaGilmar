using System;

namespace SistemaDoGilmar.Exceptions;

public class NonQuadraticEquationException : Exception
{
    public NonQuadraticEquationException() { }
    public NonQuadraticEquationException(string message) : base(message) { }
    public NonQuadraticEquationException(string message, Exception inner) : base(message, inner) { }
}