using NUnit.Framework;
using SistemaDoGilmar.CalculadoraDeFormulas;
using SistemaDoGilmar.Enums;
using SistemaDoGilmar.Exceptions;

namespace TestSistemaDoGilmar.Entradas;

[TestFixture]
public class CalculadoraBhaskaraTest
{
    private CalculadoraBhaskara _calculadoraBhaskaraCircunflexa;
    private CalculadoraBhaskara _calculadoraBhaskaraLp;

    [Test]
    public void VerificarSeparacaoEntradaLp_sanitizarEntrada()
    {
        Assert.Catch<NonSimplifiedEquationException>(() =>
        {
            _calculadoraBhaskaraLp = new CalculadoraBhaskara(
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
            _calculadoraBhaskaraLp = new CalculadoraBhaskara(
                entrada,
                TipoEntrada.NotacaoExpoenteLinguagensProgramacao
            );
        });
    }
    [TestCase("5x**2 -4*x +8 = 0", 5, -4, 8)]
    public void VerificarSeparacapEntradaLp_VerificarSeEstaSeparando(string entrada, int a, int b, int c)
    {
        _calculadoraBhaskaraLp = new CalculadoraBhaskara(
            entrada,
            TipoEntrada.NotacaoExpoenteLinguagensProgramacao
        );
        Assert.AreEqual(a, _calculadoraBhaskaraLp.Equacao['a']);
        Assert.AreEqual(b, _calculadoraBhaskaraLp.Equacao['b']);
        Assert.AreEqual(c, _calculadoraBhaskaraLp.Equacao['c']);
    }
}