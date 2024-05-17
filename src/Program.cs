using SistemaDoGilmar.EntradasUsuario;

namespace SistemaDoGilmar
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MenuPrincipal menuPrincipal = new ();
            switch (menuPrincipal.opcaoEscolhida)
            {
                case 1:
                    Formulas(
                        menuPrincipal.MenuFormulas()
                    );
                break;
            }
        }

        private static void Formulas(int formula)
        {
            switch (formula)
            {
                case 1:

                break;
            }
        }
    }
}