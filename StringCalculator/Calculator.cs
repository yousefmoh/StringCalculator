using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {


        public int Add(string numbers)
        {
            int result = 0;
            string[] delimiters = { };



            //Empty String 
            if (string.IsNullOrEmpty(numbers))
            {
                result = 0;
            }
            //Length of string equals 1
            else if (numbers.Length == 1)
            {
                result = int.Parse(numbers);
            }

            //Invalid Input
            else if (numbers.Contains(",\n"))
            {
                throw new Exception("Invalid Input " );

            }

            //handle an unknown amount of numbers without new line 
            else if (numbers.Length > 1 && !numbers.Contains("\n"))
            {
                delimiters = numbers.Split(',');
            }
            else
            {
                delimiters = numbers.Split(new string[] { ",", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            }

            if (delimiters.Length > 0)
            {

                foreach (string number in delimiters)
                {
                    result = int.Parse(number) + result;
                }
            }






            return result;


        }

    }


}
