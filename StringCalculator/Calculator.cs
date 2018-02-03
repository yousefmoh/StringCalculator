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
            string delimiter="";
            int temp = 0;
            string negative_numbers = "";



            //Empty String 
            if (string.IsNullOrEmpty(numbers))
            {
                result = 0;
            }
            //Length of string equals 1
            else if (numbers.Length == 1)
            {
                temp = int.Parse(numbers);
                if(temp<0)
                {

                    negative_numbers = negative_numbers + temp;
                }
                else
                result = temp;
                
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
            else if (numbers.Contains("\n") && !numbers.StartsWith("//"))
            {
                delimiters = numbers.Split(new string[] { ",", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            }
            //4. Support different delimiters 
            else 
            {
                delimiter = numbers.Substring(2, 1);
                numbers = numbers.Substring(3);
                delimiters = numbers.Split(new string[] { delimiter, "\n" }, StringSplitOptions.RemoveEmptyEntries);

            }

            /* split 
             * check negative numbers (5)
             * */
            if (delimiters.Length > 0)
            {

                foreach (string number in delimiters)
                {
                    temp = int.Parse(number);
                    if (temp < 0)
                    {

                        negative_numbers = negative_numbers + temp;
                    }
                    else 
                    result = temp + result;
                }
            }

            if (!string.IsNullOrEmpty(negative_numbers))
            {
                throw new Exception("negatives not allowed " + negative_numbers);

            }
            return result;

        }

    }


}
