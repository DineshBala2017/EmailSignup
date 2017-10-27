using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Whataburger_Dotcom_EmailSignup.constants;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace Whataburger_Dotcom_EmailSignup.pages
{
    public class Emailsignup_homepage
    {
        private IWebDriver driver;
        public String Successmessage;
        public String Duplicatemessage;

        public Emailsignup_homepage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void data(String fname, String lname, String email, String cemail, String year, String date, String month, String Zip)
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
            elementToClick.SendKeys(month + "/" + date + "/" + year);




            driver.FindElement(By.Id(Element.Zip)).Click();
            driver.FindElement(By.Id(Element.Zip)).SendKeys(Zip);
            //driver.FindElement(By.Id(Element.Zip)).SendKeys(Convert.ToString(Zip));
            driver.FindElement(By.Id("VisitFrequency")).SendKeys("weekly");
            System.Threading.Thread.Sleep(300);
            driver.FindElement(By.Id(Element.Agreeterms)).Click();
            driver.FindElement(By.Id(Element.Submit)).Click();

            System.Threading.Thread.Sleep(1000);
          
        }

            public void SuccessemailSignup()
            {
            if(driver.FindElement(By.XPath("//*[@id='content']/div/div/div[2]/h2/span")).Enabled)
            {
                IWebElement Success = driver.FindElement(By.XPath("//*[@id='content']/div/div/div[2]/h2/span"));
                Successmessage = Success.GetAttribute("textContent");
            }           
            }

           public void Duplicateemailsignup()
           {
            if (driver.FindElement(By.XPath("//*[@id='content']/div/div/div[2]/p")).Enabled)
            {
                IWebElement Duplicate = driver.FindElement(By.XPath("//*[@id='content']/div/div/div[2]/p"));
                Duplicatemessage = Duplicate.GetAttribute("textContent");
            }
            }

        public void NextSignup()
        {

         driver.FindElement(By.CssSelector("[href*='Signup']")).Click();

        }
        }
        }
    







