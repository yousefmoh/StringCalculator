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
            int brackets_counter = numbers.Count(f => f == '[');




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
            //4. Support different delimiters  without brackets
            else if (brackets_counter == 0 && numbers.StartsWith("//"))
            {
                delimiter = numbers.Substring(2, 1);
                numbers = numbers.Substring(3);
                delimiters = numbers.Split(new string[] { delimiter, "\n" }, StringSplitOptions.RemoveEmptyEntries);

            }


            //  Multiple delimiters with any length
            else 
            {

                string[] deleminters = new string[brackets_counter + 1];

                for (int i = 0; i < brackets_counter; i++)
                {
                    delimiter = numbers.Split('[', ']')[1];
                    deleminters[i] = delimiter;
                    numbers = numbers.Substring(numbers.IndexOf(']') + 1);

                }

                deleminters[brackets_counter] = "\n";
                
                delimiters = numbers.Split(deleminters, StringSplitOptions.RemoveEmptyEntries);
                


            }

            /* split 
             * check negative numbers (5)
             * check numbers bigger than 1000 (6)
             * 
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
                    else if (temp > 0 && temp <= 1000)
                    {
                        result = temp + result;
                    }
                }
            }


            // Negative Numbers Exception Message
            if (!string.IsNullOrEmpty(negative_numbers))
            {
                throw new Exception("negatives not allowed " + negative_numbers);

            }
            return result;

        }

    }


}
