using System;
using SistemaDoGilmar.CalculadoraDeFormulas;
using SistemaDoGilmar.EntradasUsuario;

namespace SistemaDoGilmar;

    internal class Program
    {
        public static void Main(string[] args)
        {
            MenuPrincipal menuPrincipal = new ();
            switch (menuPrincipal.opcaoEscolhida)
            {
                case 1:
                    Console.Clear();
                    Formulas(
                        menuPrincipal.MenuFormulas()
                    );
                    break;
                case 2:

                    break;
            }
        }

        private static void Formulas(int formula)
        {
            Console.Clear();
            switch (formula)
            {
                case 1:
                    MenuCalculadoraBhaskara menuBhaskara = new ();
                    menuBhaskara.EscolherTipoDeNotacao();
                    CalculadoraBhaskara bhaskara = new (
                        menuBhaskara.GetEntradaDaEquacao(),
                        menuBhaskara.TipoEntrada
                    );
                    while (!bhaskara.EntradaEValida())
                        bhaskara.SetNovaEntrada(
                            menuBhaskara.GetEntradaDaEquacao()
                        );
                    bhaskara.CalcularDelta(bhaskara.Equacao);
                    if (!bhaskara.SetRaizes(bhaskara.Equacao)) return;
                    Console.WriteLine(
                        menuBhaskara.GetSaidaRaizes(bhaskara.Raizes)
                    );
                    break;
                case 2:
                    Forca forca = new ();
                    break;
                case 3:
                    Velocidade velocidade = new ();
                    break;
            }
        }
    }
