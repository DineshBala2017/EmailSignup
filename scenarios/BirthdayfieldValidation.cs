using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using Whataburger_Dotcom_EmailSignup.pages;
using Whataburger_Dotcom_EmailSignup.datatable;
using Whataburger_Dotcom_EmailSignup.constants;
using EmailSignuWhataburger_DotcomEmailSignup.constants;
namespace EmailSignuWhataburger_DotcomEmailSignup.scenarios
{
    [TestFixture]
    public class BirthdayfieldValidation
    {

        public String Sheetname = "EmailSignup_Field Level Validat";
        private IWebDriver driver;
        Exceldata data = new Exceldata();
        Messages Error = new Messages();

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
        public void BirthdayValidation()
        {
            EmailSignup_Error_Messages errorpage = new EmailSignup_Error_Messages(driver);


            Assertions validation = new Assertions();

            data.Openexcel(Sheetname);
            for (int i = 2; i < 3; i++)
            {
                data.Readexcel(i);
                errorpage.data(data.Fname, data.Lname, data.email, data.cemail, data.year, data.date, data.month, data.Zipcode);
                errorpage.BirthdayfieldValidation();
                String Birthdayerror = errorpage.Birthdayvalidation;
                validation.AssertEqual(Error.Invalidbirthday, Birthdayerror);
                data.writedata(i, Birthdayerror);
                errorpage.NextSignup();


            }
        }
        // driver.Close();

        [TearDown]

        public void Quitdriver()
        {
            driver.Quit();
            data.savedata();
        }
    }
}
