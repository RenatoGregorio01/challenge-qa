using OpenQA.Selenium;
using Reqnroll;
using AutomationTest.Pages;
using AutomationTest.Utilities;
using AutomationTest.Models;



namespace AutomationTest.Steps
{
    [Binding]
    public class GraduationStep
    {
        private readonly GraduationPage _graduationPage;
         public GraduationStep(IWebDriver driver)
        {
            _graduationPage = new GraduationPage(driver);
        }

        
        [Given("que estou na pagina de login Grupo A")]
        public void GivenEstouNaPaginaDeLoginGrupoA()
        {
            _graduationPage.OpenSite();
            _graduationPage.WaitElementImgEducacao();
        }

        [When("eu selecionar o nivel de ensino")]
        public void WhenEuSelecionarONivelDeEnsino()
        {
            _graduationPage.WaitSelectComboboxEducationLevel();
            _graduationPage.WaitNivelGraduacaoEducationLevel();
        }

        [When("selecionar um curso")]
        public void WhenSelecionarUmCurso()
        {
            _graduationPage.WaitGraduationCombo();
            //graduationPage.WaitInputCurseSelect();
            // graduationPage.GetSelectedCourse();
            //string selectedCourse = graduationPage.GetSelectedCourse();
            //selectedCourse.Should().Be("Mestrado em Engenharia de Software", "porque o curso selecionado deve ser o esperado.");
            _graduationPage.WaitClickNextButton();
        }

        [When("preencher o formulario de cadastro")]
        public void WhenPreencherOFormularioDeCadastro()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "TestData", "data.json");
            FormData formData = JsonUtils.GetFormData(filePath);
            _graduationPage.FillForm(formData);
            _graduationPage.WaitClickNextButton();
        }

        [When("fazer login com meu usuario cadastrado")]
        public void WhenFazerLoginComMeuUsuarioCadastrado()
        {
            _graduationPage.FillCredentials();
            _graduationPage.WaitClickLoginButton();
            _graduationPage.IsLoggedIn();
        }

        [Then("devo visualizar a pagina interna do candidato")]
        public void ThenDevoVisualizarAPaginaInternaDoCandidato()
        {
            _graduationPage.WaitElementLbl();
        }
    }
}