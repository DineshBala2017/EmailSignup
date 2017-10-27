using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Whataburger_Dotcom_EmailSignup.constants

{
    public class Assertions
    {
        
        public String result;


        public void AssertEqual(String Expectedresult,String ActualResult)
        {
           Assert.AreEqual(Expectedresult, ActualResult);

        }

        public void AsserNotEqual(String Expectedresult, String ActualResult)
        {
            Assert.AreNotEqual(Expectedresult, ActualResult, ActualResult);
        }
         
       
    }
}
