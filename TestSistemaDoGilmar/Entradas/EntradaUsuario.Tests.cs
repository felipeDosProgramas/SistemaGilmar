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
    [TestCase("5x**2 -4*x +8 = 0", 5, -4, 8)]
    public void VerificarSeparacapEntradaLp_VerificarSeEstaSeparando(string entrada, int a, int b, int c)
    {
        _entradaUsuarioLp = new EntradaUsuario(
            entrada,
            TipoEntrada.NotacaoExpoenteLinguagensProgramacao
        );
        Assert.AreEqual(a, _entradaUsuarioLp.Equacao['a']);
        Assert.AreEqual(b, _entradaUsuarioLp.Equacao['b']);
        Assert.AreEqual(c, _entradaUsuarioLp.Equacao['c']);
    }
}