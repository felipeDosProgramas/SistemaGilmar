using System;

namespace SistemaDoGilmar.Exceptions;

public class NonSimplifiedEquationException : Exception
{
    public NonSimplifiedEquationException() { }
    public NonSimplifiedEquationException(string message) : base(message) { }
    public NonSimplifiedEquationException(string message, Exception inner) : base(message, inner) { }
}