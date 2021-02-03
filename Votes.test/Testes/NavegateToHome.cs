using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using Votes.Selenium.test;
using Votes.Selenium.test.Fixtures;
using Xunit;

namespace Votes.test
{
    [Collection("Chrome Driver")]
    public class NavegateToHome 
    {

        private IWebDriver driver;

        //Setup
        public NavegateToHome(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void GivenProgramOpenedMustShowTittleHome()
        {
            //arrange
      
            //act
            driver.Navigate().GoToUrl("https://localhost:44399/");

            //assert 
            Assert.Contains("Home", driver.Title);
        }
        [Fact]
        public void GivenProgramOpenedMustShowRestaurantsHome()
        {
            //arrange
            driver.Navigate().GoToUrl("https://localhost:44399/");
            //act



            //assert 
            Assert.Contains("Pepperoni", driver.PageSource);
        }
    }
}
