using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SistemaDoGilmar;
using SistemaDoGilmar.Enums;
using SistemaDoGilmar.Exceptions;

namespace TestSistemaDoGilmar.Entradas;

[TestFixture]
public class EntradaUsuarioTest
{
    private EntradaUsuario _entradaUsuarioCircunflexa;
    private EntradaUsuario _entradaUsuarioLp;
    // [Test]
    // public void EntradaComAcentoCircunflexo_AindaNaoImplmementada()
    // {
        // Assert.Catch<NotImplementedException>(() =>
        // {
            // _entradaUsuarioCircunflexa = new EntradaUsuario(
                // "X^2 + 1",
                // TipoEntrada.NotacaoExponenteAcentoCircunflexo
            // );
        // }, "Entrada com Acento circunflexo ainda não foi implementada");
    // }

    [Test]
    public void VerificarSeparacaoEntradaLp_sanitizarEntrada()
    {
        Assert.Catch<NonSimplifiedEquationException>(() =>
        {
            _entradaUsuarioLp = new EntradaUsuario(
                "   X**2 + 1   ",
                TipoEntrada.NotacaoExpoenteLinguagensProgramacao
            ); ;
        });
    }
    [TestCase("   X**2 - X**2 + 1   ")]
    [TestCase("  X**2 - X*2 + X*5 + 1 = 0")]
    public void VerificarSeparacaoEntradaLp_verificarValidadeDosExpoentes(string entrada)
    {
        Assert.Catch<NonSimplifiedEquationException>(() =>
        {
            _entradaUsuarioLp = new EntradaUsuario(
                entrada,
                TipoEntrada.NotacaoExpoenteLinguagensProgramacao
            );
        });
    }
    [Test]
    public void VerificarSeparacapEntradaLp_VerificarSeEstaSeparando()
    {
        _entradaUsuarioLp = new EntradaUsuario(
            "4x**2 - 2*x + 5 = 0",
            TipoEntrada.NotacaoExpoenteLinguagensProgramacao
        );
    }
}