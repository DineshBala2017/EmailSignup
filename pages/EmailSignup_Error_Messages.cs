using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Whataburger_Dotcom_EmailSignup.constants;


namespace Whataburger_Dotcom_EmailSignup.pages
{
    public class EmailSignup_Error_Messages
    {
        public String emailrequired;
        public String confirmvalidation;
        public String Birthdayvalidation;
        public String Ageerror;
        private IWebDriver driver;
        public EmailSignup_Error_Messages(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void data(String fname, String lname, String email, String cemail, String year, String Date, String month, String Zip)
        {

            //Email Signup Form

            WebElements Element = new WebElements();

            driver.FindElement(By.Id(Element.Firstname)).SendKeys(fname);


            driver.FindElement(By.Id(Element.Lastname)).SendKeys(lname);

            driver.FindElement(By.Id(Element.Email)).SendKeys(email);



            driver.FindElement(By.Id(Element.Confiremail)).SendKeys(cemail);



            IWebElement elementToClick = driver.FindElement(By.Name(Element.Birthday));
            (driver as IJavaScriptExecutor).ExecuteScript(string.Format("window.scrollTo(0, {0});",
             elementToClick.Location.Y));


            elementToClick.Click();
            elementToClick.SendKeys(month + "/" + Date + "/" + year);
            driver.FindElement(By.Id(Element.Zip)).Click();
            driver.FindElement(By.Id(Element.Zip)).SendKeys(Convert.ToString(Zip));
            driver.FindElement(By.Id("VisitFrequency")).SendKeys("weekly");
            driver.FindElement(By.Id(Element.Agreeterms)).Click();
            driver.FindElement(By.Id(Element.Submit)).Click();

            System.Threading.Thread.Sleep(1000);

           
        }

        public void NextSignup()
        {

            driver.FindElement(By.CssSelector("[href*='Signup']")).Click();

        }

        public void emailisvalid()
        {
            if (driver.FindElement(By.XPath("//*[@id='content']/div/div/div[2]/form/fieldset/div[3]/span/span")).Enabled)

            {

                IWebElement erequired = driver.FindElement(By.XPath("//*[@id='content']/div/div/div[2]/form/fieldset/div[3]/span/span"));
                emailrequired = erequired.GetAttribute("textContent");

            }
        }

        public void Confirmemailvalidation()
        {
            if (driver.FindElement(By.XPath("//*[@id='errorNotMatch']")).Enabled)

            {

                IWebElement erequired = driver.FindElement(By.XPath("//*[@id='errorNotMatch']"));
                confirmvalidation = erequired.GetAttribute("textContent");

            }
        }

        public void BirthdayfieldValidation()
        {
            if (driver.FindElement(By.XPath("//*[@id='errorFormat']")).Enabled)

            {

                IWebElement erequired = driver.FindElement(By.XPath("//*[@id='errorFormat']"));
                Birthdayvalidation = erequired.GetAttribute("textContent");
            }
        }

            public void Agevalidation()
            {
                if (driver.FindElement(By.XPath("//*[@id='errorYoung']")).Enabled)

                {

                    IWebElement erequired = driver.FindElement(By.XPath("//*[@id='errorYoung']"));
                    Ageerror = erequired.GetAttribute("textContent");
                }




            }
        }
}
