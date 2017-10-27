using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using Whataburger_Dotcom_EmailSignup.pages;
using Whataburger_Dotcom_EmailSignup.datatable;
using Whataburger_Dotcom_EmailSignup.constants;


namespace Whataburger_DotcomEmailSignup
{
    [TestFixture]
    public class Invalidemailvalidation
    {
       
        String Sheetname = "EmailSignup_Field Level Validat";
        private IWebDriver driver;
        Exceldata data = new Exceldata();
        public String result;

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
        public void InvalidEmail()
        {

            EmailSignup_Error_Messages errorpage = new EmailSignup_Error_Messages(driver);
           
            Assertions validation = new Assertions();

            data.Openexcel(Sheetname);
                for (int i = 2; i < 3; i++)
                {
                    data.Readexcel(i);
                    errorpage.data(data.Fname, data.Lname, data.email, data.cemail, data.year, data.date, data.month, data.Zipcode);
                 errorpage.emailisvalid();
                 String emailrequired = errorpage.emailrequired;

                validation.AssertEqual("Invalid Email Address", emailrequired);
                data.writedata(i, emailrequired);
                errorpage.NextSignup();
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

