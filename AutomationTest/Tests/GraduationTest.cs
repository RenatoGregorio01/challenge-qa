using AutomationTest.Steps;
using AutomationTest.Utilities;
using OpenQA.Selenium;
using Xunit;


namespace AutomationTest.Tests
{
    public class GraduationTests : BaseTest
    {
        private readonly GraduationStep _graduationStep;

        public GraduationTests()
        {
            _graduationStep = new GraduationStep(Driver);
        }

        [Fact]
        public void Test_GraduationPageTitle()
        {
            _graduationStep.GivenEstouNaPaginaDeLoginGrupoA();
            _graduationStep.WhenEuSelecionarONivelDeEnsino();
            _graduationStep.WhenSelecionarUmCurso();
            _graduationStep.WhenPreencherOFormularioDeCadastro();
            _graduationStep.WhenFazerLoginComMeuUsuarioCadastrado();
            _graduationStep.ThenDevoVisualizarAPaginaInternaDoCandidato();
            ScreenshotHelper.TakeScreenshot(Driver, "LoginSuccess.png");
        }
    }
}
