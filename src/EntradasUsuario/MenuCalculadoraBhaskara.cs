using System;
using System.Collections.Generic;
using SistemaDoGilmar.Enums;

namespace SistemaDoGilmar.EntradasUsuario;

public class MenuCalculadoraBhaskara
{
    public TipoEntrada TipoEntrada { get; private set; }
    public string Equacao { get; private set; }
    private const string MensagemEscolherNotacao
        = """
          antes de escrever sua Equação quadrática... \n 
          escolha qual tipo de notação vai usar para representar a exponenciação:
          1 - Notação com acento circunflexo (Ex: 2*x^2 + 2*x -1 =0 )
          2 - Notação com asterisco duplo(**) (Ex: 2*x**x + 2*x -1 =0 )
        """;

    private const string MensagemSolicitarEquacao
        = "Escreva sua Equação seguindo o padrão escolhido: \n";
    public void EscolherTipoDeNotacao()
    {
        Console.WriteLine(MensagemEscolherNotacao);
        int opcao = Convert.ToInt32(Console.ReadLine());
        switch (opcao)
        {
            case 1:
                TipoEntrada = TipoEntrada.NotacaoExponenteAcentoCircunflexo;
                return;
            case 2:
                TipoEntrada = TipoEntrada.NotacaoExpoenteLinguagensProgramacao;
                return;
            default:
                Console.Clear();
                Console.WriteLine("escreva apenas uma das opções possíveis");
                EscolherTipoDeNotacao();
                return;
        }
    }

    public void SetEntradaDaEquacao()
    {
        Console.WriteLine(MensagemSolicitarEquacao);
        Equacao = Console.ReadLine();
    }

    public string ImprimeRaizes(Dictionary<string, double> raizes) => raizes.Count > 1
            ? $"Seu x1 é {raizes["x1"]} e seu x2 é {raizes["x2"]}"
            : $"Sua equação tem apenas o x1, tal qual é {raizes["x1"]}";

}