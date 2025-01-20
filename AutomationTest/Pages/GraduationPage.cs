using OpenQA.Selenium;
using AutomationTest.Utilities;
using AutomationTest.Models;



namespace AutomationTest.Pages
{
    public class GraduationPage
    {
        private readonly IWebDriver _driver;

        public GraduationPage(IWebDriver driver)
        {
            _driver = driver;
        }
        
        private IWebElement NivelGraduacao => _driver.FindElement(By.XPath("//div[@role='option'][contains(.,'Graduação')]"));
        private IWebElement GraduationCombo => TestIdUtils.FindByTestId("graduation-combo");
        private IWebElement Search => _driver.FindElement(By.XPath("//input[contains(@type,'text')]"));
        private IWebElement LblAreaDoCandidato => _driver.FindElement(By.TagName("h1"));
        private IWebElement LblPaginaInternaCandidato => _driver.FindElement(By.XPath("//span[contains(.,'Área do candidato')]"));
        private IWebElement ImgAEducacao => _driver.FindElement(By.XPath("//img[contains(@alt,'+A Educação')]"));

        // Formulário
        private IWebElement CpfField => TestIdUtils.FindByTestId("cpf-input");
        private IWebElement NameField => TestIdUtils.FindByTestId("name-input");
        private IWebElement SurnameField => TestIdUtils.FindByTestId("surname-input");
        private IWebElement SocialNameField => TestIdUtils.FindByTestId("social-name-input");
        private IWebElement EmailField => TestIdUtils.FindByTestId("email-input");
        private IWebElement CellphoneField => TestIdUtils.FindByTestId("cellphone-input");
        private IWebElement PhoneField => TestIdUtils.FindByTestId("phone-input");
        private IWebElement CepField => TestIdUtils.FindByTestId("cep-input");
        private IWebElement AddressField => TestIdUtils.FindByTestId("address-input");
        private IWebElement ComplementField => TestIdUtils.FindByTestId("complement-input");
        private IWebElement NeighborhoodField => TestIdUtils.FindByTestId("neighborhood-input");
        private IWebElement CityField => TestIdUtils.FindByTestId("city-input");
        private IWebElement StateField => TestIdUtils.FindByTestId("state-input");
        private IWebElement CountryField => TestIdUtils.FindByTestId("country-input");

        // Buttons
        private IWebElement SelectCombobox => _driver.FindElement(By.XPath("//button[@role='combobox'][contains(.,'Selecione uma opção...')]"));
        private IWebElement NextButton => TestIdUtils.FindByTestId("next-button");
        private IWebElement LoginButton => TestIdUtils.FindByTestId("login-button");

        // Authentication
        private IWebElement UsernameField => TestIdUtils.FindByTestId("username-input");
        private IWebElement PasswordField => TestIdUtils.FindByTestId("password-input");

        // Methods to interact with the page
        public void OpenSite()
        {
            _driver.Navigate().GoToUrl("https://developer.grupoa.education/subscription/");
        }

        public bool WaitForOpenSite(int timeoutInSeconds = 10)
        {
            return WaitUtils.WaitForElementToBeVisible(_driver, ImgAEducacao, timeoutInSeconds);
        }

        public bool WaitElementImgEducacao()
        {
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    if (WaitUtils.WaitForElementToBeVisible(_driver, ImgAEducacao, 10))
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    Thread.Sleep(5000);
                    continue;
                }
            }
            return false;
        }

        public void WaitSelectComboboxEducationLevel()
        {
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    Thread.Sleep(2000);
                    SelectCombobox.Click();
                    break;
                }
                catch (Exception)
                {
                    Thread.Sleep(5000);
                    continue;
                }
            }
        }

        public void WaitNivelGraduacaoEducationLevel()
        {
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    Thread.Sleep(2000);
                    NivelGraduacao.Click();
                    break;
                }
                catch (Exception)
                {
                    Thread.Sleep(5000);
                    continue;
                }
            }
        }

        public void WaitGraduationCombo()
        {
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    Thread.Sleep(2000);
                    GraduationCombo.Click();
                    Search.Click();
                    Search.SendKeys("Mestrado em Ciência da Computação" + Keys.Enter);
                    break;
                }
                catch (Exception)
                {
                    Thread.Sleep(5000);
                    continue;
                }
            }
        }

        public void FillFormFromJson()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "TestData", "data.json");

            try
            {
                FormData data = JsonUtils.GetFormData(filePath);
                FillForm(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler o arquivo JSON: {ex.Message}");
            }
        }

        public void FillForm(FormData data)
        {
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    CpfField.SendKeys(data.Cpf);
                    NameField.SendKeys(data.Name);
                    SurnameField.SendKeys(data.Surname);
                    SocialNameField.SendKeys(data.SocialName);
                    EmailField.SendKeys(data.Email);
                    CellphoneField.SendKeys(data.Cellphone);
                    PhoneField.SendKeys(data.Phone);
                    CepField.SendKeys(data.Cep);
                    AddressField.SendKeys(data.Address);
                    ComplementField.SendKeys(data.Complement);
                    NeighborhoodField.SendKeys(data.Neighborhood);
                    CityField.SendKeys(data.City);
                    StateField.SendKeys(data.State);
                    CountryField.SendKeys(data.Country);
                    break;
                }
                catch (Exception)
                {
                    Thread.Sleep(5000);
                    continue;
                }
            }
        }

        public void FillCredentials()
        {
            WaitClickNextButton();

            for (int i = 0; i < 2; i++)
            {
                try
                {
                    UsernameField.SendKeys("candidato");
                    PasswordField.SendKeys("subscription");
                    break;
                }
                catch (Exception)
                {
                    Thread.Sleep(5000);
                    continue;
                }
            }
        }

        public void WaitElementLbl()
        {
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    var lblAreaDoCandidato = LblAreaDoCandidato;
                    break;
                }
                catch (Exception)
                {
                    Thread.Sleep(5000);
                    continue;
                }
            }
        }

        public void WaitClickNextButton()
        {
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    NextButton.Click();
                    break;
                }
                catch (Exception)
                {
                    Thread.Sleep(8000);
                    continue;
                }
            }
        }

        public void WaitClickLoginButton()
        {
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    LoginButton.Click();
                    break;
                }
                catch (Exception)
                {
                    Thread.Sleep(5000);
                    continue;
                }
            }
        }

        public string GetPageTitle()
        {
            return _driver.Title;
        }

        public bool IsLoggedIn()
        {
            try
            {
                return LblPaginaInternaCandidato.Displayed;
            }
            catch (NoSuchElementException)
            {
                Thread.Sleep(5000);
                return false;
            }
        }
    }
}
