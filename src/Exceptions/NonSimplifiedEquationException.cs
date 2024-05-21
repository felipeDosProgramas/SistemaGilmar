using System;

namespace SistemaDoGilmar.Exceptions;

public class NonSimplifiedEquationException : Exception
{
    public NonSimplifiedEquationException(string message = "escreva a equação em sua forma irredutível") { }
}