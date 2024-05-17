using System;
using System.Linq;

namespace SistemaDoGilmar.EntradasUsuario;

public class MenuPrincipal
{
    public int opcaoEscolhida;
    public MenuPrincipal()
    {
        MenuPrincipalRecursivo();
    }

    private void MenuPrincipalRecursivo()
    {
        Console.WriteLine(@"
                qual exercício quer ver? \n 
                1- Calculadora de fórmulas \n
                2- Calculadora de operações \n
                3- Calculadora de salários \n
            ");

        int opcao = Convert.ToInt32(
            Console.ReadLine()
        );
        if (new int[] { 1, 2, 3 }.Contains(opcao))
        {
            opcaoEscolhida = opcao;
            return;
        }
        Console.Clear();
        MenuPrincipalRecursivo();
    }
    public int MenuFormulas()
    {
        Console.WriteLine(@"
                Qual fórmula quer calcular? \n
                1- Bhaskara \n
                2- Força \n
                3- Velocidade \n
        ");
        int entrada = Convert.ToInt32(
            Console.ReadLine()
        );
        if (!new int[] {1, 2, 3}.Contains(entrada))
        {
            Console.Clear();
            return MenuFormulas();
        }
        return entrada;
    }
}