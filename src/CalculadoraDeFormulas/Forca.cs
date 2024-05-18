using System;
using System.Linq;

namespace SistemaDoGilmar.CalculadoraDeFormulas;

public class Forca
{
    public Forca()
    {
        tentar:
        try
        {
            Console.WriteLine("digite a massa em gramas e a aceleração em m/s \n divida-os com um espaço");
            CalcularEMostrarForca();
        }
        catch (Exception)
        {
            Console.Clear();
            Console.WriteLine("digite como foi pedido, não invente moda");
            goto tentar;
        }
    }

    private void CalcularEMostrarForca() => Console.WriteLine(
        Console.ReadLine()!
            .Split(' ')
            .Select(Convert.ToDouble)
            .Aggregate((m, a) => m * a)
    );
}