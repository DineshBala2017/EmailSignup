using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using Whataburger_Dotcom_EmailSignup.pages;
using Whataburger_Dotcom_EmailSignup.datatable;
using Whataburger_Dotcom_EmailSignup.constants;

namespace scenarios.Whataburger_Dotcom_EmailSignup
{
    [TestFixture]
    public class EmailSignupSuccess
    {
        Exceldata data = new Exceldata();
        String Sheetname = "EmailSignup_HappyPath";
        private IWebDriver driver;
        [SetUp]
        public void Browsersetup()
        {

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://wbdotcomqa.azurewebsites.net/");

            System.Threading.Thread.Sleep(2000);

            //Tap in Email Signup

            IWebElement emailsignup_link = driver.FindElement(By.CssSelector("[href*='Signup']"));
            emailsignup_link.Click();
            System.Threading.Thread.Sleep(1000);

        }
        [Test]
        public void HappypathTest()
        {
            Emailsignup_homepage page = new Emailsignup_homepage(driver);
            Assertions validation = new Assertions();
            Messages message = new Messages();

            data.Openexcel(Sheetname);
            for (int i = 2; i<4; i++)
            {
                data.Readexcel(i);
                page.data(data.Fname, data.Lname, data.email, data.cemail, data.year, data.date, data.month, data.Zipcode);
                page.SuccessemailSignup();
                System.Threading.Thread.Sleep(500);
                String Confirmation = page.Successmessage.Trim();
                data.writedata(i, Confirmation);
                validation.AssertEqual(message.sucessconfirmation, Confirmation);
                page.NextSignup();

            }
           // driver.Close();
        }
            
            [TearDown]

            public void Quitdriver()
        {
           driver.Quit();
           data.savedata();
           
        }

    }
}
