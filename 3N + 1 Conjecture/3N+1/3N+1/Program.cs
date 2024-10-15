using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace _3N_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Menu: Please Select");
            Console.WriteLine("Mode 1: Loop and update List");
            Console.WriteLine("Mode 2: Run Singular Number and show trail");
            Console.WriteLine("Mode 3: Run Next Valid Number ONLY and show trail");
            int UserChoice = Convert.ToInt32(Console.ReadLine());
            switch (UserChoice)
            {
                case 1:
                    {
                        Mode1();
                        break;
                    }
                case 2:
                    {
                        Mode2();
                        break;
                    }
                case 3:
                    {
                        Mode3();
                        break;
                    }
            }
        }

        static void Mode1()
        {
            for (BigInteger i = 0; i < 1000; i++)
            {
                i--;
                Console.Clear();
                BigInteger nextValidNumber = FindNextValidNumber();
                Console.WriteLine("Next Valid Number: " + nextValidNumber);
                Check_Next_Number(nextValidNumber, true);
            }
            Console.ReadLine();
        }

        static void Mode2()
        {
            Console.Clear();
            Console.WriteLine("Please enter a number:");
            BigInteger Num = BigInteger.Parse(Console.ReadLine());
            List<BigInteger> PreviousNumbers = new List<BigInteger>();
            while (Num != 1)
            {
                PreviousNumbers.Add(Num);
                Num = Calculate(Num);
                Console.Clear();
                Console.WriteLine("Original Number: " + PreviousNumbers[0]);
                Console.WriteLine("Currently On: " + Num);
                int j = 0;
                foreach (BigInteger i in PreviousNumbers)
                {
                    Console.Write(PreviousNumbers[j] + " > ");
                    j++;
                }
            }
            Console.ReadLine();
        }

        static void Mode3()
        {
            Console.Clear();
            BigInteger Num = FindNextValidNumber();
            List<BigInteger> PreviousNumbers = new List<BigInteger>();
            while (Num != 1)
            {
                PreviousNumbers.Add(Num);
                Num = Calculate(Num);
                Console.Clear();
                Console.WriteLine("Original Number: " + PreviousNumbers[0]);
                Console.WriteLine("Currently On: " + Num);
                int j = 0;
                foreach (BigInteger i in PreviousNumbers)
                {
                    Console.Write(PreviousNumbers[j] + " > ");
                    j++;
                }
            }
            Console.ReadLine();
        }

        private static BigInteger FindNextValidNumber()
        {
            BigInteger[] InvalidNumbers = ReadNumbersFromFile("C:\\Users\\chunk\\Desktop\\3N + 1 Challenge\\Checked_Numbers.txt");
            Array.Sort(InvalidNumbers);
            BigInteger VNum = 1;
            BigInteger j = 0;
            foreach (BigInteger i in InvalidNumbers)
            {
                if (VNum == InvalidNumbers[(int)j])
                {
                    VNum++;
                }
                else
                {
                }

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
                    else
                    {
                        Console.WriteLine($"Error parsing number: {numberStrings[(int)i]}");
                        // You can choose to handle the error differently, like skipping the invalid number.
                    }
                }

                return numbers;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found. Please make sure the specified file exists.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            return new BigInteger[0]; // Return an empty array if an error occurs.
        }

        static BigInteger Check_Next_Number(BigInteger Num, bool x)
        {
            string filePath = "C:\\Users\\chunk\\Desktop\\3N + 1 Challenge\\Checked_Numbers.txt";
            BigInteger[] InvalidNumbers = ReadNumbersFromFile(filePath);
            List<BigInteger> NumberTrail = new List<BigInteger>();
            BigInteger OriginalNumber = Num;
            Console.WriteLine("x = " + x);
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
                        Console.WriteLine(OriginalNumber + " Will go to 1, found at:" + InvalidNumbers[(int)j]);
                        x = false;
                    }
                    if (Num < 0 )
                    {
                        Console.ReadLine();
                    }
                    j++;
                }

                Console.WriteLine("Number Trail:");
                foreach (BigInteger number in NumberTrail)
                {
                    Console.Write(number + " ");
                    
                }
                Console.WriteLine();
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
                Console.WriteLine("Num = " + Num + " (Even), therefore /2    = " + NewNum);
                
            }
            else
            {
                NewNum = (Num * 3) + 1;
                Console.WriteLine("Num = " + Num + " (Odd), therefore *3 + 1 = " + NewNum);
            }

            return NewNum;
        }
    }
}