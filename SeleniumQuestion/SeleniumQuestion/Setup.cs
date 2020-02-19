using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumQuestion
{
    public class Setup : IDisposable
    {
        internal IWebDriver driver { get; }        
        public Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:44379");

        }

        public void Dispose()
        {
            if(!(driver is null))
            {
                driver.Quit();
            }
        }
    }
}