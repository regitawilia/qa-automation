//Inside SeleniumTest.cs

using NUnit.Framework;

using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Firefox;

using System;

using System.Collections.ObjectModel;

using System.IO;

namespace SeleniumCsharp

{

    public class Test

    {

        IWebDriver? driver;

        [OneTimeSetUp]
        public void Setup()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName; ;
            driver = new ChromeDriver(path + @"\drivers\");
        }

        [Test]
        public void Completeform()
        {
            driver.Navigate().GoToUrl("http://computer-database.gatling.io/computers");
            IWebElement add = driver.FindElement(By.Id("add"));
            System.Threading.Thread.Sleep(1000);
            add.Click();

            driver.FindElement(By.Id("name")).SendKeys("Xtramile");
            driver.FindElement(By.Id("introduced")).SendKeys("2022-01-01");
            driver.FindElement(By.Id("discontinued")).SendKeys("2022-12-31");
            IWebElement company = driver.FindElement(By.Id("company"));
            company.SendKeys("RCA");

            IWebElement submit = driver.FindElement(By.XPath("//body/section[@id='main']/form[1]/div[1]/input[1]"));
            System.Threading.Thread.Sleep(1000);
            submit.Click();
            System.Threading.Thread.Sleep(1000);
        }

        [Test]
        public void Edit()
        {
            driver.Navigate().GoToUrl("http://computer-database.gatling.io/computers");
            IWebElement view = driver.FindElement(By.LinkText("ACE"));
            view.Click();

            driver.FindElement(By.Id("name")).Clear();
            driver.FindElement(By.Id("name")).SendKeys("Xtramile Edit");
            IWebElement submit = driver.FindElement(By.CssSelector("body:nth-child(2) section:nth-child(2) form:nth-child(2) div.actions:nth-child(2) > input.btn.primary:nth-child(1)"));
            System.Threading.Thread.Sleep(1000);
            submit.Click();
            System.Threading.Thread.Sleep(1000);
        }

        [Test]
        public void Search()
        {
            IWebElement searchbox = driver.FindElement(By.Id("searchbox"));
            searchbox.SendKeys("ACE");
            IWebElement add = driver.FindElement(By.Id("searchsubmit"));
            System.Threading.Thread.Sleep(1000);
            add.Click();
        }

        [Test]
        public void Delete()
        {
            driver.Navigate().GoToUrl("http://computer-database.gatling.io/computers");
            IWebElement view = driver.FindElement(By.LinkText("AN/FSQ-32"));
            view.Click();
            IWebElement submit = driver.FindElement(By.CssSelector("body:nth-child(2) section:nth-child(2) form.topRight:nth-child(3) > input.btn.danger"));
            System.Threading.Thread.Sleep(1000);
            submit.Click();
            System.Threading.Thread.Sleep(1000);
        }

        [Test]
        public void GoToNextPage()
        {
            driver.Navigate().GoToUrl("http://computer-database.gatling.io/computers");
            IWebElement view = driver.FindElement(By.CssSelector("section:nth-child(2) div.pagination:nth-child(4) ul:nth-child(1) li.next > a:nth-child(1)"));
            System.Threading.Thread.Sleep(1000);
            view.Click();
            System.Threading.Thread.Sleep(1000);
        }

        [OneTimeTearDown]
        public void TearDown()

        {

            driver.Quit();

        }

    }

}
