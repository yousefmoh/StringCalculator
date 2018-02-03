using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;
namespace StringCalculatorUnitTest
{
    [TestClass]
    public class CalculatorUnitTest
    {
        Calculator test = new Calculator();

        //Empty Input
        [TestMethod]
        public void AddEmptyInput()
        {

            Assert.AreEqual(0, test.Add(""));


        }

        //Input with one number 
        [TestMethod]
        public void AddOneNumber()
        {
            Assert.AreEqual(4, test.Add("4"));
        }


        //Input with Two numbers 
        [TestMethod]
        public void AddTowNumbers()
        {
            Assert.AreEqual(6, test.Add("4,2"));
        }

        //Input Without newline
        [TestMethod]
        public void AddWithoutNewLine()
        {
            Assert.AreEqual(5, test.Add("1,2,2"));
        }


        //Input With New Line
        [TestMethod]
        public void AddWithNewLine()
        {

            Assert.AreEqual(6, test.Add("1\n2,3"));

        }


        // single delimiter  
        [TestMethod]
        public void AddWithSingleDelimiter()
        {

            Assert.AreEqual(6, test.Add("//;\n1;2;3"));

        }


        // single delimiter with number bigger than 1000
        [TestMethod]
        public void AddBigNumber()
        {

            Assert.AreEqual(6, test.Add("//;\n1;2;3;1005"));

        }

        //Single delimiter in braces  
        [TestMethod]
        public void AddWithOneDelimiterSingleChar()
        {

            Assert.AreEqual(6, test.Add("//[*]\n1*2*3"));

        }


        //Multiple Delimiters Single Character 
        [TestMethod]
        public void AddWithMultiDelimiterSingleChar()
        {

            Assert.AreEqual(6, test.Add("//[*][%]\n1*2%3"));

        }

        // Delimiter Of Any Length 
        [TestMethod]
        public void AddWithMultiDelimiterChars()
        {

            Assert.AreEqual(6, test.Add("//[***]\n1***2***3"));

        }


        // Multiple delimiters  Of Any length
        [TestMethod]
        public void AddNumbersBiggerThanOneThousand()
        {

            Assert.AreEqual(5, test.Add("//[***][%%]\n1***2%%1001***2"));

        }

        // Multiple delimiters with 1000 number
        [TestMethod]
        public void AddNumbersWithOneThousand()
        {

            Assert.AreEqual(1005, test.Add("//[***][%%]\n1***2%%1000%%2"));

        }

    }
}
