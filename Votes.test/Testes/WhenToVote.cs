using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using Votes.Selenium.test.Fixtures;
using Xunit;

namespace Votes.Selenium.test.Testes
{
    [Collection("Chrome Driver")]
    public class WhenToVote
    {
        private IWebDriver driver;
        protected ReadOnlyCollection<IWebElement> WebElements { get; }
        public WhenToVote(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact] 
        public void GivenOldDateMustShowErrorMessage()
        {
            //arrange - dado chrome aberto, e passado uma data antiga
            driver.Navigate().GoToUrl("https://localhost:44399/");

            var inputDate = driver.FindElement(By.Id("date"));
            var date = DateTime.Today;
            var data = date.AddDays(-1);
            inputDate.SendKeys(data.ToString("MM/dd/yyyy HH:mm:ss"));

            var inputUser = driver.FindElement(By.Id("user"));
            var inputRadio = driver.FindElement(By.CssSelector("input[type=radio][name=radio]"));
            var buttonVote = driver.FindElement(By.Id("btn"));

            inputUser.SendKeys("andre.melo");
            if (inputRadio.Selected == false)
                inputRadio.Click();

            //act - efetuo o voto
            buttonVote.Click();

            //assert - deve aparecer msg de erro
            IWebElement element = driver.FindElement(By.CssSelector("div.error"));
            Assert.Equal("Não é possível selecionar uma data antiga", element.Text); 
        }

        [Fact]
        public void GivenInvalidUserMustShowErrorMessage()
        {
            //arrange - dado chrome aberto, e um user inesistente
            driver.Navigate().GoToUrl("https://localhost:44399/");

            var inputDate = driver.FindElement(By.Id("date"));
            var date = DateTime.Today;
            var data = date.AddDays(1);
            inputDate.SendKeys(data.ToString("MM/dd/yyyy HH:mm:ss"));

            var inputUser = driver.FindElement(By.Id("user"));
            var inputRadio = driver.FindElement(By.CssSelector("input[type=radio][name=radio]:not([disabled])"));
            var buttonVote = driver.FindElement(By.Id("btn"));

            inputUser.SendKeys("kelly.figueira");
            if (inputRadio.Selected == false)
                inputRadio.Click();

            //act - efetuo o voto
            buttonVote.Click();

            //assert - deve aparecer msg de erro
            IWebElement element = driver.FindElement(By.CssSelector("div.error"));
            Assert.Equal("Este usuário não existe.", element.Text);
        }

        [Fact]
        public void GivenValidDataMustShowSucessfulMessage()
        {
            //arrange - dado chrome aberto,  dados corretos
            driver.Navigate().GoToUrl("https://localhost:44399/");

            var inputDate = driver.FindElement(By.Id("date"));
            var date = DateTime.Today;
            var data = date.AddDays(1);
            inputDate.SendKeys(data.ToString("MM/dd/yyyy HH:mm:ss"));

            var inputUser = driver.FindElement(By.Id("user"));
            var inputRadio = driver.FindElement(By.CssSelector("input[type=radio][name=radio]:not([disabled])"));
            var buttonVote = driver.FindElement(By.Id("btn"));

            inputUser.SendKeys("kelly.prado");
            if (inputRadio.Selected == false)
                inputRadio.Click();
            
            //act - efetuo o voto
            buttonVote.Click();

            //assert - deve aparecer msg de sucesso
            IWebElement element = driver.FindElement(By.CssSelector("div.sucess"));
            Assert.Equal("Voto concluido com sucesso!", element.Text);
        }

        [Fact]
        public void GivenRepeatedUserMustShowErrorMessage()
        {
            //arrange - dado chrome aberto, e data de hoje após meio dia
            driver.Navigate().GoToUrl("https://localhost:44399/");

            //primeiro voto
            var inputDate = driver.FindElement(By.Id("date"));
            var date = DateTime.Today;
            var data = date.AddDays(1);
            inputDate.SendKeys(data.ToString("MM/dd/yyyy HH:mm:ss"));

            var inputUser = driver.FindElement(By.Id("user"));
            var inputRadio = driver.FindElement(By.CssSelector("input[type=radio][name=radio]:not([disabled])"));
            var buttonVote = driver.FindElement(By.Id("btn"));

            inputUser.SendKeys("pedro.metli");
            if (inputRadio.Selected == false)
                inputRadio.Click();

            //act - efetuo o voto
            buttonVote.Click();

            //SEGUNDO VOTO
            var inputDate2 = driver.FindElement(By.Id("date"));
            var date2 = DateTime.Today;
            var data2 = date2.AddDays(1);
            inputDate2.SendKeys(data2.ToString("MM/dd/yyyy HH:mm:ss"));

            var inputUser2 = driver.FindElement(By.Id("user"));
            var inputRadio2 = driver.FindElement(By.CssSelector("input[type=radio][name=radio]:not([disabled])"));
            var buttonVote2 = driver.FindElement(By.Id("btn"));

            inputUser2.SendKeys("pedro.metli");
            if (inputRadio2.Selected == false)
                inputRadio2.Click();

            //act - efetuo o voto
            buttonVote2.Click();

            //assert - deve aparecer msg de erro
            IWebElement element= driver.FindElement(By.CssSelector("div.error"));
            Assert.Equal("Você já votou neste dia!", element.Text);
        }

        [Fact]
        public void GivenWeekendDateMustShowErrorMessage()
        {
            //arrange - dado chrome aberto, e data no fim de semana
            driver.Navigate().GoToUrl("https://localhost:44399/");

            var inputDate = driver.FindElement(By.Id("date"));
            var date = DateTime.Today;
            var data = date.AddDays(3);
            inputDate.SendKeys(data.ToString("MM/dd/yyyy HH:mm:ss"));

            var inputUser = driver.FindElement(By.Id("user"));
            var inputRadio = driver.FindElement(By.CssSelector("input[type=radio][name=radio]:not([disabled])"));
            var buttonVote = driver.FindElement(By.Id("btn"));

            inputUser.SendKeys("pedro.metli");
            if (inputRadio.Selected == false)
                inputRadio.Click();

            //act - efetuo o voto
            buttonVote.Click();

            //assert - deve aparecer msg de erro
            IWebElement element = driver.FindElement(By.CssSelector("div.error"));
            Assert.Equal("Não é possível votar no final de semana.", element.Text);
        }
    }
}
