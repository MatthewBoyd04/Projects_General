using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace _3N_1_Adaptive
{
    internal class Program
    {
        const int Threshold = int.MaxValue; // Set your threshold value here (e.g., int.MaxValue)

        static void Main(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
                i--;
                Console.Clear();
                BigInteger nextValidNumber = FindNextValidNumber();
                Console.WriteLine("Next Valid Number: " + nextValidNumber);
                Check_Next_Number(nextValidNumber, true);
            }
            Console.ReadLine();
        }

        private static BigInteger FindNextValidNumber()
        {
            BigInteger[] InvalidNumbers = ReadNumbersFromFile("C:\\Users\\chunk\\Desktop\\3N + 1 Challenge\\Checked_Numbers.txt");
            BigInteger VNum = 1;
            int j = 0;
            while (j < InvalidNumbers.Length && VNum == InvalidNumbers[(int)j])
            {
                VNum++;
                j++;
            }
            return VNum;
        }

        public static BigInteger[] ReadNumbersFromFile(string filePath)
        {
            try
            {
                string content = File.ReadAllText(filePath);
                string[] numberStrings = content.Split(',');
                BigInteger[] numbers = new BigInteger[numberStrings.Length];

                for (BigInteger i = 0; i < numberStrings.Length; i++)
                {
                    if (BigInteger.TryParse(numberStrings[(int)i], out BigInteger number))
                    {
                        numbers[(int)i] = number;
                    }
                }

                return numbers;
            }
            catch (FileNotFoundException)
            {
            }
            return new BigInteger[0]; // Return an empty array if an error occurs.
        }

        static BigInteger Check_Next_Number(BigInteger Num, bool x)
        {
            string filePath = "C:\\Users\\chunk\\Desktop\\3N + 1 Challenge\\Checked_Numbers.txt";
            BigInteger[] InvalidNumbers = ReadNumbersFromFile(filePath);
            List<BigInteger> NumberTrail = new List<BigInteger>();
            BigInteger OriginalNumber = Num;
            while (x)
            {
                NumberTrail.Add(Num);
                Num = Calculate(Num);
                BigInteger j = 0;
                Console.Clear();
                Console.WriteLine("Currently Checking: " + OriginalNumber);
                foreach (BigInteger i in InvalidNumbers)
                {
                    if (Num == InvalidNumbers[(int)j])
                    {
                        x = false;
                    }
                    else if (Num < 0)
                    {
                        Console.ReadLine();
                    }
                    j++;
                }

            }
            // Combine the NumberTrail list with the InvalidNumbers list
            List<BigInteger> combinedList = NumberTrail.Concat(InvalidNumbers).ToList();

            // Remove duplicates from the combinedList
            combinedList = new HashSet<BigInteger>(combinedList).ToList();

            // Sort the combined list
            combinedList.Sort();

            // Write the sorted list back to the file in the desired format
            File.WriteAllText(filePath, string.Join(",", combinedList));

            File.WriteAllText("C:\\Users\\chunk\\Desktop\\3N + 1 Challenge\\Numbers_Checked.txt", combinedList.Count.ToString());

            //Longest Number Trail so far: 

            return 0;
        }

        static BigInteger Calculate(BigInteger Num)
        {
            BigInteger NewNum = 0;
            if (Num % 2 == 0)
            {
                NewNum = Num / 2;

            }
            else
            {
                NewNum = (Num * 3) + 1;
            }

            return NewNum;
        }
    }
}
