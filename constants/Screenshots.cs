using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenQA.Selenium;
using System.Collections;
using System.Drawing.Imaging;

namespace EmailSignuWhataburger_DotcomEmailSignup.constants
{
    public class Screenshots
    {
       
            private IWebDriver driver;
          
            

            public Screenshots(IWebDriver driver)
            {
                this.driver = driver;
            }

        public void TakeScreenshot(IWebDriver driver, string saveLocation)
        {
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
          //  screenshot.SaveAsFile(saveLocation, System.Drawing.Imaging.ImageFormat.Png);
        }
    }

    }

