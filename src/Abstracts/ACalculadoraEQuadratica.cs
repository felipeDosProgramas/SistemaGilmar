using System;
using System.Collections.Generic;

namespace SistemaDoGilmar.Abstracts;

public abstract class ACalculadoraEQuadratica
{
    protected double D;
    protected Dictionary<string, double> Raizes = new ();
    protected void CalcularDelta(Dictionary<char, double> equacao)
    {
        D = Math.Pow(equacao['b'], 2) - 4 * (equacao['a'] * equacao['c']);
    }

    protected bool SetRaizes(Dictionary<char, double> equacao)
    {
        switch (D)
        {
            case < 0:
                Console.WriteLine("delta é menor que zero, sem raízes reais por aqui");
                return false;
            case 0:
                Raizes.Add("x1",
                    -equacao['b'] / (2 * equacao['a'])
                );
                return true;
            default:
                Raizes.Add("x1",
                    -equacao['b'] + Math.Sqrt(D) / (2 * equacao['a'])
                );
                Raizes.Add("x2",
                    -equacao['b'] - Math.Sqrt(D) / (2 * equacao['a'])
                );
                return true;
        }
    }
}