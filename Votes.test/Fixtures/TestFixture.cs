using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Votes.Selenium.test.Fixtures
{
    public class TestFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; } 

        //Setup
        public TestFixture()
        {
            Driver = new ChromeDriver(TestHelper.ExecuteFolder);
        }

        //TearDown
        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
