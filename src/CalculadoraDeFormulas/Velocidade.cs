using System;
using System.Linq;

namespace SistemaDoGilmar.CalculadoraDeFormulas;

public class Velocidade
{
    public Velocidade()
    {
        Console.WriteLine(
            ReceberVelocidade()
        );
    }

    private double ReceberVelocidade()
    {
        try
        {
            Console.WriteLine(@"
                Digite a velocidade inicial em m/s \n 
                a área percorrido (em metros) \n
                e o tempo total em segundos \n
                digite os 3 valores separados por espaço
            ");
            double[] valores =  Console.ReadLine()!
                    .Split(' ')
                    .Select(Convert.ToDouble)
                    .ToArray();
            return valores[0] + (valores[1] * valores[2]);
        }
        catch (Exception)
        {
            Console.Clear();
            Console.WriteLine("digite como foi pedido");
            return ReceberVelocidade();
        }
    }
}